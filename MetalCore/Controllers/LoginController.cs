//using SB_Admin.Entities;
using MetalCore.ETL.Entities;
using reCAPTCHA.MVC;
using SB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SB_Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public JsonResult AjaxEmail(string email)
        {
            UsuarioModel modelo = new UsuarioModel();
            UsuarioObj usuario = new UsuarioObj();
            usuario.email = email;

            if (modelo.ValidarExistenciaEmailUser(usuario) != null)
            {
                var respuesta = modelo.CantidadIntentos(usuario);

                if (respuesta == 3)
                {
                    return Json("El email ingresado no coincide con nuestro registros");
                    
                }
            }
            
            return (null);
        }

        [HttpPost]
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard", "Home");

        }

        [HttpPost]
        [CaptchaValidator]
        public ActionResult Validar(UsuarioObj usuario, bool captchaValid)
        {
            string email = usuario.email;
            string clave = usuario.password;
            string claveEncriptada = GetSha256(clave);

            UsuarioModel modelo = new UsuarioModel();
            var respuesta = modelo.ValidarCrenciales(usuario);

            var validarEmail = modelo.ValidarExistenciaEmailUser(usuario);
            
            if (validarEmail != null && modelo.CantidadIntentos(usuario).Equals(3))
            {
                ViewBag.propiedad = "disabled";
            }
            if (validarEmail != null &&  validarEmail.password != claveEncriptada)
            {
                int intentos = modelo.CantidadIntentosIncremt(usuario);
                
            }

            if (!captchaValid)
            {
                ViewBag.MsjError = "El Captcha es requerido para ingresar";
                return View("Login");
            }
            if (respuesta != null)
            {
                FormsAuthentication.SetAuthCookie(respuesta.email, false);

                //Se crea una nueva session (almacena toda la infomacion del usuario)
                Session["User"] = respuesta;


                return RedirectToAction("Dashboard", "Home");

            }
            else
            {
                ViewBag.MsjError = "Credenciales Invalidas";
                return View("Login");
            }

        }

        [HttpGet]
        //Cuando se recibe un correo para ingresar el nuevo password
        public ActionResult GenerarTokenPassword()
        {

            return View();
        }

        [HttpPost]
        [CaptchaValidator]
        //Cuando se recibe un correo para ingresar el nuevo password
        public ActionResult GenerarTokenPassword(RecoveryPassword modelo, bool captchaValid)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            if (!captchaValid)
            {
                ViewBag.MsjError = "El Captcha es requerido";
                return View();

            }
            //Se valida que el correo ingreado exista en los registros de la bd
            if (usuarioModel.ValidarExistenciaEmail(modelo)!=null)
            {
                usuarioModel.GenerarTokenPassword(modelo);
            }
            else
            {
                ViewBag.MjsEmail = "El email ingresado no coincide con nuestro registros";
                return View();

            }

            ViewBag.MjsEmailEnviado = "Se le ha envidado un correo para cambiar su contraseña";
            return View("Login");

        }


        [HttpGet]
        public ActionResult RestablecerPassword(string token)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            RecoveryPassword modelo = new RecoveryPassword();
            modelo.token = token;

            if (usuarioModel.RestablecerPassword(modelo) ==null)
            {
                ViewBag.Error = "Token Expirado";
                return View("Login");
            }

            return View(modelo);
        }

        [HttpPost]
        public ActionResult RestablecerPassword(RecoveryPassword model)
        {
            UsuarioModel usuarioModel = new UsuarioModel();

            if (usuarioModel.RestablecerPassword(model) != null)
            {
                ViewBag.Message = "Contraseña moficada con éxito";
                return View("Login");
            }

            return View(model);
        }

        private string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}