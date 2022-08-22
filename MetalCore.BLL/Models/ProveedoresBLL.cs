using MetalCore.DAL.Models;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.BLL.Models
{
    public class ProveedoresBLL
    {
        public List<SelectListItem> ConsultarProveedoresCombo()
        {
            ProveedoresDAL DAL = new ProveedoresDAL();
            return (DAL.ConsultarProveedoresCombo());
        }

        public ProveedoresObj RegistrarProveedor(ProveedoresObj proveedor)
        {
            ProveedoresDAL DAL = new ProveedoresDAL();
            return (DAL.RegistrarProveedor(proveedor));
        }

        public List<ProveedoresObj> ConsultarProveedores()
        {
            ProveedoresDAL DAL = new ProveedoresDAL();

            return (DAL.ConsultarProveedores());
        }


        public ProveedoresObj ConsultarProveedorEspecifico(int idProveedor)
        {
            ProveedoresDAL DAL = new ProveedoresDAL();

            return (DAL.ConsultarProveedorEspecifico(idProveedor));
        }

        public ProveedoresObj ActualizarProveedores(ProveedoresObj proveedor)
        {
            ProveedoresDAL DAL = new ProveedoresDAL();
            return (DAL.ActualizarProveedores(proveedor));
        }

        public bool BorrarProve(int idProve)
        {
            ProveedoresDAL DAL = new ProveedoresDAL();
            return (DAL.BorrarProve(idProve));

        }
    }
}
