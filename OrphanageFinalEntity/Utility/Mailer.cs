using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace OrphanageFinalEntity.Utility
{
    public class Mailer
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Mailer()
        {

        }
        public Mailer(string to, string subject, string content)
        {
            this.To = to;
            this.Subject = subject;
            this.Body = content;

        }
        public void Send()
        {
            MailMessage message = new MailMessage();
            message.To.Add(To);
            message.Body = Body;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Send(message);
        }
    }
}