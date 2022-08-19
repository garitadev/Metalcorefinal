using MetalCore.ETL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using MetalCore.BLL.Models;

namespace SB_Admin.Models
{
    public class DashboardModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();



        public DashboardObj TotalEncurso()
        {
            try
            {
                DashboardBLL BLL = new DashboardBLL();
                return (BLL.TotalEncurso());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DashboardObj TotalFinalizado()
        {
            try
            {
                DashboardBLL BLL = new DashboardBLL();
                return (BLL.TotalFinalizado());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DashboardObj TotalCancelado()
        {
            try
            {
                DashboardBLL BLL = new DashboardBLL();
                return (BLL.TotalCancelado());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   
        ///////////////////////////


        //Obtiene total de productos
        public DashboardObj TotalProductos()
        {
            try
            {
            
                DashboardBLL BLL = new DashboardBLL();
                return (BLL.TotalProductos());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}