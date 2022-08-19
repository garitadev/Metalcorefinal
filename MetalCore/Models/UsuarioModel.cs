using Newtonsoft.Json;
//using SB_Admin.Entities;
using MetalCore.ETL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using MetalCore.BLL.Models;
using MetalCore.BLL.Passwords;

namespace SB_Admin.Models
{
    public class UsuarioModel
    {
        string ruta = ConfigurationManager.AppSettings["RutaApi"].ToString();


        public UsuarioObj ValidarCrenciales(UsuarioObj usuario)
        {
            UsuarioBLL BLL = new UsuarioBLL();
            var respuesta = BLL.ValidarCredenciales(usuario);
            return (respuesta);
        }

        //verifica la existencia del usuario
        public bool VerifiExistencia(string Email, string Cedula)
        {
            try
            {
                UsuarioBLL BLL = new UsuarioBLL();
                return (BLL.VerifiExistencia(Email, Cedula));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //registrar usuario

        public UsuarioObj RegistrarUsuario(UsuarioObj Usuario, string token)
        {
            UsuarioBLL BLL = new UsuarioBLL();
            var respuesta = BLL.RegistrarUsuario(Usuario);
            return (respuesta);
        }


        public List<UsuarioObj> ConsultarTodosUsuarios(string token)
        {
            try
            {
                UsuarioBLL BLL = new UsuarioBLL();
                var listaUsuario = BLL.ConsultarUsuarios();

                if (listaUsuario != null)
                {
                    return listaUsuario;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        //consulta un usuario  en especifico

        public UsuarioObj ConsultarUsuarioEspecifico(int idUsuario)
        {
            try
            {
                UsuarioBLL BLL = new UsuarioBLL();
                var respuesta = BLL.ConsultarUsuarioEspecifico(idUsuario);
                return (respuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //hace la consulta a los roles que se encuentran en la BD
        public List<SelectListItem> ConsultarRolesCombo()
        {
            try
            {
                UsuarioBLL BLL = new UsuarioBLL();
                return (BLL.ConsultarRolesCombo());
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
                UsuarioBLL BLL = new UsuarioBLL();
                return (BLL.ConsultarEstadosCombo());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ActuaUsuario(UsuarioObj Actua)
        {
            try
            {
                UsuarioBLL BLL = new UsuarioBLL();
                var usuarioAct = BLL.ActuaUsuario(Actua);
                if (usuarioAct !=null)
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

        public bool ValidarExistenciaEmail(RecoveryPassword obj)
        {
            try
            {
                UsuarioBLL BLL = new UsuarioBLL();

                return (BLL.ValidarExistenciaEmail(obj.Email));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerarTokenPassword(RecoveryPassword obj)
        {
            try
            {
                RecoveryPasswordBLL BLL = new RecoveryPasswordBLL();
                //SendEmail(obj.Email, obj.token);
                var generate = BLL.GenerarTokenPassword(obj);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RecoveryPassword RestablecerPassword(RecoveryPassword obj)
        {
            try
            {
                RecoveryPasswordBLL BLL = new RecoveryPasswordBLL();
                var user = BLL.RestablecerPassword(obj);

                if (user!=null)
                {
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
        
       