using MetalCore.ETL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using MetalCore.BLL.Models;

namespace SB_Admin.Models
{
    public class ProveedoresModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();

        public List<ProveedoresObj> ConsultarTodosProveedores()
        {
            try
            {
                ProveedoresBLL BLL = new ProveedoresBLL();
                return (BLL.ConsultarProveedores());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> ConsultarTodosProveedoresCombo()
        {
            try
            {
                ProveedoresBLL BLL = new ProveedoresBLL();
                return (BLL.ConsultarProveedoresCombo());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RegistrarProveedores(ProveedoresObj proveedores)
        {
            try
            {
                ProveedoresBLL BLL = new ProveedoresBLL();

                if (BLL.RegistrarProveedor(proveedores) != null)
                {
                    return string.Empty;

                }
                return "No se ha podido registrar el proveedor";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ProveedoresObj ConsultarProveedorEspecifico(int idProveedor)
        {
            try
            {
                ProveedoresBLL BLL = new ProveedoresBLL();
                return (BLL.ConsultarProveedorEspecifico(idProveedor));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ModificarProveedor(ProveedoresObj proveedores)
        {
            try
            {
                ProveedoresBLL BLL = new ProveedoresBLL();
                if (BLL.ActualizarProveedores(proveedores) != null)
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

        public bool BorrarProve(int idProve)
        {
            try
            {
                ProveedoresBLL BLL = new ProveedoresBLL();
                BLL.BorrarProve(idProve);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}