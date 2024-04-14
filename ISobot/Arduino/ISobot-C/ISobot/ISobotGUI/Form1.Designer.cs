namespace ISobotGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCommand = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lstCommand = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnCommand
            // 
            this.btnCommand.Location = new System.Drawing.Point(339, 43);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(75, 23);
            this.btnCommand.TabIndex = 0;
            this.btnCommand.Text = "Send";
            this.btnCommand.UseVisualStyleBackColor = true;
            this.btnCommand.Click += new System.EventHandler(this.btnCommand_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(74, 43);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(242, 20);
            this.txtCommand.TabIndex = 1;
            // 
            // lstCommand
            // 
            this.lstCommand.FormattingEnabled = true;
            this.lstCommand.Location = new System.Drawing.Point(74, 79);
            this.lstCommand.Name = "lstCommand";
            this.lstCommand.Size = new System.Drawing.Size(340, 238);
            this.lstCommand.TabIndex = 2;
            this.lstCommand.SelectedIndexChanged += new System.EventHandler(this.lstCommand_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 339);
            this.Controls.Add(this.lstCommand);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnCommand);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.ListBox lstCommand;
        private System.Windows.Forms.Timer timer1;

    }
}

