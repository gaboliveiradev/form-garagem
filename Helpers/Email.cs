using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FormGaragem.Helpers
{
    public class Email
    {
        public string provedor { get; private set; }
        public string remetente { get; private set; }
        public string password { get; private set; }

        public Email(string provedor, string remetente, string password)
        {
            this.provedor = provedor ?? throw new ArgumentNullException(nameof(provedor));
            this.remetente = remetente ?? throw new ArgumentNullException(nameof(remetente));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public void sendEmail(string emailTo, string subject, string body)
        {

        }

        private MailMessage prepareteMessage(string emailTo, string subject, string body)
        {
            var mail = new MailMessage();

            mail.From = new MailAddress(remetente);
        }
    }
}
