using API_Metalcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Metalcore.Controllers
{
    public class GraficoController : ApiController
    {

        [HttpGet]
        [Route("api/GraficoProductos")]
        public IHttpActionResult GraficoProductos()
        {
            GraficaModel model = new GraficaModel();
            try
            {
                var cbtenerGrafico = model.GraficoProductos();
                return Ok(cbtenerGrafico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/GraficoTrabajos")]
        public IHttpActionResult cbtenerGrafico()
        {
            GraficaModel model = new GraficaModel();
            try
            {
                var cbtenerGrafico = model.GraficoTrabajos();
                return Ok(cbtenerGrafico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







    }
}
