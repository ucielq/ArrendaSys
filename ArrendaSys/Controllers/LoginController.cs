﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArrendaSys.Controllers.Acceso;
using ArrendaSysServicios;

namespace ArrendaSys.Controllers
{
    //[SessionUtility]
    //[Permiso("HOME")]
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult RecuperarContrasenia()
        {
            return View();
        }
        public ActionResult ModuloDenegado()
        {
            return View();
        }
        public ActionResult Validar(string mail, string password)
        {
            try
            {
                ServicioCuenta servicio = new ServicioCuenta();
                if (string.IsNullOrEmpty(mail))
                {
                    return RedirectToAction("LoginManual", "Login");
                }
                if (string.IsNullOrEmpty(password))
                {
                    return RedirectToAction("LoginManual", "Login");
                }
                var resp = servicio.ObtenerLoginUsuario(mail, password);
                if (resp != "DatosIncorrectos#Login")
                {
                    var user = servicio.ObtenerDatosUsuarioLogueado(mail);
                    var usuario = servicio.ObtenerDatosCuenta(user.idCuenta);
                    System.Web.HttpContext.Current.Session["usuarioLogeado"] = mail;
                    System.Web.HttpContext.Current.Session["tipoCuenta"] = usuario.tipoCuenta;
                    System.Web.HttpContext.Current.Session["idCuenta"] = user.idCuenta;
                    System.Web.HttpContext.Current.Session["id"] = usuario.idPropio;
                    System.Web.HttpContext.Current.Session["foto"] = usuario.rutaFoto;
                    System.Web.HttpContext.Current.Session["premium"] = usuario.premium;
                    if (usuario.nombreRol != null)
                    {
                        System.Web.HttpContext.Current.Session["rol"] = usuario.nombreRol;
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["rol"] = "Sin Rol";
                    }
                    if (resp.Split('*')[0]== "Perfil#AdministrarPerfil")
                    {
                        return RedirectToAction("AdministrarPerfil", "Perfil", new { id = resp.Split('*')[1] });
                    }
                }
                return RedirectToAction(resp.Split('#')[1], resp.Split('#')[0]);

            }
            catch (UnauthorizedAccessException e)
            {
                ViewBag.User = e.Message;
            }
            return RedirectToAction("LoginManual", "Login");
        }
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Landing");
        }
    }
}