using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;

namespace FormGaragem.Helpers
{
    public class Email
    {
        public string provedor { get; private set; }
        public int porta { get; private set; }
        public string remetente { get; private set; }
        public string password { get; private set; }

        public Email(string provedor, int porta, string remetente, string password)
        {
            this.provedor = provedor ?? throw new ArgumentNullException(nameof(provedor));
            this.porta = porta;
            this.remetente = remetente ?? throw new ArgumentNullException(nameof(remetente));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public bool validadeEmail(string email)
        {
            Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-aZ-Z]{2,3}");
            if (expression.IsMatch(email)) return true;

            return false;
        }

        public void sendEmailBySmtp(string destinatario, string subject, string body)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(remetente);
            if (validadeEmail(destinatario)) mail.To.Add(destinatario);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient(provedor, porta);
            smtpClient.Host = provedor;
            smtpClient.Port = porta; // 587
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 50000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(remetente, password);

            try
            {
                smtpClient.Send(this.remetente, destinatario, subject, body);
            } catch (Exception err) 
            {
                MessageBox.Show(err.Message);
            } finally {
                smtpClient.Dispose();
            }
        }
    }
}
