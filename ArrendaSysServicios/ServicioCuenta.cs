﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Configuration;
using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using ArrendaSysUtilidades;

namespace ArrendaSysServicios
{
    public class ServicioCuenta : IDisposable
    {
        private ArrendasysEntities db = new ArrendasysEntities();

        public int altaCuenta(string email, string pass)
        {
            var codigo = Math.Abs(email.GetHashCode());
            var ePass = Encrypt.GetSHA256(pass);
            Cuenta cuenta = new Cuenta
            {
                emailCuenta=email,
                contrasenaCuenta=ePass,
                codigoConfimacion=codigo
            };
            db.Cuenta.Add(cuenta);
            db.SaveChanges();            
            enviarMailCodigo(email, codigo);
            return codigo;
        }

        public CuentaViewModel ObtenerDatosUsuarioLogueado(string emailCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                //var user = nombreUsuario.Remove(0, 10);
                CuentaViewModel usuario = new CuentaViewModel();
                if (emailCuenta != null)
                {
                    usuario = (from c in db.Cuenta
                               where c.fechaAltaCuenta != null && c.fechaBajaCuenta==null && c.emailCuenta == emailCuenta
                               select new CuentaViewModel
                               {
                                   idCuenta = c.idCuenta,
                                   email = c.emailCuenta,
                               }).FirstOrDefault();
                    //aca debo controlar lo que se hace si no encuentro usuario en la base
                    if (usuario == null)
                    {
                        usuario = new CuentaViewModel();
                        usuario.email = "Sin nombre";
                        usuario.idCuenta = 0;

                    }

                }
                return usuario;
            }
        }

        public int confirmaCuenta(string email)
        {
            var cuenta = db.Cuenta.Where(x => x.emailCuenta == email).FirstOrDefault();
            if (cuenta != null)
            {
                cuenta.fechaAltaCuenta = DateTime.Now;
            }
            db.SaveChanges();
            return cuenta.idCuenta;
        }
        public void enviarMailCodigo(string email, int codigo)
        {
            EnvioMail mail = new EnvioMail();
            var destino = email;
            var body = codigo.ToString();
            var subject = "Código confirmación";
            mail.EnviarMailGenerico(destino, body, subject);
        }

        public static int Get(string emailCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var usuario = (from c in db.Cuenta

                               where c.emailCuenta == emailCuenta
                               select new CuentaViewModel
                               {
                                   idCuenta = c.idCuenta,
                               }).FirstOrDefault() ?? new CuentaViewModel()
                               {
                                   idCuenta = 0,
                               };
                if (usuario.idCuenta==0)
                {
                    usuario.idCuenta = -1;
                }

                return usuario.idCuenta;
            }

        }

        public static bool TienePermisoPorLogin(int? access, string nombreUsuario)
        {

            var usuario = Get(nombreUsuario);

            if (usuario > 0)
            {
                return HasAccess(usuario, access);
            }

            return false;
        }

        public static RolViewModel ObtenerTiposPermisos(int? access, string emailCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var idCuenta = Get(emailCuenta);
                var rolPerm = (from t1 in db.Cuenta
                               join t2 in db.PermisoRol
                                   on t1.idRol equals t2.idRol
                               join t3 in db.URL
                                   on t2.idURL equals t3.idURL
                               where t1.idCuenta == idCuenta && t2.idURL == access
                               select new RolViewModel
                               {
                                   tienePermisoEdicion = t2.edicionRol,
                                   tienePermisoEliminacion = t2.eliminacionRol,
                                   tienePermisoLectura = t2.lecturaRol

                               }).FirstOrDefault();


                return rolPerm;

            }
        }

        private static bool HasAccess(int idCuenta, int? acceso)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var list = (from t1 in db.Cuenta
                            join t2 in db.PermisoRol
                                on t1.idRol equals t2.idRol
                            join t3 in db.URL
                                on t2.idURL equals t3.idURL
                            select new { t1, t3 }).Where(x => x.t1.idCuenta == idCuenta).ToList();


                if (list.Any(item => item.t3.idURL == acceso))
                {
                    return true;
                }
                return false;
            }
        }

        public int ObtenerUsuarioLogueado(string emailCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var usuario = (from c in db.Cuenta

                               where c.emailCuenta == emailCuenta
                               select new CuentaViewModel
                               {
                                   idCuenta = c.idCuenta,
                                   fechaAltaCuenta=c.fechaAltaCuenta,
                                   fechaBajaCuenta=c.fechaBajaCuenta
                               }).FirstOrDefault() ?? new CuentaViewModel()
                               {
                                   idCuenta = 0,
                               };
                if (usuario.fechaAltaCuenta==null || usuario.fechaBajaCuenta!=null)
                {
                    usuario.idCuenta = -1;
                }
                //devuelvo 0 si el usuario no existe en la bd ó -1 si existe pero no está activo

                return usuario.idCuenta;
            }
        }

        public string ObtenerLoginUsuario(string mailUsuario, string pass)
        {
            {
                var ePass = Encrypt.GetSHA256(pass);
                var usuario = (from c in db.Cuenta

                                where c.emailCuenta == mailUsuario && c.contrasenaCuenta == ePass
                                select new CuentaViewModel
                                {
                                    idCuenta = c.idCuenta,
                                    idRol=c.idRol
                                }).FirstOrDefault() ?? new CuentaViewModel()
                                {
                                    idCuenta = 0,
                                };
                if (usuario.idCuenta == 0)
                {
                    return "DatosIncorrectos#Login";
                }
                else
                {
                    //Aca se maneja el rol

                    var rol = db.Rol.Where(x => x.idRol == usuario.idRol && x.fechaBajaRol == null).FirstOrDefault();
                    if (rol == null)
                    {
                        return "Perfil#AdministrarPerfil*"+usuario.idCuenta;
                    }
                    else {
                            
                        var acceso = db.PermisoRol.Where(x => x.idRol == rol.idRol).FirstOrDefault();
                        var menuInicio = db.URL.Where(x => x.idURL == acceso.idURL).FirstOrDefault().linkURL;
                        var response = "Home#Index";
                        return response;
                    }
                        
                }
            }
        }
        public CuentaViewModel ObtenerDatosCuenta(int idCuenta)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var cuenta = new CuentaViewModel();
                var cuent = db.Cuenta.Where(x => x.idCuenta == idCuenta && x.fechaBajaCuenta == null).FirstOrDefault();
                if (cuent != null)
                {
                    cuenta.email = cuent.emailCuenta;
                    var arrendatario = db.Arrendatario.Where(x => x.idCuenta == cuent.idCuenta).FirstOrDefault();
                    var propietario = db.Propietario.Where(x => x.idCuenta == cuent.idCuenta).FirstOrDefault();
                    var inmobiliaria = db.Inmobiliaria.Where(x => x.idCuenta == cuent.idCuenta).FirstOrDefault();                    
                    if (arrendatario != null)
                    {
                        //Es arrendatario
                        var arrendatarioVM = new ArrendatarioViewModel();
                        cuenta.tipoCuenta = 3;
                        arrendatarioVM.nroDocumento = (int)arrendatario.numeroDocumentoArr;
                        arrendatarioVM.nombreArrendatario = arrendatario.nombreArrendatario;
                        arrendatarioVM.apellidoArrendatario = arrendatario.apellidoArrendatario;
                        arrendatarioVM.nroTelefono = (int)arrendatario.telefonoArrendatario;
                        arrendatarioVM.fechaNacimientoStr = String.Format("{0:yyyy-MM-dd}", arrendatario.fechaNacimArrendatario);
                        arrendatarioVM.fechaNacimiento = (DateTime)arrendatario.fechaNacimArrendatario;
                        cuenta.arrendatario = arrendatarioVM;
                        return cuenta;
                    }
                    else
                    {
                        if (propietario != null)
                        {
                            //Es propietario
                            var propVM = new PropietarioViewModel
                            {
                                apellidoPropietario = propietario.apellidoPropietario,
                                nombrePropietario = propietario.nombrePropietario,
                                numeroDocumentoPropietario = (int)propietario.numeroDocumentoProp,
                                telefonoPropietario = propietario.telefonoPropietario,
                                fechaNacimientoStr = String.Format("{0:yyyy-MM-dd}", propietario.fechaNacimPropietario)

                            };
                            cuenta.propietario = propVM;
                            cuenta.tipoCuenta = 2;
                            return cuenta;
                        }
                        else
                        {
                            if (inmobiliaria != null)
                            {
                                //Es inmobiliaria
                                cuenta.tipoCuenta = 1;
                                return cuenta;
                            }
                            else
                            {
                                //Todavia no es nada
                                cuenta.tipoCuenta = -1;
                                return cuenta;
                            }
                        }
                    }
                }
                else
                {
                    //No existe la cuenta
                    return new CuentaViewModel {
                        idCuenta = 0
                    };
                }
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
