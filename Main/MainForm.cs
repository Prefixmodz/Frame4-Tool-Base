using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libframe4;
using CBH_WinForm_Theme_Library_NET;

namespace Frame4_ToolBase
{
    public partial class MainForm : CrEaTiiOn_Form
    {
        public static FRAME4 frame4;
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Labelstatus.Text = "Idle";

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                frame4 = new FRAME4(BoxIP.Text);
                frame4.Connect();
                frame4.Notify(222, "Connected!");
                LabelFrame4Vers.Text = frame4.GetConsoleDebugVersion();
                groupboxNotify.Enabled = true;
               

                Labelstatus.Text = "Connected At: " + BoxIP.Text;
                Labelstatus.ForeColor = Color.Green;
                

            }
            catch
            {
                MessageBox.Show("Could not reach console!");
            }
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (frame4.IsConnected)
            {
                frame4.Notify(222, "Disconnected!");
                frame4.Disconnect();
                Labelstatus.Text = "Disconnected  From: " + BoxIP.Text;
                Labelstatus.ForeColor = Color.Red;
                groupboxNotify.Enabled = false;
            }
            else
            {
                MessageBox.Show("Console is not Connected!");
            }
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            if (frame4.IsConnected)
            {

                frame4.Reboot();
                Labelstatus.Text = "Console Rebooting...";
                Labelstatus.ForeColor = Color.Red;
            }
            else
            {
                MessageBox.Show("Console is not Connected!");
            }
        }

        private void btnSendNotify_Click(object sender, EventArgs e)
        {
            if (frame4.IsConnected)
            {
                frame4.Notify(222, BoxNotify.Text);
            }
            else
            {
                MessageBox.Show("Console is not Connected!");
            }
        }
    }
}