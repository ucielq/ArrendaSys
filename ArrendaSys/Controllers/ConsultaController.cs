using ArrendaSysUtilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public string enviarMail(string name, string email, string subject, string message)
        {
            EnvioMail envioMail = new EnvioMail();
            message = "Autor: " + email + "<br>" + message;
            var response = envioMail.EnviarMailGenerico("arrendasys@gmail.com", message,name+" "+ subject);
            return "OK";
        }
    }
}