using System;
using System.Collections.Generic;
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
            string respuesta = "Enviar";

            string emailRemitente = "arrendasys@gmail.com";
            string passwordRemitente = "arrendasys2021";

            //Configuring SMTP
            SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.Port = 587;
            client.Timeout = (60 * 5 * 1000);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            //Setting credentials
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(emailRemitente, passwordRemitente);

            MailAddress from2 = new MailAddress(emailRemitente, String.Empty, System.Text.Encoding.UTF8);
            MailMessage message = new MailMessage();
            message.To.Add(destino);
            message.From = from2;
            message.Body = body;
            message.IsBodyHtml = true;

            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            string userstate = "sending ...";
            client.Send(message);
            return respuesta;
        }
    }
}
