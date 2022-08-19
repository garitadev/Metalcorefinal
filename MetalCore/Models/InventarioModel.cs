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
    public class InventarioModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();

        //Obtiene la lista de proveedores
        public List<ProductosObj> ObtenerProveedor()
        {
            try
            {
                InventarioBLL BLL = new InventarioBLL();
                return (BLL.ObtenerProveedor());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Crea los objetos para obtenerlos en la vista
        public List<SelectListItem> CosultarProveedores()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            InventarioModel model = new InventarioModel();
            var datos = model.ObtenerProveedor();

            foreach (var item in datos)
            {
                list.Add(new SelectListItem { Text = item.PROVEEDOR });
            }
            return list;
        }


        public List<ProductosObj> ConsultarTodosProductos(string token)
        {
            try
            {
                InventarioBLL BLL = new InventarioBLL();
                return (BLL.ConsultarProductos());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Operaciones CRUD Inventario
        public ProductosObj CrearProdcuto(ProductosObj producto)
        {
            InventarioBLL BLL = new InventarioBLL();
            return BLL.RegistrarProductos(producto);
        }


        public bool ModificarProducto(ProductosObj producto)
        {
            try
            {
                InventarioBLL BLL = new InventarioBLL();
                var productoAct = BLL.ActualizarProductos(producto);

                if (productoAct != null)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarProducto(int idProducto)
        {
            try
            {
                InventarioBLL BLL = new InventarioBLL();
                var productoEli = BLL.BorrarProductos(idProducto);

                if (productoEli != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Consultar por un registro en especifico
        public ProductosObj ConsultarProductoEspecifico(int idProducto)
        {
            try
            {
                InventarioBLL BLL = new InventarioBLL();
                return (BLL.ConsultarProducto(idProducto));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Metodos para llenar combobox
        public List<SelectListItem> ConsultarTodosProductosCombo()
        {
            try
            {
                InventarioBLL BLL = new InventarioBLL();
                return (BLL.ConsultarProductosCombo());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}