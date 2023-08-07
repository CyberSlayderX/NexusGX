using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNexus.ReferenciaServicioGerente;
using Rotativa;

namespace ProyectoNexus.Controllers
{
    public class GerenteController : Controller
    {

        IServicioGerenteClient proxy = new IServicioGerenteClient();
        // GET: Gerente
        public ActionResult Gerente()
        {
            return View(proxy.Gerente());
        }


        public ActionResult GerentePorNombre(string nombre)
        {

            ViewBag.nombre = nombre;
            return View(proxy.GerentePorNombre(nombre));
        }

        public ActionResult AgregarGerente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarGerente(CGerente reg)
        {
            string msj = proxy.agregarGerente(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Gerente");
        }


        public ActionResult ModificarGerente(int id)
        {
            CGerente reg = proxy.GerentePorId(id);
            return View(reg);

        }
        [HttpPost]
        public ActionResult ModificarGerente(CGerente reg)
        {
            string msj = proxy.actualizarGerente(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Gerente");
        }
        public ActionResult EliminarGerente(int? id)
        {
            CGerente reg = proxy.GerentePorId((int)id);

            return View(reg);
        }

        [HttpPost]
        public ActionResult EliminarGerente(int id)
        {
            string msj = proxy.eleiminarGerente(id);
            ViewBag.msj = msj;
            return RedirectToAction("Gerente");
        }

        public ActionResult ReporteGerente()
        {
            return new ActionAsPdf("Gerente", new { nombre = "Gerente" })
            {
                FileName = "Gerente.pdf"
            };
        }
    }
}