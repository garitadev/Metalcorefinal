using API_Metalcore.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Metalcore.Controllers
{
    public class DashboardController : ApiController
    {

        [HttpGet]
        [Route("api/TotalEncurso")]
        public IHttpActionResult TotalEncurso()
        {
            DashboardModel model = new DashboardModel();
            try
            {
                var TotalEncurso = model.TotalEncurso();
                return Ok(TotalEncurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/TotalFinalizado")]
        public IHttpActionResult TotalFinalizado()
        {
            DashboardModel model = new DashboardModel();
            try
            {
                var TotalFinalizado = model.TotalFinalizado();
                return Ok(TotalFinalizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/TotalCancelado")]
        public IHttpActionResult TotalCancelado()
        {
            DashboardModel model = new DashboardModel();
            try
            {
                var TotalCancelado = model.TotalCancelado();
                return Ok(TotalCancelado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/TotalProductos")]
        public IHttpActionResult TotalProductos()
        {
            DashboardModel model = new DashboardModel();
            try
            {
                var totalProducto = model.TotalProductos();
                return Ok(totalProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
