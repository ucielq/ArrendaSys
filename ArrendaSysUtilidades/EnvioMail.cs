using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysUtilidades
{
    public class EnvioMail
    {

        public string EnviarMailGenerico(string destino,string body,string subject)
        {

            var smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("arrendasys@gmail.com","oaejywljtzkqswgf");
            var MailMessage = new MailMessage();
            MailMessage.From = new MailAddress("arrendasys@gmail.com");
            MailMessage.To.Add(new MailAddress(destino));
            MailMessage.IsBodyHtml = true;
            MailMessage.Subject = subject;
            MailMessage.Body = body;
            smtp.Send(MailMessage);
            return "OK";
        }
    }
}
