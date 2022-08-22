using MetalCore.BLL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_Metalcore.Models
{
    public class ProveedoresModel
    {
        public List<SelectListItem> ConsultarProveedoresCombo()
        {
            ProveedoresBLL BLL = new ProveedoresBLL();
            return (BLL.ConsultarProveedoresCombo());
        }

        public ProveedoresObj RegistrarProveedor(ProveedoresObj proveedor)
        {
            ProveedoresBLL BLL = new ProveedoresBLL();
            return (BLL.RegistrarProveedor(proveedor));
        }

        public List<ProveedoresObj> ConsultarProveedores()
        {
            ProveedoresBLL BLL = new ProveedoresBLL();
            return (BLL.ConsultarProveedores());
        }

        public ProveedoresObj ConsultarProveedorEspecifico(int idProveedor)
        {
            ProveedoresBLL BLL = new ProveedoresBLL();
            return (BLL.ConsultarProveedorEspecifico(idProveedor));
        }

        public ProveedoresObj ActualizarProveedores(ProveedoresObj proveedor)
        {
            ProveedoresBLL BLL = new ProveedoresBLL();
            return (BLL.ActualizarProveedores(proveedor));
        }

        public bool BorrarProve(int idProve)
        {
            ProveedoresBLL BLL = new ProveedoresBLL();
            return (BLL.BorrarProve(idProve));
        }

    }

}