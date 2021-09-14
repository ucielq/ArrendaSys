﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;

namespace ArrendaSysServicios
{
    public class ServicioInmobiliaria :IDisposable
    {
        public int crearInmobiliaria(InmobiliariaViewModel inmobiliaria)
        {

            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var cuenta = db.Cuenta.Where(x => x.idCuenta == inmobiliaria.idCuenta).FirstOrDefault();
                var arrenda = db.Arrendatario.Where(x => x.idCuenta == cuenta.idCuenta).FirstOrDefault();
                if (arrenda != null)
                {
                    db.Arrendatario.Remove(arrenda);
                }
                var prop = db.Propietario.Where(x => x.idCuenta == cuenta.idCuenta).FirstOrDefault();
                if (prop != null)
                {
                    db.Propietario.Remove(prop);
                }
                cuenta.idRol = 4;
                var inmobiliaria2 = db.Inmobiliaria.Where(x => x.idCuenta == inmobiliaria.idCuenta).FirstOrDefault();
                if (inmobiliaria2 != null)
                {
                    inmobiliaria2.nombreInmobiliaria = inmobiliaria.nombreInmobiliaria;
                    inmobiliaria2.altaInscripcion = inmobiliaria.altaInscripcion;
                    inmobiliaria2.cuitInmobiliaria = inmobiliaria.cuitInmobiliaria;
                    inmobiliaria2.telefonoInmobiliaria = inmobiliaria.telefonoInmobiliaria.ToString();
                    inmobiliaria2.idCuenta = inmobiliaria.idCuenta;

                }
                else
                {
                    Inmobiliaria inmo = new Inmobiliaria
                    {
                        nombreInmobiliaria = inmobiliaria.nombreInmobiliaria,
                        altaInscripcion = inmobiliaria.altaInscripcion,
                        cuitInmobiliaria = inmobiliaria.cuitInmobiliaria,
                        telefonoInmobiliaria = inmobiliaria.telefonoInmobiliaria.ToString(),
                        idCuenta = inmobiliaria.idCuenta
                    };
                    db.Inmobiliaria.Add(inmo);
                }
                db.SaveChanges();
                return 1;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}