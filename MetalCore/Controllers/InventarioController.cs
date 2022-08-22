//using SB_Admin.Entities;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using SB_Admin.Entities;
using SB_Admin.Models;

namespace SB_Admin.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        // GET: Inventario
        [HttpGet]
        public ActionResult Consultar(int? codigo)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            var token = user.TokenJWT;

            try
            {

                if (codigo!= null)
                {
                    ViewBag.codigo = codigo;
                }
                //verifica si la lista de actividades tiene datos o está vacía
                if (Session["User"] != null)
                {
                    InventarioModel model = new InventarioModel();
                    var respuesta = model.ConsultarTodosProductos(token);
                    ViewBag.listaPermisos = user.listaPermisos;
                    ViewBag.rol = user.idRol;


                    return View(respuesta);
                }
                else
                {
                    return RedirectToAction("Registrar");
                }
            }
            catch (Exception ex)
            {

                LogModel.LogError("Modulo: Inventario. Mensaje: Error al Consultar Inventario: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            InventarioModel model = new InventarioModel();

            ViewBag.Proveedor = model.CosultarProveedores();

            if (Session["User"] != null)
            {
                UsuarioObj user = (UsuarioObj)Session["User"];
                return View(user.listaPermisos);
            }
            return View();
        }

        public ActionResult CrearProducto(ProductosObj producto)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];

            try
            {
                if (Session["User"] != null)
                {
                    InventarioModel modelo = new InventarioModel();
                    //almacena un producto en el inventario
                    var respuesta = modelo.CrearProdcuto(producto);

                    //verifica la respuesta
                    if (respuesta != null)
                    {
                        return RedirectToAction("Consultar", "Inventario");
                    }
                    else
                    {
                        ViewBag.MsjValidacion = respuesta;
                        return View(producto);
                    }

                }
                return View(producto);


            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Inventario. Mensaje: Error al Crear Producto: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }
        [HttpGet]
        public ActionResult CrearProductoFrm()
        {
            try
            {
                if (Session["User"] != null)
                {
                    UsuarioObj user = (UsuarioObj)Session["User"];
                    ProveedoresModel proveedores = new ProveedoresModel();
                    var respuesta = proveedores.ConsultarTodosProveedoresCombo();

                    ViewBag.listaPermisos = user.listaPermisos;
                    ViewBag.listaProveedores = respuesta;

                    return View("Crear");
                }
                return View();
            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Inventario. Mensaje: Error al Crear Producto en Formulario: " + ex.Message.ToString());
                //bita.RegistrarError(e.Message);
                return View("../Shared/Error");
            }
        }


        [HttpPost]
        public ActionResult EliminarProducto(int idProducto)
        {
            InventarioModel modelo = new InventarioModel();
            ProveedoresModel modelos = new ProveedoresModel();
            //Consultar si el producto tiene trabajos
            //->si tieena return view
            if (modelo.ConsultaProductoMaterial(idProducto) != null)
            {

                //codigos 3 -> no se puede borrar
                int codigo = 3;
                ViewBag.codigo = codigo;
                return RedirectToAction("Consultar", "Inventario", new {codigo = 3});

            }


            if (modelo.EliminarProducto(idProducto))
            {
                return RedirectToAction("Consultar", "Inventario");

            }
            else
            {
                LogModel.LogError("Modulo: Inventario. Mensaje: Error al Eliminar Producto: ");
                return View("../Shared/Error");

            }

        }

        [HttpPost]
        public ActionResult ModificarProducto(ProductosObj producto)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];
            InventarioModel modelo = new InventarioModel();
            ProveedoresModel proveedores = new ProveedoresModel();

            try
            {

                if (Session["User"] != null)
                {
                    var comboProveedores = proveedores.ConsultarTodosProveedoresCombo();
                    
                    ViewBag.listaPermisos = user.listaPermisos;
                    ViewBag.listaProveedores = comboProveedores;
                    //almacena un producto en el inventario
                    var respuesta = modelo.ModificarProducto(producto);

                    //verifica la respuesta
                    if (respuesta == true)
                    {
                        return RedirectToAction("Consultar", "Inventario");
                    }
                    else
                    {
                        //ViewBag.MsjValidacion = respuesta;
                        //return View(producto);
                        return View("../Shared/Error");
                    }
                }

                return View("../Shared/Error");

            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Inventario. Mensaje: Error al Modificar Producto: " + ex.Message.ToString());

                return View("../Shared/Error");
            }
        }

        //Modificar 
        [HttpPost]
        public ActionResult ModificarProductoForm(int idProducto)
        {
            UsuarioObj user = (UsuarioObj)Session["User"];

            ProveedoresModel proveedores = new ProveedoresModel();
            InventarioModel modelo = new InventarioModel();
            try
            {
                if (Session["User"] != null)
                {
                    var respuesta = proveedores.ConsultarTodosProveedoresCombo();

                    ViewBag.listaPermisos = user.listaPermisos;
                    ViewBag.listaProveedores = respuesta;
                    //Almacena la información de la actividad consultada

                    var producto = modelo.ConsultarProductoEspecifico(idProducto);

                    if (producto != null)
                    {
                        return View("Actualizar", producto);
                    }
                    return View("Actualizar");
                }
                return View("Actualizar");

            }
            catch (Exception ex)
            {
                LogModel.LogError("Modulo: Inventario. Mensaje: Error al Modificar Producto Formulario: " + ex.Message.ToString());

                return View("../Shared/Error");
            }

        }



    }
}