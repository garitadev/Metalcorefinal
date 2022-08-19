using MetalCore.BLL.Models;
using MetalCore.ETL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Models
{
    public class TrabajoModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();

        public List<TrabajoObj> VerTrabajos()
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.VerTrabajos());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> ConsultarEstadosCombo()
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarEstadosCombo());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TrabajoObj> ConsultarEstadoEspecifico(int idEstado)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarEstadoEspecifico(idEstado));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////////

        public MaterialesOBJ ConsultarMaterialEspecifico(int idMaterial)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarMaterialEspecifico(idMaterial));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActuaTrabajo(TrabajoObj Actua)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                BLL.ActuaTrabajo(Actua);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActuaMaterial(MaterialesOBJ Actua)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                BLL.ActuaMaterial(Actua);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //stocks
        public bool VerifiStockActua(int Cantidad, int idProducto, int idMaterial)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.VerifiStockActua(Cantidad, idProducto, idMaterial));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //borrar trabajo-----------------------------

        public bool BorrarTrabajo(int idTrabajo)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                BLL.BorrarTrabajo(idTrabajo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool BorrarMaterial(int idMaterial)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                BLL.BorrarMaterial(idMaterial);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //verificar que no haya materiales relacionados a trabajos
        public bool VerifiExisTrabajo(int idTrabajo)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.VerifiExisTrabajo(idTrabajo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TrabajoObj> Consultar()
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarTrabajos());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //consultar materiale asignados
        public List<MaterialesOBJ> ConsultarAsigMateri(string token)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarAsigMateri());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MaterialesOBJ EncontrarPrecio(int idProducto)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                var respuesta = BLL.EncontrarPrecio(idProducto);
                return (respuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool VerifiFecha(int idUsuario, DateTime fecha)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.VerifiFecha(idUsuario, fecha));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //stocks
        public bool VerifiStock(int Cantidad, int idProducto)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.VerifiStock(Cantidad, idProducto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> ConsultarEstadoTrabajosCombo()
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarEstadoTrabajosCombo());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<SelectListItem> ProductoPrecio()
        {
            try
            {
                //Se crea una lista para almacenar los trabjos
                List<SelectListItem> listaTrabajos = new List<SelectListItem>();

                using (var client = new HttpClient())
                {
                    ruta += "ProductoPrecio";
                    //Se consulta al API con la ruta definida
                    HttpResponseMessage respuesta = client.GetAsync(ruta).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Se deserializa la respuesta del api
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        listaTrabajos = JsonConvert.DeserializeObject<List<SelectListItem>>(datos);

                    }
                }
                return listaTrabajos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<SelectListItem> ConsultarProductoCombo()
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarProductoCombo());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<SelectListItem> ConsultarEmpleadoCombo()
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarEmpleadoCombo());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //Metodos CRUD Trabajos
        public void RegistrarTrabajo(TrabajoObj trabajo)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                BLL.RegistrarTrabajo(trabajo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //prueba


        //Metodos para combo box

        public List<SelectListItem> ConsultarTrabajosCombo()
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarTrabajosCombo());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //registrar material

        public void RegistrarMaterial(MaterialesOBJ trabajo)
        {
            TrabajosBLL BLL = new TrabajosBLL();
            BLL.RegistrarMaterial(trabajo);
        }


        //modificar

        public TrabajoObj ConsultarUTrabajoEspecifico(int idTrabajo)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarUTrabajoEspecifico(idTrabajo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MaterialesOBJ> ConsultarMaterialesXTrabajo(int idTrabajo)
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarMaterialesXTrabajo(idTrabajo));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //''''''''''''''''PDF

        public List<TrabajoObj> PdfConsulta()
        {
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.PdfConsulta());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TrabajoObj> ConsultarUTrabajoPDF(TrabajoObj idTrabajos)
        {

            int idUsuario = idTrabajos.IdUsuario;
            try
            {
                TrabajosBLL BLL = new TrabajosBLL();
                return (BLL.ConsultarUTrabajoPDF(idUsuario));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}