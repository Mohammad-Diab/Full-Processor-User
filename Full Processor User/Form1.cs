using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Full_Processor_User
{
    public partial class Form1 : Form
    {
        bool stop_thread;
        public Form1()
        {
            InitializeComponent();
            //Activated += (object sender, EventArgs e) => { Opacity = 0.5; };
            //Deactivate += (object sender, EventArgs e) => { Opacity = 1; };
        }

        private void Start_Click(object sender, EventArgs e)
        {
            stop_thread = false;
            int corescount = 1;
            foreach (var item in new ManagementObjectSearcher("Select NumberOfCores from Win32_Processor").Get())
                corescount += Convert.ToInt32(item["NumberOfCores"]);

            bool[] refrance = new bool[1000000];
            refrance[2] = false;

            for (int i = 2; i < 500000; i++)
                for (int j = i * 2; j < 1000000; j += i)
                    if (refrance[j])
                        break;
                    else
                        refrance[j] = true;

            for (int i = 0; i < corescount; i++)
            {
                Thread task = new Thread(() =>
                {
                    while (true)
                    {
                        for (long k = 2; k < 500000000000; k++)
                        {
                            if (stop_thread)
                                break;
                            for (long j = k * 2; j < 1000000000000; j += k)
                            {
                                if (stop_thread)
                                    break;
                                continue;
                            }
                        }
                        if (stop_thread)
                            break;
                    }
                });
                task.Priority = ThreadPriority.Highest;
                task.IsBackground = false;
                task.Start();
            }
            start_button.Enabled = false;
            start_button.Text = "Started";
            stop_button.Text = "Stop";
            stop_button.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stop_thread = true;
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop_thread = true;
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            stop_thread = true;
            start_button.Enabled = true;
            start_button.Text = "Start";
            stop_button.Text = "Stopped";
            stop_button.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Full Processor User App\nby: mohammad.diab93@outlook.com", "Full Processor User", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
