using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGaragem.View.modules.forget_password
{
    public partial class FormForgetPassword : Form
    {
        string remetente = "mocadaautomoveis@gmail.com";
        string senha = "etecjau070";

        public FormForgetPassword()
        {
            InitializeComponent();
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            FormLogin frmLogin = new FormLogin();
            this.Close();
            frmLogin.Show();
        }

        private void btn_recuperar_senha_Click(object sender, EventArgs e)
        {
            // DEDO NERVOSO :)
            btn_recuperar_senha.Enabled = false;

            string destinatario = txt_email.Text;
            string assunto = "Recuperação de Senha | Moçada Automóveis";
            string msg = $"Olá {txt_user.Text}, essa é a sua nova senha [123456]. Guarde bem ela!";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remetente);
            mail.To.Add(destinatario);
            mail.Subject = assunto;
            mail.Body = msg;

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(remetente, senha);

                try
                {
                    smtp.Send(mail);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
