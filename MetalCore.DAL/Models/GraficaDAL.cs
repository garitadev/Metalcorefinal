using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.DAL.Models
{
    public class GraficaDAL
    {

        public List<GraficoObj> GraficoProductos()
        {
            List<GraficoObj> resultado = new List<GraficoObj>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var list = (from t in context.Productos
                                orderby t.cantidad
                                select t).Take(5).ToList();

                  

                    foreach (var item in list)
                    {
                        resultado.Add(new GraficoObj
                        {
                            name = item.nombre,
                            y = (int)item.cantidad,
                            Marca = item.marca

                        });

                    }

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {

                    var error = ex.ToString();
                    context.Dispose();

                    throw ex;
                }
            }

        }

        public List<GraficoObj> GraficoTrabajos()
        {

            List<GraficoObj> resultado = new List<GraficoObj>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Trabajo
                                 select x).ToList();

                    int c = 0;
                    int f = 0;
                    int p = 0;

                    foreach (var item in datos)
                    {

                        if (item.idEstadoTrabajo == 1)
                        {
                            c++;
                        }
                        else if (item.idEstadoTrabajo == 2)
                        {
                            f++;
                        }
                        else if (item.idEstadoTrabajo == 3)
                        {
                            p++;
                        }
                    }

                    resultado.Add(new GraficoObj
                    {

                        name = "En Curso",
                        y = c

                    }); ;
                    resultado.Add(new GraficoObj
                    {

                        name = "Finalizado",
                        y = f

                    });
                    resultado.Add(new GraficoObj
                    {

                        name = "Cancelado",
                        y = p

                    });

                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    context.Dispose();

                    throw ex;
                }
            }
        }




    }
}
