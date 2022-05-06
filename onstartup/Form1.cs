using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();
            this.Hide();
            string [] str = File.ReadAllLines("ztcfg.txt");
            thread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Thread.Sleep(Convert.ToInt32(str[1]));
                    Process[] ps = Process.GetProcessesByName(str[0].Split('.')[0]);
                    if (ps.Length > 0)
                    {
                        continue;
                    }
                    else
                    {
                        Process.Start(str[0]);
                    }
                }
            }));
            thread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
