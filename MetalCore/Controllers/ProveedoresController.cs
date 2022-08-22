
using MetalCore.ETL.Entities;
using SB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SB_Admin.Controllers
{
    public class ProveedoresController : Controller
    {
        [HttpGet]
        public ActionResult Consultar()
        {
            try
            {
                UsuarioObj user = (UsuarioObj)Session["User"];

                if (Session["User"] != null)
                {

                    UsuarioModel CosultaUsuarios = new UsuarioModel();
                    ViewBag.listaPermisos = user.listaPermisos;
                    ProveedoresModel ConsultaActividadesDisponibles = new ProveedoresModel();
                    var ListaActividades = ConsultaActividadesDisponibles.ConsultarTodosProveedores();

                    if (ListaActividades.Count > 0)
                    {
                        return View("Consultar", ListaActividades);
                    }

                }

                return View("Consultar", new List<ProveedoresObj>());

            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Proveedores. Mensaje: Error al Consultar Proveedor: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        [HttpGet]
        public ActionResult Crear()
        {
            if (Session["User"] != null)
            {
                UsuarioObj user = (UsuarioObj)Session["User"];
                var proveedores = new ProveedoresObj();
                ViewBag.listaPermisos = user.listaPermisos;

                return View();
            }
            return View();

        }


        [HttpPost]
        public ActionResult RegistrarProveedores(ProveedoresObj proveedores)
        {
            try
            {
                ProveedoresModel modelo = new ProveedoresModel();

                var respuesta = modelo.RegistrarProveedores(proveedores);
                //verifica la respuesta
                if (respuesta == string.Empty)
                {
                    return RedirectToAction("Consultar", "Proveedores");
                }
                else
                {
                    ViewBag.MsjValidacion = respuesta;
                    return View(proveedores);
                }
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Proveedores. Mensaje: Error al Registrar Proveedor: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }


        //Modificar 
        [HttpPost]
        public ActionResult ModificarProveedoresForm(int idProveedor)
        {
            try
            {

                UsuarioObj user = (UsuarioObj)Session["User"];

                if (Session["User"] != null)
                {
                    ViewBag.listaPermisos = user.listaPermisos;
                    ProveedoresModel proveedores = new ProveedoresModel();
                    var respuesta = proveedores.ConsultarProveedorEspecifico(idProveedor);



                    if (respuesta != null)
                    {
                        return View("Actualizar", respuesta);
                    }
                }

                return View("../Shared/Error");

            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Proveedores. Mensaje: Error al Modificar Proveedor formulario: " + ex.Message.ToString());

                return View("../Shared/Error");
            }

        }

        [HttpPost]
        public ActionResult ModificarProveedor(ProveedoresObj proveedores)
        {
            try
            {
                ProveedoresModel modelo = new ProveedoresModel();
                //almacena un producto en el inventario
                var respuesta = modelo.ModificarProveedor(proveedores);
                //verifica la respuesta
                if (respuesta == true)
                {
                    return RedirectToAction("Consultar", "Proveedores");
                }
                else
                {
                    //ViewBag.MsjValidacion = respuesta;
                    //return View(producto);
                    return View("../Shared/Error");
                }
            }
            catch (Exception ex)
            {

                LogModel.LogError("Modulo: Proveedores. Mensaje: Error al Modificar Proveedor: " + ex.Message.ToString());


                return View("../Shared/Error");
            }
        }

        [HttpPost]
        public ActionResult BorrarProve(int idProve)
        {
            ProveedoresModel modelo = new ProveedoresModel();
            if (modelo.BorrarProve(idProve))
            {
                ViewBag.MjsElim = "Mensaje";
                return RedirectToAction("Consultar", "Proveedores");

            }
            else
            {
                LogModel.LogError("Modulo: Trabajo. Mensaje: Error al Eliminar proveedor: ");

                return View("../Shared/Error");

            }

        }


    }


}
