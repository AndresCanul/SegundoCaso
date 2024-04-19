using CasoEstudio2Web.Entidades;
using CasoEstudio2Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasoEstudio2Web.Controllers
{
    public class CasasController : Controller
    {   
        
         CasasModel modelo = new CasasModel();
        
         [HttpGet]
         public ActionResult ConsultarCasas()
         {
             var respuesta = modelo.ConsultarCasas();

             if (respuesta.Codigo == 0)
                 return View(respuesta.Datos);
             else
             {
                 ViewBag.MsjPantalla = respuesta.Detalle;
                 return View(new List<Casa>());
             }
         }
        
         [HttpGet]
         public ActionResult ConsultarCasa(long IdCasa)
         {
                var respuesta = modelo.ConsultarCasa(IdCasa);

                if (respuesta.Codigo == 0)
                {
                    return Json(respuesta.Dato, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(respuesta.Detalle, JsonRequestBehavior.AllowGet);
                }
         }
        
         [HttpGet]
         public ActionResult AlquilarCasa()
            {
                CargarListaCasas();
                return View();
            }
        
         [HttpPost]
         public ActionResult AlquilarCasa(Casa entidad)
         {
                var respuesta = modelo.AlquilarCasa(entidad);

                if (respuesta.Codigo == 0)
                {
                    return RedirectToAction("AlquilarCasa", "Casas");
                }
                else
                {
                    CargarListaCasas();
                    ViewBag.MsjPantalla = respuesta.Detalle;
                    return View();
                }
         }
        
         private void CargarListaCasas()
         {
                var respuesta = modelo.ListaCasas();
                var listaCasas = new List<SelectListItem>();

                listaCasas.Add(new SelectListItem { Text = "Seleccione...", Value = "" });

                if (respuesta.Datos != null)
                {
                       foreach (var item in respuesta.Datos)
                       listaCasas.Add(new SelectListItem { Text = item.DescripcionCasa, Value = item.IdCasa.ToString() });
                }

                ViewBag.listaCasas = listaCasas;               
         }
        
    }
}
