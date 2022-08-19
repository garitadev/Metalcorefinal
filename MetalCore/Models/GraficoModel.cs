using MetalCore.BLL.Models;
using MetalCore.ETL.Entities;
using Newtonsoft.Json;
using SB_Admin.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SB_Admin.Models
{
    public class GraficoModel
    {

        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();



 

        public List<GraficoObj> GraficoProductos()
        {
            try
            {
                GraficaBLL BLL = new GraficaBLL();
                return (BLL.GraficoProductos());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public List<GraficoObj> GraficoTrabajos()
        {
            try
            {
                GraficaBLL BLL = new GraficaBLL();
                return (BLL.GraficoTrabajos());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}