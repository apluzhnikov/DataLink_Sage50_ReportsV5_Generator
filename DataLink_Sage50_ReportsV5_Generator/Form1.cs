using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLink_Sage50_ReportsV5_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)            
                textBox1.Text = openFileDialog1.FileName;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)            
                textBox2.Text = folderBrowserDialog1.SelectedPath;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                var outputFile = $@"C:\Users\Public\Documents\{textBox3.Text}.pdf";
                if (ReportCreator.Generate(textBox1.Text, textBox2.Text, outputFile, comboBox1.SelectedItem.ToString(), textBox4.Text, textBox5.Text))
                    Process.Start(new ProcessStartInfo
                    {
                        Arguments = Path.GetFullPath(outputFile),
                        FileName = "explorer.exe"
                    });
                else
                    MessageBox.Show("Report was not generated");
            }
            else
                MessageBox.Show("Please fill all the text boxes");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
