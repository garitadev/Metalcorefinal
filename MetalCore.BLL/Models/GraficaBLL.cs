using MetalCore.DAL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCore.BLL.Models
{
    public class GraficaBLL
    {

        public List<GraficoObj> GraficoProductos()
        {
            GraficaDAL DAL = new GraficaDAL();
            return (DAL.GraficoProductos());
        }
        public List<GraficoObj> GraficoTrabajos()
        {
            GraficaDAL DAL = new GraficaDAL();
            return (DAL.GraficoTrabajos());
        }



    }
}
