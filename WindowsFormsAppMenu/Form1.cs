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

namespace WindowsFormsAppMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void readFile()
        {
            ofd.Filter = "Text Files|*.txt";
            if(ofd.ShowDialog()!=DialogResult.Cancel)
            {
                StreamReader sr=File.OpenText(ofd.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                if(MessageBox.Show("Do you want to save this file?","Warning",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    textBox1.Clear();
                }

            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Text Files|*.txt";
            if (sfd.ShowDialog() != DialogResult.Cancel)
            {
                StreamWriter sw =File.CreateText(sfd.FileName);
                sw.Write(textBox1.Text);
                sw.Close();

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Text Files|*.txt";
            if(textBox1.Text!="")
            {
                if(MessageBox.Show("Do you want to save this file?","Warning"
                    ,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender , e);
                    readFile();
                }
              
            }
            else
            {
                readFile();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boldToolStripMenuItem.Checked = !boldToolStripMenuItem.Checked;
            textBox1.Font=new Font(textBox1.Font.Name,textBox1.Font.Size,
                textBox1.Font.Style ^ FontStyle.Bold);

        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
           italicToolStripMenuItem.Checked = !italicToolStripMenuItem.Checked;
            textBox1.Font = new Font(textBox1.Font.Name, textBox1.Font.Size,
                textBox1.Font.Style ^ FontStyle.Italic);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font=fontDialog1.Font;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(wordWrapToolStripMenuItem.Checked)
            {
                textBox1.WordWrap = true;//important! set checkOnClick property on true
                
            }
            else
            {
                textBox1.WordWrap = false;
                textBox1.ScrollBars= ScrollBars.Both;
            }
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font=fontDialog1.Font;
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.BackColor = colorDialog1.Color;
        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.ForeColor = colorDialog1.Color;
        }
    }
}
