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

namespace BinSoub1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool konec = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    while (br.BaseStream.Position < br.BaseStream.Length && konec == false)
                    {
                        if (br.ReadChar() == '?')
                        {
                            MessageBox.Show("? je na pozici: " + br.BaseStream.Position.ToString());
                            br.BaseStream.Position = br.BaseStream.Position - 2;
                            MessageBox.Show("Předchozí znak je: " + br.ReadChar().ToString());
                            konec = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
