using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetMACFromCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtOutput_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ofdFile.ShowDialog();
        }

        private void ofdFile_FileOk(object sender, CancelEventArgs e)
        {
            if (!ofdFile.CheckFileExists)
            {
                MessageBox.Show("Filen eksisterer ikke");
            }
            else
            {
                foreach (string line in File.ReadAllLines(ofdFile.FileName))
                {
                    string[] parts = line.Split(',');
                    Regex validMac = new Regex("^[a-fA-F0-9]{12}$");
                    string MAC = parts[4];

                    if (validMac.IsMatch(MAC))
                        txtOutput.AppendText(ConvertStringToMAC(MAC) + Environment.NewLine);
                }
            }
        }

        private string ConvertStringToMAC(string text)
        {
            return String.Format("{0}:{1}:{2}:{3}:{4}:{5}", text.Substring(0, 2), text.Substring(2, 2), text.Substring(4, 2), text.Substring(6, 2), text.Substring(8, 2), text.Substring(10,2));
        }
    }
}
