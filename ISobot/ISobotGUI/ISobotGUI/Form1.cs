using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ISobotGUI
{
    public partial class Form1 : Form
    {
        
        List<string> cmdLst = new List<string>()
        {
 "forward;898819",
 "backward;964611",
 "sideright;703491",
 "sideleft;637699",
 "fleft;1030403",
 "fright;571907",
 "bleft;834819",
 "bright;900611",
 "fclockwise;966403",
 "fcounter;1032195",
 "bclockwise;573699",
 "bcounter;639491",
 "headleft;907015",
 "headright;775948",
 "leanforward;841478",
 "leanback;1038081",
 "lpunch;922368",
 "r12;661248",
 "lchop;858368",
 "sidechopl;663040",
 "combopunch;597248",
 "rpunch;988160",
 "rchop;924160",
 "l12;792576",
 "sidechopr;728832",
 "lbackhand;529664",
 "doublechop;989952",
 "doublebackhand;925952",
 "slapping;860160",
 "rbackhand;595456",
 "upperchop;531456",
 "roundhousel;991744",
 "roundhouser;533248",
 "forwardkickl;599040",
 "forwardkickr;664832",
 "sidekickl;730624",
 "roundhouselr;666624",
 "forwardkicklr;732416",
 "combokick;798208",
 "sidekickr;796416",
 "backkickl;927744",
 "backkickr;993536",
 "highkickl;864000",
 "highkickr;995328",
 "splits1;536832",
 "guardl;602624",
 "guardr;668416",
 "doubleguard1;734208",
 "doubleguard2;800000",
 "dodgel;865792",
 "dodger;931584",
 "duck;604160",
 "swayback;669952",
 "upblock;735744",
 "splits2;801536",
 "comboblock;867328",
 "zero;1034752",
 "homeposition;775424",
 "soundoff;840451",
 "affirm;540416",
 "disagree;803328",
 "goodmorning;934912",
 "greet1;1000704",
 "greet2;608000",
 "greet3;739328",
 "greet4;805120",
 "bye1;870912",
 "bye2;936704",
 "bye3;1002496",
 "bye4;544000",
 "bye5;542208",
 "respect;869120",
 "thanks1;609792",
 "thanks2;675584",
 "love1;872704",
 "love2;938496",
 "love3;1004288",
 "standupfront;933120",
 "standupback;998912",
 "excited1;743168",
 "excited2;874496",
 "excited3;940288",
 "excited4;618752",
 "party;677376",
 "amazed;750336",
 "regret1;547584",
"regret2;744960",
"regret3;810752",
"worry;679168",
"pain1;1007872",
"pain2;615168",
"beg1;942080",
"beg2;880128",
"merry;552960",
"hilarious;1013504",
"hidenseek;613376",
"youlike;682752",
"mystery5;748544",
"tipsy;814336",
"tickleme;686080",
"tiredfeet;751872",
"needabreak;817664",
"wave1;883456",
"wave2;949248",
"applause;947712",
"mystery6;945920",
"toosexy;1015040",
"clink;556544",
"relax;753664",
"soccer1;885248",
"soccer2;600832",
"soccer3;535040",
"lift;819456",
"countonme;951040",
"articulation;1016832",
"showoff1;558336",
"showoff2;624128",
"showoff3;689920",
"showoff4;821248",
"cominthrough;887040",
"catch;1006080",
"pose1;771840",
"pose2;903168",
"pose3;968960",
"mystery1;684544",
"mystery2;816128",
"mystery3;881920",
"mystery4;549376",
"forwardsomersault;952832",
"headstandexercises;1018624",
"exercises;560128",
"airdrum;625920",
"airguitar;691712",
"randomperformance1;954624",
"randomanimal;627712",
"tropicaldance;825088",
"giantrobot;956416",
"western;1022208",
"randomperformance2;629504"


        };
        public Form1()
        {
            InitializeComponent();
            lstCommand.DataSource = cmdLst;
            
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
             
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
             
        }

        private void lstCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            string command = lstCommand.SelectedItem.ToString().Split(';')[1];
            SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.Write(command);
            txtCommand.Text = command;
            port.Close();
        }

        
    }
     

    
}

