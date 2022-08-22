using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MetalCore.DAL.Models
{
    public class ProveedoresDAL
    {

        public ProveedoresObj RegistrarProveedor(ProveedoresObj proveedores)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    Proveedor obj = new Proveedor();
                    obj.nombre = proveedores.nombre;
                    obj.direccion = proveedores.direccion;
                    obj.telefono = proveedores.telefono;
                    obj.email = proveedores.email;
                    obj.idEstado = 1;
                    context.Proveedor.Add(obj);
                    context.SaveChanges();
                    context.Dispose();

                    return proveedores;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public List<ProveedoresObj> ConsultarProveedores()

        {
            List<ProveedoresObj> resultado = new List<ProveedoresObj>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Proveedor
                                 select x).ToList();
                    foreach (var item in datos)
                    {
                        if (item.idEstado == 1)
                        {
                            resultado.Add(new ProveedoresObj
                            {

                                idProveedor = item.idProveedor,
                                nombre = item.nombre,
                                direccion = item.direccion,
                                telefono = item.telefono,
                                email = item.email
                            });
                        }
                    }
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    context.Dispose();
                    throw ex;
                }
            }
        }
        public List<SelectListItem> ConsultarProveedoresCombo()
        {
            List<SelectListItem> resultado = new List<SelectListItem>();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Proveedor
                                 select x).ToList();

                    resultado.Add(new SelectListItem
                    {
                        Value = "0",
                        Text = "Seleccione"
                    });

                    foreach (var item in datos)
                    {
                        if (item.idEstado == 1)
                        {
                            resultado.Add(new SelectListItem
                            {
                                Value = item.idProveedor.ToString(),
                                Text = item.nombre

                            });
                        }
                    }
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    context.Dispose();

                    throw ex;
                }
            }
        }

        public ProveedoresObj ConsultarProveedorEspecifico(int idProveedor)
        {
            ProveedoresObj resultado = new ProveedoresObj();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var datos = (from x in context.Proveedor
                                 where x.idProveedor == idProveedor
                                 select x).FirstOrDefault();

                    resultado.idProveedor = datos.idProveedor;
                    resultado.nombre = datos.nombre;
                    resultado.direccion = datos.direccion;
                    resultado.telefono = datos.telefono;
                    resultado.email = datos.email;
                    context.Dispose();
                    return resultado;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    context.Dispose();
                    throw ex;
                }
            }
        }

        public ProveedoresObj ActualizarProveedores(ProveedoresObj proveedor)
        {
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.Proveedor
                                     where x.idProveedor == proveedor.idProveedor
                                     select x).FirstOrDefault();
                    if (resultado != null)
                    {
                        resultado.idProveedor = proveedor.idProveedor;
                        resultado.nombre = proveedor.nombre;
                        resultado.direccion = proveedor.direccion;
                        resultado.telefono = proveedor.telefono;
                        resultado.email = proveedor.email;
                        resultado.idEstado = 1;
                        context.SaveChanges();
                        return proveedor;
                    }
                    return null;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }
        public ProveedoresObj BorrarProve(int idProveedor)
        {
            ProveedoresObj producto = new ProveedoresObj();
            using (var context = new DD_METALCOREEntities())
            {
                try
                {
                    var resultado = (from x in context.Proveedor
                                     where x.idProveedor == idProveedor
                                     select x).FirstOrDefault();

                    if (resultado != null)
                    {
                        resultado.idEstado = 2;
                        context.SaveChanges();

                        return producto;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    //modeloBitacora.RegistrarError(error);
                    throw ex;
                }
                finally
                {
                    context.Dispose();
                }
            }
        }


    }
}
