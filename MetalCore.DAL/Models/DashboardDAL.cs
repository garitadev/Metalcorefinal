using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.DAL.Models
{
    public class DashboardDAL
    {

        public DashboardObj TotalEncurso()
        {


            DashboardObj dato = new DashboardObj();

            using (var contex = new DD_METALCOREEntities())

            {
                try
                {
                    var datos = (from x in contex.Trabajo
                                 select x).ToList();

                    int c = 0;

                    foreach (var item in datos)
                    {

                        if (item.idEstadoTrabajo == 1)
                        {
                            c++;
                        }

                    }

                    dato.TotalProductos = c;

                    return dato;

                }

                catch (Exception ex)
                {

                    var error = ex.ToString();

                    contex.Dispose();
                    throw ex;
                }
            }

        }
        public DashboardObj TotalFinalizado()
        {


            DashboardObj dato = new DashboardObj();

            using (var contex = new DD_METALCOREEntities())

            {
                try
                {
                    var datos = (from x in contex.Trabajo
                                 select x).ToList();

                    int c = 0;

                    foreach (var item in datos)
                    {

                        if (item.idEstadoTrabajo == 2)
                        {
                            c++;
                        }

                    }

                    dato.TotalProductos = c;

                    return dato;

                }

                catch (Exception ex)
                {

                    var error = ex.ToString();

                    contex.Dispose();
                    throw ex;
                }
            }

        }

        public DashboardObj TotalCancelado()
        {


            DashboardObj dato = new DashboardObj();

            using (var contex = new DD_METALCOREEntities())

            {
                try
                {
                    var datos = (from x in contex.Trabajo
                                 select x).ToList();

                    int c = 0;

                    foreach (var item in datos)
                    {

                        if (item.idEstadoTrabajo == 3)
                        {
                            c++;
                        }

                    }

                    dato.TotalProductos = c;

                    return dato;

                }

                catch (Exception ex)
                {

                    var error = ex.ToString();

                    contex.Dispose();
                    throw ex;
                }
            }

        }



        ///////////////////////

        public DashboardObj TotalProductos()
        {


            DashboardObj dato = new DashboardObj();

            using (var contex = new DD_METALCOREEntities())

            {
                try
                {
                    var productos = (from x in contex.Productos
                                     select x).Sum(x=> x.cantidad);

                    if (productos != null)
                    {
                        dato.TotalProductos = (int)productos;
                        return dato;

                    }
                    else
                    {
                        return null;
                    }

                }

                catch (Exception ex)
                {

                    var error = ex.ToString();

                    contex.Dispose();
                    throw ex;
                }
            }

        }
    }
}
