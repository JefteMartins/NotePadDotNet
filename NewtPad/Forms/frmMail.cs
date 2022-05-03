using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace NewtPad.Forms
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }

        private void frmMail_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MailMessage mailm = new MailMessage(textBox2.Text, "jefte@softium.com.br"); 
            mailm.Subject = txbMailName.Text;
            mailm.Body = "Email de: " + txbMailName.Text + "\n" +  textBox3.Text;
            mailm.ReplyTo = new MailAddress(textBox2.Text,txbMailName.Text);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential("jefte@softium.com.br", "J3ft3@456");
            smtp.Credentials = nc;
            smtp.EnableSsl = true;
            smtp.Send(mailm);
            DialogResult result = MessageBox.Show("Email enviado com sucesso para: "+ textBox2.Text, "Mensagem Enviada!",MessageBoxButtons.CancelTryContinue, MessageBoxIcon.Question);
            switch (result) {
                case DialogResult.Cancel:
                    Close();
                    break;
                case DialogResult.Continue:
                    Close();
                    break;
                case DialogResult.TryAgain:
                    smtp.Send(mailm);
                    MessageBox.Show("Email enviado com sucesso para: " + textBox2.Text, "Mensagem Enviada!", MessageBoxButtons.CancelTryContinue, MessageBoxIcon.Question);
                    break;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
