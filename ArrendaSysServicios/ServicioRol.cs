using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioRol
    {
        public int ModificarRol(RolViewModel rol)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var consultaunRol = db.Rol.Where(x => x.idRol == rol.idRol).FirstOrDefault();
                var list = db.PermisoRol.Where(x => x.idRol == rol.idRol).ToList();

                if (consultaunRol != null)
                {
                    //Rol
                    consultaunRol.nombreRol = rol.nombreRol;

                    foreach (var consultaAccesoRol in list)
                    {
                        //Acceso Rol
                        db.PermisoRol.Remove(consultaAccesoRol);
                    }
                    foreach (var lisMenu in rol.menu)
                    {
                        PermisoRol gar = new PermisoRol
                        {
                            idRol = rol.idRol,
                            lecturaRol = lisMenu.lectura,
                            edicionRol = lisMenu.edicion,
                            eliminacionRol = lisMenu.eliminacion,
                            idURL = lisMenu.idUrl,
                        };
                        db.PermisoRol.Add(gar);
                    }

                }

                db.SaveChanges();
            }
            return 200;

        }
        public List<URLViewModel> ObtenerMenu(string emailCuenta)
        {
            ServicioCuenta serUsuario = new ServicioCuenta();
            var usuario = serUsuario.ObtenerDatosUsuarioLogueado(emailCuenta);
            List<URLViewModel> lstMenu = new List<URLViewModel>();
            if (usuario != null)
            {
                var idUsuario = usuario.idCuenta;
                var rolesUsuario = RolesPorUsuario(idUsuario);


                using (ArrendasysEntities db = new ArrendasysEntities())
                {
                    foreach (var item in rolesUsuario)
                    {
                        var menuRol = (from m in db.URL
                                       join ga in db.PermisoRol on m.idURL equals ga.idURL
                                       where ga.idRol == item.idRol && m.seMuestra == true
                                       select new URLViewModel
                                       {
                                           idUrl = m.idURL,
                                           codigo = m.codigo,
                                           codigoRetorno = 200,
                                           descripcion = m.descripcion,
                                           nombreUrl = m.nombre,
                                           linkUrl = m.linkURL,
                                           posicion = m.posicion,
                                           iconClass = m.iconClass
                                       }).Where((x) => x.idUrl > 0).Distinct().ToList();

                        foreach (var item2 in menuRol)
                        {
                            lstMenu.Add(item2);
                        }
                    }
                    if (lstMenu.Count > 0)
                    {
                        lstMenu = lstMenu.Where((x) => x.idUrl > 0).Distinct().OrderBy(y => y.posicion).ToList();
                    }
                    else
                    {
                        URLViewModel sinMenu = new URLViewModel
                        {
                            idUrl = -1,
                            codigoRetorno = 400
                        };
                        lstMenu.Add(sinMenu);
                    }

                }

            }
            return lstMenu;
        }

        public List<RolViewModel> RolesPorUsuario(int idCuenta)
        {
            List<RolViewModel> listaRoles = new List<RolViewModel>();
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                var consultarUsuario = db.Cuenta.Find(idCuenta);
                if (consultarUsuario != null)
                {
                    var rol = (from r in db.Rol
                               join nr in db.Cuenta on r.idRol equals nr.idRol
                               where nr.idCuenta == idCuenta
                               select new RolViewModel
                               {
                                   codigoRetorno = 200,
                                   idRol = r.idRol,
                                   nombreRol = r.nombreRol,

                               }).ToList();
                    foreach (var item in rol)
                    {
                        listaRoles.Add(item);
                    }
                }


            }
            return listaRoles;
            //var user = nombreUsuario.Remove(0, 10);

        }
        public List<URLViewModel> ObtenerListaMenu()
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                List<URLViewModel> listaMenu = new List<URLViewModel>();
                listaMenu = (from m in db.URL
                             select new URLViewModel
                             {
                                 idUrl = m.idURL,
                                 nombreUrl = m.nombre,
                             }).ToList();
                return listaMenu;
            }
        }
        public RolViewModel obtenerRol(int idRol)
        {
            using (ArrendasysEntities  db = new ArrendasysEntities())
            {
                RolViewModel rol;
                rol = (from r in db.Rol
                       where r.idRol == idRol
                       select new RolViewModel
                       {
                           idRol = r.idRol,
                           tipoRol=r.tipoRol
                       }).FirstOrDefault();
                return rol;
            }
        }
        public List<RolViewModel> obtenerRoles()
        {
            using (ArrendasysEntities  db = new ArrendasysEntities())
            {
                List<RolViewModel> roles;
                roles = (from r in db.Rol
                         where r.tipoRol!=1
                       select new RolViewModel
                       {
                           idRol = r.idRol,
                           tipoRol=r.tipoRol,
                           nombreRol=r.nombreRol
                       }).ToList();
                return roles;
            }
        }
        public RolViewModel ConsultarRol(int idRol)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                RolViewModel rol;
                List<URLViewModel> listAcceso = new List<URLViewModel>();
                rol = (from r in db.Rol where r.idRol == idRol
                       select new RolViewModel
                       {
                           idRol = r.idRol,
                           nombreRol = r.nombreRol,
                           tipoRol = r.tipoRol
                       }).FirstOrDefault();


                rol.menu = new List<URLViewModel>();
                var list = db.PermisoRol.Where(x => x.idRol == rol.idRol).ToList();
                foreach (var i in list)
                {
                    URLViewModel menu = new URLViewModel
                    {
                         idPermisoRol= i.idPermisoRol,
                        idUrl = i.idURL,
                        lectura = i.lecturaRol,
                        edicion = i.edicionRol,
                        eliminacion = i.eliminacionRol,
                    };
                    rol.menu.Add(menu);
                }

                return rol;
            }
        }
        public object ObtenerRoles(bool activo)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                
                if (activo)
                {
                    var lista = (from r in db.Rol
                                 where r.fechaBajaRol == null
                                 select new RolViewModel
                                 {
                                     nombreRol = r.nombreRol,
                                     idRol = r.idRol,
                                     activo=true,
                                     fechaBajaRol=r.fechaBajaRol,
                                     tipoRol=r.tipoRol,
                                     descripcionRol=r.descripcionRol

                                 }).ToList();
                    object json = new { data = lista };
                    return json;
                }
                else
                {
                    var lista = (from r in db.Rol
                                 where r.fechaBajaRol != null
                                 select new RolViewModel
                                 {
                                     nombreRol = r.nombreRol,
                                     idRol = r.idRol,
                                     activo = false,
                                     fechaBajaRol = r.fechaBajaRol,
                                     tipoRol = r.tipoRol,
                                     descripcionRol = r.descripcionRol

                                 }).ToList();
                    object json = new { data = lista };
                    return json;
                }
                
            }
        }

        //Maury
        public int AgregarRol(RolViewModel rol)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {

                Rol rol1 = new Rol();
                rol1.nombreRol = rol.nombreRol;
                rol1.tipoRol = rol.tipoRol;
                rol1.descripcionRol = rol.descripcionRol;
                rol1.fechaAltaRol = DateTime.Now;
                db.Rol.Add(rol1);
                db.SaveChanges();
                return 1;
            }
        }


        public int EliminarRol(RolViewModel rol)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var rol1 = db.Rol.Where(x => x.idRol == rol.idRol).FirstOrDefault();
                rol1.fechaBajaRol= DateTime.Now;                
                db.SaveChanges();
                return 1;
            }
        }


        public int EditarRol(RolViewModel rol)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var rol1 = db.Rol.Where(x => x.idRol == rol.idRol).FirstOrDefault();
                rol1.nombreRol = rol.nombreRol;
                rol1.tipoRol = rol.tipoRol;
                rol1.descripcionRol = rol.descripcionRol;
                db.SaveChanges();
                return 1;
            }
        }

    }
}
