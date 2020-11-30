using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedController
{
    public partial class Form1 : Form
    {
        private Led led;
        public Form1()
        {
            led = new Led();
            SystemEvents.SessionEnded += new SessionEndedEventHandler(SystemEvents_SessionEnded);

            InitializeComponent();

            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void SystemEvents_SessionEnded(object sender, EventArgs e)
        {
            //led.fillSolid(Color.Blue);
            led.turnOff();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            led.fillSolid(Color.Red);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            led.turnOff();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Console.WriteLine(colorDialog1.Color);
                led.fillSolid(colorDialog1.Color);
            }
        }
    }
}
