﻿
//using SB_Admin.Entities;
using MetalCore.ETL.Entities;
using SB_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SB_Admin.Controllers
{

    public class HomeController : Controller
    {
        //Aqui es el dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";
            //Consultar pendientes, caneldaos y terminados

            return View();
        }


        public ActionResult Dashboard()
        {

            DashboardModel model = new DashboardModel();
            DashboardModel curs = new DashboardModel();
            DashboardModel fina = new DashboardModel();
            DashboardModel cana = new DashboardModel();

            var resultado = model.TotalProductos();
            var curso = curs.TotalEncurso();
            var fin = fina.TotalFinalizado();
            var can = cana.TotalCancelado();


            ViewBag.enCurso = curso.TotalProductos;
            ViewBag.finalizado = fin.TotalProductos;
            ViewBag.cancelado = can.TotalProductos;
            ViewBag.totalProductos = resultado.TotalProductos;


            using (var client = new HttpClient())
            {
                if (Session["User"] != null)
                {
                    UsuarioObj user = (UsuarioObj)Session["User"];
                    ViewBag.listaPermisos = user.listaPermisos;
                    var token = user.TokenJWT;


                    return View();
                }
            }



            return View();
        }

        public JsonResult DataPastel()
        {

            GraficoModel model = new GraficoModel();
            var datos = model.GraficoTrabajos();



            return Json(datos, JsonRequestBehavior.AllowGet);

        }

        public JsonResult DataBarra()
        {

            GraficoModel model = new GraficoModel();
            var datos = model.GraficoProductos();



            return Json(datos, JsonRequestBehavior.AllowGet);

        }


        public ActionResult SinPermiso()
        {
            if (Session["User"] != null)
            {
                UsuarioObj user = (UsuarioObj)Session["User"];
                return View(user.listaPermisos);
                ViewBag.Message = "Su usuario no cuenta con permisos para ver esta pagina";

            }


            return View();
        }


        public ActionResult CerrarSesion()
        {
            //se cierra la sescion del usuario
            FormsAuthentication.SignOut();
            Session["Usuario"] = null;

            return RedirectToAction("Login", "Login");
        }
    }
}