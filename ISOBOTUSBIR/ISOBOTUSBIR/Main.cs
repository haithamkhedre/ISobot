using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace ISOBOTUSBIR
{
    public partial class Main : Form
    {
        Dictionary<string, string> dicCommands = new Dictionary<string,string>()
{{"Forward","898819"},
 { "Backward","964611"},
 { "Side Right","703491"},
 { "Side Left","637699"},
 { "Forward Left","1030403"},
 { "Forward Right","571907"},
 { "Backward Left","834819"},
 { "Bacward Right","900611"},
 { "Foward Clockwise","966403"},
 { "Forward Counter","1032195"},
 { "Backword Clockwise","573699"},
 { "Backword Counter","639491"},
 { "Head Left","907015"},
 { "Head Right","775948"},
 { "Lean Forward","841478"},
 { "Lean Back","1038081"},
 { "Left Punch","922368"},
 { "Box Left Right","661248"},
 { "Left Chop","858368"},
 { "Side Chop","663040"},
 { "Combo Punch","597248"},
 { "Right Punch","988160"},
 { "Right Chop","924160"},
 { "Box Right Left","792576"},
 { "Side Chopr","728832"},
 { "Left Backhand","529664"},
 { "Double Chop","989952"},
 { "Double Backhand","925952"},
 { "Slapping","860160"},
 { "Right Backhand","595456"},
 { "Upper Chop","531456"},
 { "Round Kick Left","991744"},
 { "Round Kick Right","533248"},
 { "Forward Kick Left","599040"},
 { "Forward Kick Right","664832"},
 { "Side kick","730624"},
 { "Round Kick Left Right","666624"},
 { "Forward kick Left Right","732416"},
 { "Combo Kick","798208"},
 { "Side Kick Right","796416"},
 { "Back Kick Left","927744"},
 { "Back Kick Right","993536"},
 { "High Kick Left","864000"},
 { "High Kick Right","995328"},
 { "Splits (1)","536832"},
 { "Guardl","602624"},
 { "Guardr","668416"},
 { "Double Guard1","734208"},
 { "Double Guard2","800000"},
 { "Dodge (L)","865792"},
 { "Dodge (R)","931584"},
 { "Duck","604160"},
 { "Sway Back","669952"},
 { "Upblock","735744"},
 { "Splits (2)","801536"},
 { "Combo Block","867328"},
 { "Zero","1034752"},
 { "Home Position","775424"},
 { "Sound Off","840451"},
 { "Affirm","540416"},
 { "Disagree","803328"},
 { "Goodmorning","934912"},
 { "Greet (1)","1000704"},
 { "Greet (2)","608000"},
 { "Greet (3)","739328"},
 { "Greet (4)","805120"},
 { "Bye (1)","870912"},
 { "Bye (2)","936704"},
 { "Bye (3)","1002496"},
 { "Bye (4)","544000"},
 { "Bye (5)","542208"},
 { "Respect","869120"},
 { "Thanks (1)","609792"},
 { "Thanks (2)","675584"},
 { "Love (1)","872704"},
 { "Love (2)","938496"},
 { "Love (3)","1004288"},
 { "Standup Front","933120"},
 { "Standup Back","998912"},
 { "Excited (1)","743168"},
 { "Excited (2)","874496"},
 { "Excited (3)","940288"},
 { "Excited (4)","618752"},
 { "Party","677376"},
 { "Amazed","750336"},
 { "Regret (1)","547584"},
 {"Regret (2)","744960"},
 {"Regret (3)","810752"},
 {"Worry","679168"},
 {"Pain (1)","1007872"},
 {"Pain (2)","615168"},
 {"Beg (1)","942080"},
 {"Beg (2)","880128"},
 {"Merry","552960"},
 {"Hilarious","1013504"},
 {"Hidenseek","613376"},
 {"Youlike","682752"},
 {"Mystery (5)","748544"},
 {"Tipsy","814336"},
 {"Tickle Me","686080"},
 {"Tired Feet","751872"},
 {"Needa Break","817664"},
 {"Wave (1)","883456"},
 {"Wave (2)","949248"},
 {"Applause","947712"},
 {"Mystery (6)","945920"},
 {"Too Sexy","1015040"},
 {"Clink","556544"},
 {"Relax","753664"},
 {"Soccer (1)","885248"},
 {"Soccer (2)","600832"},
 {"Soccer (3)","535040"},
 {"Lift","819456"},
 {"Count on me","951040"},
 {"Articulation","1016832"},
 {"Show off (1)","558336"},
 {"Show off (2)","624128"},
 {"Show off (3)","689920"},
 {"Show off (4)","821248"},
 {"Comin through","887040"},
 {"Catch","1006080"},
 {"Pose (1)","771840"},
 {"Pose (2)","903168"},
 {"Pose (3)","968960"},
 {"Mystery (1)","684544"},
 {"Mystery (2)","816128"},
 {"Mystery (3)","881920"},
 {"Mystery (4)","549376"},
 {"Forward some rsault","952832"},
 {"Head Stand exercises","1018624"},
 {"Exercises","560128"},
 {"Air Drum","625920"},
 {"Air Guitar","691712"},
 {"Random Performance1","954624"},
 {"Random Animal","627712"},
 {"Tropicaldance","825088"},
 {"Giant Robot","956416"},
 {"Western","1022208"},
 {"Random Performance2","629504"}};
        ListBox targetListBox;
        public Main()
        {
            InitializeComponent();
            string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
            cmbCom.Items.Add("Select Serial Port");
            cmbCom.Items.AddRange(theSerialPortNames);
            
            lstCommands.DataSource = new BindingSource(dicCommands, null);
            lstCommands.DisplayMember = "Key";
            lstCommands.ValueMember = "Value";
            lstCommands.SelectedIndex = -1;
            cmbCom.SelectedIndex = cmbCom.Items.Count - 1;
            optActions.Text = "Actions " + "(" + lstCommands.Items.Count + ")";
            targetListBox = lstCommands;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ISOBOT USB IR Remote v 1.0 by www.Robonavy.com","About",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void lstCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstCommands_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if(!chkDontSend.Checked)
            SendCommand();
        }

        private void SendCommand()
        {
            try
            {
                string command=string.Empty;
                if(optActions.Checked)
                    command= targetListBox.SelectedValue.ToString();
                else
                    command = dicCommands[targetListBox.SelectedItem.ToString()];
                SerialPort port = new SerialPort(cmbCom.Text, 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write(command);
                port.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Select Correct Serial Port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlayAll_Click(object sender, EventArgs e)
        {
            lstPlayList.SelectedIndex = -1;
            lstCommands.SelectedIndex = -1;
             
            bool rresult = int.TryParse(cmbRepeat.Text, out repeatCount );
            if (!rresult) repeatCount = 1; 
            int intervals = 10;
            bool result = int.TryParse(cmbTime.Text, out intervals);
            if (result)
                timer1.Interval = intervals * 1000;
            else
                MessageBox.Show("Enter Numbers Default will be 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            rand = false;
            timer1.Enabled = true;
            
        }

        int repeatCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            repeatCount--;
            int index = 0;
            if (!rand)
            {
                index = targetListBox.SelectedIndex + 1;
            }
            else
            {
                index = new Random().Next(targetListBox.Items.Count-1);
            }
            if (repeatCount <= 0)
            {
                if (targetListBox.SelectedIndex < targetListBox.Items.Count - 1)
                {
                    targetListBox.SelectedIndex =index ;
                    bool rresult = int.TryParse(cmbRepeat.Text, out repeatCount);
                    if (!rresult) repeatCount = 1; 
                }
                else
                    targetListBox.SelectedIndex = 0;
            }
            SendCommand();
            

        }

        private void optPlayList_CheckedChanged(object sender, EventArgs e)
        {
            if (optPlayList.Checked && lstPlayList.Items.Count > 0)
                targetListBox = lstPlayList;
            else
            {
                if (optPlayList.Checked)
                {
                    MessageBox.Show("Please Add Items First !", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    targetListBox = lstCommands;
                    optActions.Checked = true;
                    optPlayList.Checked = false;
                }
            }
        }

        private void optActions_CheckedChanged(object sender, EventArgs e)
        {
            if(optActions.Checked)
                targetListBox = lstCommands;
            else
                targetListBox = lstPlayList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in lstCommands.SelectedItems)
            {
                lstPlayList.Items.Add(item.ToString().Split(',')[0].Replace("[",""));
            }
            optPlayList.Checked = true;
            
            
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "ISOBOT (*.ISOBOT)|*.ISOBOT";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog1.FileName;
            // Write to the file name selected.
            // ... You can write the text from a TextBox instead of a string literal.
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lstPlayList.Items.Count-1; i++)
			{
			 sb.Append(lstPlayList.Items[i].ToString()+";");
			}  
            sb.Append(lstPlayList.Items[lstPlayList.Items.Count-1]);
            
            File.WriteAllText(name,sb.ToString());
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            lstPlayList.Items.Clear();
            openFileDialog1.Filter = "ISOBOT (*.ISOBOT)|*.ISOBOT";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    lstPlayList.Items.AddRange(text.Split(';')); 
                }
                catch (IOException)
                {
                }
            }
            optPlayList.Checked = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(lstPlayList.SelectedIndex>=0)
            lstPlayList.Items.RemoveAt(lstPlayList.SelectedIndex);
        }

        

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lstPlayList.SelectedIndex > 0)
            {
                string temp = lstPlayList.SelectedItem.ToString();
                string temp2 = lstPlayList.Items[lstPlayList.SelectedIndex - 1].ToString();
                lstPlayList.Items[lstPlayList.SelectedIndex - 1] = temp;
                lstPlayList.Items[lstPlayList.SelectedIndex] = temp2;
                lstPlayList.SelectedIndex -= 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lstPlayList.SelectedIndex < lstPlayList.Items.Count-1)
            {
                string temp = lstPlayList.SelectedItem.ToString();
                string temp2 = lstPlayList.Items[lstPlayList.SelectedIndex + 1].ToString();
                lstPlayList.Items[lstPlayList.SelectedIndex + 1] = temp;
                lstPlayList.Items[lstPlayList.SelectedIndex] = temp2;
                lstPlayList.SelectedIndex += 1;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Send raw command , coming soon...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbFreq_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbFreq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMode.Text != "Remote/Special Mode")
                MessageBox.Show("coming soon...,stay tuned :)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmbMode.Text = "Remote/Special Mode";
        }

        private void lstPlayList_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (!chkDontSend.Checked)
                SendCommand();
        }

        private void lstPlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cmbFreq_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbFreq.Text != "A")
                MessageBox.Show("coming soon...,stay tuned :)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmbFreq.Text = "A";
        }
        bool rand = false;
        private void btnPlayAllRandom_Click(object sender, EventArgs e)
        {
            rand = true;
            lstPlayList.SelectedIndex = -1;
            lstCommands.SelectedIndex = -1;

            bool rresult = int.TryParse(cmbRepeat.Text, out repeatCount);
            if (!rresult) repeatCount = 1;
            int intervals = 10;
            bool result = int.TryParse(cmbTime.Text, out intervals);
            if (result)
                timer1.Interval = intervals * 1000;
            else
                MessageBox.Show("Enter Numbers Default will be 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            timer1.Enabled = true;
        }
    }
}
