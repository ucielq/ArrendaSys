﻿using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArrendaSysServicios;
using ArrendaSysModelos;

namespace ArrendaSys.Controllers.Api
{
    public class CuentaApiController : ApiController
    {
        [System.Web.Http.Route("Api/Cuenta/ValidarMail")]
        [System.Web.Http.ActionName("ValidarMail")]
        [System.Web.Http.HttpGet]
        public int ValidarMail(string email)
        {
            using(ArrendaSysModelos.ArrendasysEntities db = new ArrendaSysModelos.ArrendasysEntities())
            {
                var existe = db.Cuenta.Where(x => x.emailCuenta == email).FirstOrDefault();
                if (existe != null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
        [System.Web.Http.Route("Api/Cuenta/getTipo")]
        [System.Web.Http.ActionName("getTipo")]
        [System.Web.Http.HttpGet]
        public int getTipo(int idRol)
        {
            using (ArrendaSysModelos.ArrendasysEntities db = new ArrendaSysModelos.ArrendasysEntities())
            {
                var rol = db.Rol.Where(x => x.idRol == idRol).FirstOrDefault();
                return rol == null ? 0 : (int)rol.tipoRol;
            }
        }   

        [System.Web.Http.Route("Api/Cuenta/eliminarCuenta")]
        [System.Web.Http.ActionName("eliminarCuenta")]
        [System.Web.Http.HttpPost]
        public void eliminarCuenta(int idCuenta)
        {
            using (ArrendasysEntities entities = new ArrendasysEntities())
            {
                var cuenta = entities.Cuenta.Where(x => x.idCuenta == idCuenta).FirstOrDefault();
                cuenta.fechaBajaCuenta=DateTime.Now;
                entities.SaveChanges();
            }
        }

        [System.Web.Http.Route("Api/Cuenta/obtenerCodigoCuenta")]
        [System.Web.Http.ActionName("obtenerCodigoCuenta")]
        [System.Web.Http.HttpGet]
        public int obtenerCodigoCuenta(int idCuenta)
        {
            using (ArrendasysEntities entities = new ArrendasysEntities())
            {
                var cuenta = entities.Cuenta.Where(x => x.idCuenta == idCuenta).FirstOrDefault();
                return (int)cuenta.codigoConfimacion;
            }
        }
        [System.Web.Http.Route("Api/Cuenta/GuardarImagenCuenta")]
        [System.Web.Http.ActionName("GuardarImagenCuenta")]
        [System.Web.Http.HttpPost]
        public int GuardarImagenCuenta()
        {
            ArchivoApiController api = new ArchivoApiController();
            ServicioCuenta serv2 = new ServicioCuenta();
            var listaArchivos = api.Subir("Inmueble");
            if (listaArchivos.Count > 0)
            {
                if (listaArchivos[0].error != 400)
                {
                    return serv2.GuardarImagenCuenta(listaArchivos);
                }
                else return 500;
            }
            else
            {
                return 500;
            }
        }

        [System.Web.Http.Route("Api/Cuenta/generarCodigoValidacion")]
        [System.Web.Http.ActionName("generarCodigoValidacion")]
        [System.Web.Http.HttpGet]
        public int generarCodigoValidacion(string email)
        {
            DateTime now = DateTime.Now;

            var hashCode = Math.Abs((email+now.ToString()).GetHashCode());
            ArrendaSysUtilidades.EnvioMail envioMail = new ArrendaSysUtilidades.EnvioMail();
            var hola = envioMail.EnviarMailGenerico(email,"Código de recuperación de contraseña: "+ hashCode, "Recuperación Contraseña");
            return hashCode;
        }
        [System.Web.Http.Route("Api/Cuenta/ActualizarContrasenia")]
        [System.Web.Http.ActionName("ActualizarContrasenia")]
        [System.Web.Http.HttpGet]
        public int ActualizarContrasenia(string email,string pass)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                try
                {
                    var cuenta = db.Cuenta.Where(x => x.emailCuenta == email).FirstOrDefault();
                    var nuevaContrasenia = Encrypt.GetSHA256(pass);
                    cuenta.contrasenaCuenta = nuevaContrasenia;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }           
        }

        [System.Web.Http.Route("Api/Cuenta/altaCuenta")]
        [System.Web.Http.ActionName("altaCuenta")]
        [System.Web.Http.HttpGet]
        public int altaCuenta(string email, string password)
        {
            ServicioCuenta servicioCuenta = new ArrendaSysServicios.ServicioCuenta();
            return servicioCuenta.altaCuenta(email, password);
        }

        [System.Web.Http.Route("Api/Cuenta/ObtenerId")]
        [System.Web.Http.ActionName("ObtenerId")]
        [System.Web.Http.HttpGet]
        public int ObtenerId(string email)
        {
            ServicioCuenta servicioCuenta = new ArrendaSysServicios.ServicioCuenta();
            return servicioCuenta.ObtenerUsuarioLogueado(email);
        }
        [System.Web.Http.Route("Api/Cuenta/ObtenerDatosCuenta")]
        [System.Web.Http.ActionName("ObtenerDatosCuenta")]
        [System.Web.Http.HttpGet]
        public CuentaViewModel ObtenerDatosCuenta(int idCuenta)
        {
            ServicioCuenta servicio = new ServicioCuenta();
            CuentaViewModel cuenta = servicio.ObtenerDatosCuenta(idCuenta);
            return cuenta;
        }

        [System.Web.Http.Route("Api/Cuenta/ValidarContraseniaActual")]
        [System.Web.Http.ActionName("ValidarContraseniaActual")]
        [System.Web.Http.HttpGet]
        public int ValidarContraseniaActual(int idCuenta, string password)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var user = db.Cuenta.Where(x => x.idCuenta == idCuenta && x.fechaBajaCuenta == null).FirstOrDefault();
                var ePass = Encrypt.GetSHA256(password);
                var resultado = 0;
                    if (user.contrasenaCuenta == ePass)
                    {

                        resultado = 1;

                    }
                return resultado;
            }
        }
        [System.Web.Http.Route("Api/Cuenta/cambiarContrasenia")]
        [System.Web.Http.ActionName("cambiarContrasenia")]
        [System.Web.Http.HttpGet]
        public int cambiarContrasenia(int idCuenta, string password)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                try
                {
                    var cuenta = db.Cuenta.Where(x => x.idCuenta == idCuenta).FirstOrDefault();
                    var nuevaContrasenia = Encrypt.GetSHA256(password);
                    cuenta.contrasenaCuenta = nuevaContrasenia;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}