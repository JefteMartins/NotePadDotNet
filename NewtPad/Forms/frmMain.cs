using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Globalization.CultureInfo;
namespace NewtPad.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos de texto|*.txt|Texto Personalizado|*.tpe";
            saveFileDialog.Title = "Salvar meu arquivo";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, txbNotepad.Text);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos de texto|*.txt|Texto Personalizado|*.tpe";
            ofd.Multiselect = true;
            ofd.ShowDialog();

            txbNotepad.Text = File.ReadAllText(ofd.FileName);


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Arquivos de texto|*.txt|Texto Personalizado|*.tpe";
            ofd.Multiselect = true;
            ofd.ShowDialog();

            txbNotepad.Text = File.ReadAllText(ofd.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos de texto|*.txt|Texto Personalizado|*.tpe";
            saveFileDialog.Title = "Salvar meu arquivo";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, txbNotepad.Text);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void captalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string content = txbNotepad.Text;
            for (int i = 0; i < content.Length; i++)
             {
                if (i == 0 && content[0].ToString().All(char.IsLower))
                {
                    content = content[0].ToString().ToUpper() + content.Substring(1);
                }
                if (i != 0 && content[i - 1] == '\n' && content[i].ToString().All(char.IsLower))
                {
                    content = content.Substring(0, i) + content[i].ToString().ToUpper() + content.Substring(i, content.Length - i);
                }
                if (i != 0 && content[i - 1] != '\n' && content[i].ToString().All(char.IsLower))
                {
                    String teste = content.Substring(0, i);
                    String teste2 = content[i].ToString().ToLower();
                    String teste3 = content.Substring(i + 1);
                    content = content.Substring(0, i) + content[i].ToString().ToLower() + content.Substring(i+1);
                }
            }
            txbNotepad.Text = content;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txbNotepad.Text = txbNotepad.Text.ToLower();

        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txbNotepad.Text = txbNotepad.Text.ToUpper();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formAbout formAbout = new formAbout();
            formAbout.ShowDialog();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMail frmMail = new frmMail();
            frmMail.ShowDialog();
        }
    }
}
