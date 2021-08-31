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
                                           codigo= m.codigo,
                                           codigoRetorno = 200,
                                           descripcion = m.descripcion,
                                           nombreUrl = m.nombre,
                                           linkUrl = m.linkURL,
                                           posicion = m.posicion,
                                           iconClass=m.iconClass
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
    }
}
