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
            var apiKey = ConfigurationManager.AppSettings["apiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("arrendasys@gmail.com", "Arrendasys");
            var subject2 = subject;
            var to = new EmailAddress(destino, destino);
            var plainTextContent = body;
            var htmlContent = body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject2, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            return "OK";
        }
    }
}
