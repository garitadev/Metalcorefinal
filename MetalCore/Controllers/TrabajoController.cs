using SB_Admin.Filters;
using SB_Admin.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;

namespace SB_Admin.Controllers
{
    public class TrabajoController : Controller
    {
        // GET: Trabajo


        [HttpGet]
        public ActionResult VerTrabajos()
        {


            try
            {
                TrabajoModel model = new TrabajoModel();
                UsuarioObj user = (UsuarioObj)Session["User"];


                ViewBag.listaPermisos = user.listaPermisos;

                var respuesta = model.VerTrabajos();

                if (Session["User"] != null)
                {

                    var estados = model.ConsultarEstadosCombo();


                    ViewBag.User = user;
                    ViewBag.listaEstados = estados;
                    ViewBag.listaTrabajos = respuesta;
                    TrabajoModel modeloss = new TrabajoModel();
                    ViewBag.listaUsuarios = modeloss.ConsultarEmpleadoCombo();

                    return View();
                }
                return View("VerTrabajos");
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Ver Trabajos: " + ex.Message.ToString());

                return View("VerTrabajos");

            }
        }


        [HttpPost]
        public ActionResult idEspecifico(int IdEstado)
        {
            List<TrabajoObj> lst;
            TrabajoModel model = new TrabajoModel();

            lst = model.ConsultarEstadoEspecifico(IdEstado);



            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        ////////////////////////////////////////////////////


        [HttpGet]
        public ActionResult Consultar()
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
           // var token = user.TokenJWT;
            try
            {
                if (Session["User"] != null)
                {

                    TrabajoModel CosultaTrabajos = new TrabajoModel();
                    ViewBag.listaPermisos = user.listaPermisos;
                    var respuesta = CosultaTrabajos.Consultar();


                    return View(respuesta);

                }
                return View();

            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Consultar Trabajos: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        [HttpGet]
        public ActionResult ConsultarAsigMateri()
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                if (Session["User"] != null)
                {

                    TrabajoModel ConsultarAsigMateri = new TrabajoModel();
                    ViewBag.listaPermisos = user.listaPermisos;
                    var respuesta = ConsultarAsigMateri.ConsultarAsigMateri(token);


                    return View(respuesta);

                }
                return View();

            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Consultar Asignar Materiales: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }
        [HttpPost]
        //encontrar precio producto
        public ActionResult EncontrarPrecio(int idProducto)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                TrabajoModel modeloza = new TrabajoModel();
                ViewBag.listaPermisos = user.listaPermisos;
                var respuesta = modeloza.EncontrarPrecio(idProducto);
                decimal cantidadProducto = respuesta.Precio;
                return Json(cantidadProducto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Encontrar Precio: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        [HttpGet]
        public ActionResult AsignarTrabajoFrm()
        {

            TrabajoModel modelo = new TrabajoModel();
            try
            {

                if (Session["User"] != null)
                {
                    UsuarioObj user = (UsuarioObj)Session["User"];
                    ViewBag.listaPermisos = user.listaPermisos;
                    ViewBag.listaEstados = modelo.ConsultarEstadoTrabajosCombo();
                    TrabajoModel modelos = new TrabajoModel();
                    ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                    TrabajoModel modeloza = new TrabajoModel();
                    ViewBag.listaprodu = modeloza.ConsultarProductoCombo();
                    TrabajoModel modelozas = new TrabajoModel();
                    ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                }
                return View("Asignar");

            }
            catch (Exception ex)
            {

                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Asignar Trabajo Formulario: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        //asignar materiales
        [HttpGet]
        public ActionResult AsignarMaterialesFrm()
        {

            TrabajoModel modelo = new TrabajoModel();
            try
            {

                if (Session["User"] != null)
                {
                    UsuarioObj user = (UsuarioObj)Session["User"];
                    ViewBag.listaPermisos = user.listaPermisos;

                    TrabajoModel modeloza = new TrabajoModel();
                    ViewBag.listaprodu = modeloza.ConsultarProductoCombo();
                    TrabajoModel modelozas = new TrabajoModel();
                    ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                }
                return View("Asignar");

            }
            catch (Exception ex)
            {

                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Asignar Materiales Formulario: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        //guardar materiales
        [HttpPost]
        public ActionResult AsignarMateriales(MaterialesOBJ trabajo)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];

            int Cantidad = trabajo.Cantidad;
            int idProducto = trabajo.IdProducto;
            try
            {
                TrabajoModel modelo = new TrabajoModel();

                var respuestaV = modelo.VerifiStock(Cantidad, idProducto);
                ViewBag.listaPermisos = user.listaPermisos;


                //validacion
                if (ModelState.IsValid)
                {


                    if (respuestaV == false)
                    {
                        TrabajoModel modelao = new TrabajoModel();
                        ViewBag.listaPermisos = user.listaPermisos;

                        ViewBag.MjsCrearMate = "Mensaje";

                        //TrabajoModel modeloza = new TrabajoModel();
                        //ViewBag.listaEstados = modelo.ConsultarEstadoTrabajosCombo();
                        TrabajoModel modelos = new TrabajoModel();
                        ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                        TrabajoModel modelozsa = new TrabajoModel();
                        ViewBag.listaprodu = modelozsa.ConsultarProductoCombo();
                        TrabajoModel modelozas = new TrabajoModel();
                        ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();
                        return View("Asignar");

                    }
                    else
                    {

                        TrabajoModel modelao = new TrabajoModel();
                        ViewBag.listaPermisos = user.listaPermisos;
                        modelao.RegistrarMaterial(trabajo);
                        ViewBag.MjsCreadoMate = "Mensaje";
                        //TrabajoModel modeloza = new TrabajoModel();
                        //ViewBag.listaEstados = modelo.ConsultarEstadoTrabajosCombo();
                        TrabajoModel modelos = new TrabajoModel();
                        ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                        TrabajoModel modelozsa = new TrabajoModel();
                        ViewBag.listaprodu = modelozsa.ConsultarProductoCombo();
                        TrabajoModel modelozas = new TrabajoModel();
                        ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                        return View("Asignar");
                    }

                }


                return View(trabajo);
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Asignar Materiales: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }




        //guardar trabajos
        [HttpPost]
        public ActionResult RegistrarTrabajo(TrabajoObj trabajo)
        {

           

            UsuarioObj user = (UsuarioObj)Session["User"];

            int idUsuario = trabajo.IdUsuario; //variables para la validación de existencia
            DateTime fecha = trabajo.Fecha;
            int idTrabajo = trabajo.IdTrabajo;


            try
            {
                TrabajoModel modelo = new TrabajoModel();

                var respuestaV = modelo.VerifiFecha(idUsuario, fecha);//metodo de existencia
                ViewBag.listaPermisos = user.listaPermisos;


                //validacion
                if (ModelState.IsValid)
                {

                    //crea un empleado nuevo
                    if (respuestaV == false)
                    {

                        ViewBag.listaPermisos = user.listaPermisos;

                        ViewBag.MjsCrear = "Mensaje";
                        //TrabajoModel modelaos = new TrabajoModel();
                        //ViewBag.listaEstados = modelaos.ConsultarEstadoTrabajosCombo();
                        TrabajoModel modelos = new TrabajoModel();
                        ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                        TrabajoModel modelozsa = new TrabajoModel();
                        ViewBag.listaprodu = modelozsa.ConsultarProductoCombo();
                        TrabajoModel modelozas = new TrabajoModel();
                        ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                        ModelState.Clear();
                        TrabajoObj obj = new TrabajoObj()
                        {
                            NombreCliente = string.Empty,
                            TelefonoCliente = string.Empty,
                            Descripcion = string.Empty,
                            Direccion = string.Empty
                        };

                        return View("Asignar");

                    }
                    else
                    {
                        //crea un empleado nuevo

                        TrabajoModel modelao = new TrabajoModel();
                        ViewBag.listaPermisos = user.listaPermisos;
                        modelao.RegistrarTrabajo(trabajo);
                        ViewBag.MjsCreado = "Mensaje";
                        //TrabajoModel modelaos = new TrabajoModel();

                        //ViewBag.listaEstados = modelaos.ConsultarEstadoTrabajosCombo();
                        TrabajoModel modelos = new TrabajoModel();
                        ViewBag.listaUsuarios = modelos.ConsultarEmpleadoCombo();
                        TrabajoModel modelozsa = new TrabajoModel();
                        ViewBag.listaprodu = modelozsa.ConsultarProductoCombo();
                        TrabajoModel modelozas = new TrabajoModel();
                        ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();

                        ModelState.Clear();
                        TrabajoObj obj = new TrabajoObj()
                        {
                            NombreCliente = string.Empty,
                            TelefonoCliente = string.Empty,
                            Descripcion = string.Empty,
                            Direccion = string.Empty
                        };

                        return View("Asignar");
                    }

                }


                return View(trabajo);
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Registrar Trabajo: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        //actualizar informacion---------------------

        [HttpPost]
        public ActionResult ModificarTrabajoForm(int idTrabajo)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                TrabajoModel modelos = new TrabajoModel();
                ViewBag.listaPermisos = user.listaPermisos;
                var respuesta = modelos.ConsultarUTrabajoEspecifico(idTrabajo);
                TrabajoModel modelaos = new TrabajoModel();
                ViewBag.listaEstados = modelaos.ConsultarEstadoTrabajosCombo();
                TrabajoModel modeloss = new TrabajoModel();
                ViewBag.listaUsuarios = modeloss.ConsultarEmpleadoCombo();

                if (respuesta != null)
                {
                    return View("Actualizar", respuesta);
                }
                else
                {
                    return View("../Shared/Error");

                }
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Actualizar Informacion: " + ex.Message.ToString());


                return View("../Shared/Error");
            }

        }


        public ActionResult ActuaTrabajo(TrabajoObj Actua)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                TrabajoModel modelos = new TrabajoModel();
                ViewBag.listaPermisos = user.listaPermisos;
                var respuesta = modelos.ActuaTrabajo(Actua);

                if (respuesta == true)
                {
                    ViewBag.MjsActua = "Mensaje";
                    return RedirectToAction("Consultar", "Trabajo");
                }
                else
                {

                    return View("../Shared/Error");
                }
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Actualizar Informacion de Trabajo: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        //modifcar material---------------

        [HttpPost]
        public ActionResult ModificarmaterialForm(int idMaterial)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;
            try
            {
                TrabajoModel modelos = new TrabajoModel();
                ViewBag.listaPermisos = user.listaPermisos;
                var respuesta = modelos.ConsultarMaterialEspecifico(idMaterial);
                TrabajoModel modeloza = new TrabajoModel();
                ViewBag.listaprodu = modeloza.ConsultarProductoCombo();
                TrabajoModel modelozas = new TrabajoModel();
                ViewBag.listaTrabajos = modelozas.ConsultarTrabajosCombo();


                if (respuesta != null)
                {
                    return View("ActualiMaterial", respuesta);
                }
                else
                {
                    return View("../Shared/Error");

                }
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Consultar Trabajos: " + ex.Message.ToString());

                return View("../Shared/Error");
            }

        }

        public ActionResult ActuaMaterial(MaterialesOBJ Actua)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;

            int Cantidad = Actua.Cantidad;
            int idProducto = Actua.IdProducto;
            int idMaterial = Actua.IdMaterial;
            try
            {
                TrabajoModel modelos = new TrabajoModel();
                ViewBag.listaPermisos = user.listaPermisos;
                TrabajoModel modelo = new TrabajoModel();
                var respuestaV = modelo.VerifiStockActua(Cantidad, idProducto, idMaterial);
                ViewBag.listaPermisos = user.listaPermisos;


                if (respuestaV == true)
                {
                    var respuesta = modelos.ActuaMaterial(Actua);
                    ViewBag.MjsActua = "Mensaje";
                    return RedirectToAction("ConsultarAsigMateri", "Trabajo");
                }
                else
                {
                    ViewBag.MjsNoActu = "Mensaje";
                    return RedirectToAction("ConsultarAsigMateri", "Trabajo");
                }
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Actualizar Material: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        //eliminar material--------------------------------

        [HttpPost]
        public ActionResult BorrarTrabajo(int idTrabajo)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;

            ViewBag.listaPermisos = user.listaPermisos;
            TrabajoModel modelo = new TrabajoModel();
            var respuestaV = modelo.VerifiExisTrabajo(idTrabajo);

            if (respuestaV == false)
            {

                TrabajoModel CosultaTrabajos = new TrabajoModel();
                ViewBag.listaPermisos = user.listaPermisos;
                CosultaTrabajos.BorrarTrabajo(idTrabajo);
                ViewBag.MjsElim = "Mensaje";
                return RedirectToAction("Consultar", "Trabajo");

            }
            else
            {
                TrabajoModel modelos = new TrabajoModel();
                modelos.BorrarTrabajo(idTrabajo);
                ViewBag.MjsElim = "Mensaje";
                return RedirectToAction("Consultar", "Trabajo");
            }


        }

 
        public ActionResult ConsultarMaterialesXTrabajo(int idTrabajo)
        {
            if (Session["User"] != null)
            {

                UsuarioObj user = (UsuarioObj)Session["User"];
                TrabajoModel modelo = new TrabajoModel();
                ViewBag.listaPermisos = user.listaPermisos;
                var respuesta = modelo.ConsultarUTrabajoEspecifico(idTrabajo);
                var listaMateriales = modelo.ConsultarMaterialesXTrabajo(idTrabajo);
                ViewBag.listaMateriales = listaMateriales;


                return View(respuesta);

            }
            return View();
        }

        public ActionResult Maps()
        {
            if (Session["User"] != null)
            {

                UsuarioObj user = (UsuarioObj)Session["User"];
                TrabajoModel CosultaTrabajos = new TrabajoModel();
                ViewBag.listaPermisos = user.listaPermisos;
                var respuesta = CosultaTrabajos.Consultar();


                return View();

            }
            return View();
        }

        //parte para el pdf
        public ActionResult PdfConsultas(UsuarioObj user)
        {

            TrabajoModel CosultaTrabajos = new TrabajoModel();
            try
            {

                ViewBag.listaPermisos = user.listaPermisos;

                var respuesta = CosultaTrabajos.PdfConsulta();
                return new ViewAsPdf(respuesta) { FileName = "Reporte de empleados.pdf" };//Este objetos recibe parametros segun la accion y datos que son agregados a la vista
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Consultar PDF: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        public ActionResult ConsultarUTrabajoPDF(TrabajoObj idTrabajo)
        {

            TrabajoModel ConsultarUTrabajoPDF = new TrabajoModel();


            try
            {

                var respuesta = ConsultarUTrabajoPDF.ConsultarUTrabajoPDF(idTrabajo);
                return new ViewAsPdf(respuesta) { FileName = "Reporte de control.pdf" };//Este objetos recibe parametros segun la accion y datos que son agregados a la vista
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Consultar Trabajo PDF: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }
    }
}
