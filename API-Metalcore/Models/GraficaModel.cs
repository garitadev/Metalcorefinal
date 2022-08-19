using MetalCore.BLL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Metalcore.Models
{
    public class GraficaModel
    {

        public List<GraficoObj> GraficoProductos()
        {
            GraficaBLL BLL = new GraficaBLL();
            return (BLL.GraficoProductos());
        }

        public List<GraficoObj> GraficoTrabajos()
        {
            GraficaBLL BLL = new GraficaBLL();
            return (BLL.GraficoTrabajos());
        }
    }
}