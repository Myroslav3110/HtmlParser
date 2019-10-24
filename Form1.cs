using Parser.Core;
using Parser.Core.Habra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parser
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new HabraParser());
            parser.OnComleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            parser.Settings = new HabraSettings((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            parser.Start();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Text = string.Empty;
            parser.Abort();
        }
    }
}
