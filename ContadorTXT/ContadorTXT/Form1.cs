using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContadorTXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
                folderBrowserDialog1.SelectedPath = textBox1.Text;
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (Directory.Exists(textBox1.Text))
            {
                
                int archivos = 0;
                foreach(string archivo in   Directory.GetFiles(textBox1.Text,"*.txt",SearchOption.AllDirectories))
                    {
                    archivos = archivos + 1;
                    label1.Text = archivo;
                    StreamReader sr =  File.OpenText(archivo);
                    if (!sr.EndOfStream) {
                        string linea = sr.ReadLine();
                        var miArray = linea.Split(',');
                        if(miArray.Length == 1)
                            miArray = linea.Split('_');
                                                
                        }
                    }
                    label3.Text = archivos.ToString();
                    
                }


                button1.Enabled = true;

            }
        }
    }
}
