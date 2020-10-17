using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LAB03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void FileSave() {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текст файлууд | *.txt";
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileName = sfd.FileName;
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (string line in richContent.Lines)
                {
                    sw.WriteLine(line);
                }
                this.Text = fileName;
                MessageBox.Show("\"" + fileName + "\"" + " замд файлыг амжилттай хадгаллаа!");
                sw.Close();
            }
        }

        public void FileOpen() {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текст файлууд | *.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;
                if (File.Exists(filename))
                {
                    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    String allText = "";
                    String lineText = "";
                    while (lineText != null)
                    {
                        lineText = sr.ReadLine();
                        if (allText == "") allText += lineText;
                        else allText += "\n" + lineText;

                    }
                    this.Text = filename;
                    richContent.Text = allText;
                }
                else
                {
                    MessageBox.Show(filename + " файл байхгүй байна.");
                }
            }
        }

        public void clear()
        {
            richContent.Clear();
            this.Text = "Untitled";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileSave();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSave();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
