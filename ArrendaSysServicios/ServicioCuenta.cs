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

namespace ArrendaSysServicios
{
    public class ServicioCuenta : IDisposable
    {
        private ArrendasysEntities db = new ArrendasysEntities();

        public CuentaViewModel hola()
        {
            CuentaViewModel cuenta = new CuentaViewModel();
            var c = db.Cuenta.FirstOrDefault();            
            cuenta.email = c.emailCuenta;
            return cuenta;
        }
        public string ObtenerLoginUsuario(string mailUsuario, string pass)
        {
            {
                var usuario = (from c in db.Cuenta

                                where c.emailCuenta == mailUsuario && c.contrasenaCuenta == pass
                                select new CuentaViewModel
                                {
                                    idCuenta = c.idCuenta,
                                    //esGuardia = c.esJefeGuardia
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
                    return "Index#Home";
                }


                //Aca manejar el rol

                //var rolUsuario = bc.GralUsuarioRol.Where(x => x.idUsuario == usuario.idUsuario && x.activo == true).FirstOrDefault();
                //if (rolUsuario == null)
                //{
                //    return "PermisoDenegado#Login";
                //}
                //var rol = bc.GralRol.Where(x => x.idRol == rolUsuario.idRol).FirstOrDefault();

                //if (rolUsuario != null)
                //{
                //    if (rol != null)
                //    {
                //        if (rol.esJefe == true)
                //        {
                //            return "Novedad#Novedad";
                //        }
                //        if (rol.esOperador == true)
                //        {
                //            return "Novedad#Novedad";
                //        }
                //        var acceso = bc.GralAccesoRol.Where(x => x.idRol == rol.idRol).FirstOrDefault();
                //        var menuInicio = bc.GralMenu.Where(x => x.idMenu == acceso.idMenu).FirstOrDefault().url;
                //        var response = menuInicio.Split('/')[1] + "#" + menuInicio.Split('/')[2];
                //        return response;
                //    }
                //    else
                //    {
                //        return "PermisoDenegado#Login";
                //    }

                //}
                //else
                //{
                //    return "PermisoDenegado#Login";
                //}
            }
            
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}