using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNexus.ReferenciaServicioAuto;
using Rotativa;

namespace ProyectoNexus.Controllers
{
    public class AutosController : Controller
    {
        IServicioAutosClient proxy = new IServicioAutosClient();


        public ActionResult Auto()
        {
            return View(proxy.Auto());
        }


        public ActionResult AutosPorNombre(string nombre)
        {

            ViewBag.nombre = nombre;
            return View(proxy.AutoPorNombre(nombre));
        }

        public ActionResult AgregarAutos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarAutos(CAuto reg)
        {
            string msj = proxy.agregarAuto(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Auto");
        }


        public ActionResult ModificarAutos(int id)
        {
            CAuto reg = proxy.AutoPorId(id);
            return View(reg);

        }
        [HttpPost]
        public ActionResult ModificarAutos(CAuto reg)
        {
            string msj = proxy.actualizarAuto(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Auto");
        }
        public ActionResult EliminarAutos(int? id)
        {
            CAuto reg = proxy.AutoPorId((int)id);

            return View(reg);
        }

        [HttpPost]
        public ActionResult EliminarAutos(int id)
        {
            string msj = proxy.eliminarAuto(id);
            ViewBag.msj = msj;
            return RedirectToAction("Auto");
        }
        public ActionResult ReporteAuto()
        {
            return new ActionAsPdf("Auto", new { nombre = "Auto" })
            {
                FileName = "Auto.pdf"
            };
        }


    }
}