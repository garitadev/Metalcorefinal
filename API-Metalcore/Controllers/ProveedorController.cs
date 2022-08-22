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
    public class ProveedorController : ApiController
    {
        [HttpGet]
        [Route("api/ConsultarProveedoresAPI")]
        public IHttpActionResult ConsultarProveedoresAPI()
        {
            ProveedoresModel model = new ProveedoresModel();
            try
            {
                var listaProveedores = model.ConsultarProveedores();
                return Ok(listaProveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/ConsultarProveedoresCombo")]
        public IHttpActionResult ConsultarTrabajosCombo()
        {
            try
            {
                ProveedoresModel proveedores = new ProveedoresModel();

                var listaProveedores = proveedores.ConsultarProveedoresCombo();
                return Ok(listaProveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/RegistrarProveedor")]
        public IHttpActionResult RegistrarProveedor(ProveedoresObj proveedores)
        {
            try
            {
                ProveedoresModel model = new ProveedoresModel();
                model.RegistrarProveedor(proveedores);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/ConsultarProveedorEspecifico")]
        public IHttpActionResult ConsultarProveedorEspecifico(int idProveedor)
        {
            ProveedoresModel model = new ProveedoresModel();
            try
            {
                var producto = model.ConsultarProveedorEspecifico(idProveedor);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/ActualizarProveedor")]
        public IHttpActionResult ActualizarProveedor(ProveedoresObj proveedores)
        {
            ProveedoresModel model = new ProveedoresModel();
            try
            {
                model.ActualizarProveedores(proveedores);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/BorrarProve")]
        public IHttpActionResult BorrarProve(int idProve)
        {
            ProveedoresModel model = new ProveedoresModel();
            try
            {
                if (model.BorrarProve(idProve))
                {
                    return Ok();

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

