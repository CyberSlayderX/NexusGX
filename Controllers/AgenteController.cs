using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNexus.ServicioAgente;
using Rotativa;

namespace ProyectoNexus.Controllers
{
    public class AgenteController : Controller
    {
        IServicioAgenteClient proxy = new IServicioAgenteClient();
        // GET: Agente
        public ActionResult Agente()
        {

            return View(proxy.Agente());
        }
        public ActionResult AgentePorNombre(string nombre)
        {

            ViewBag.nombre = nombre;
            return View(proxy.AgentePorNombre(nombre));
        }

        public ActionResult agregarAgente()
        {
            return View();
        }

        [HttpPost]

        public ActionResult agregarAgente(CAgente reg)
        {

            string msj = proxy.agregarAgente(reg);
            ViewBag.msj = msj;

            return RedirectToAction("Agente");
        }

        public ActionResult ModificarAgente(int id)
        {
            CAgente reg = proxy.AgentePorId(id);

            return View(reg);
        }

        [HttpPost]
        public ActionResult ModificarAgente(CAgente reg)
        {

            string msj = proxy.actualizarAgente(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Agente");
        }


        public ActionResult EliminarAgente(int? id)
        {

            CAgente reg = proxy.AgentePorId((int)id);
            return View(reg);
        }
        [HttpPost]
        public ActionResult EliminarAgente(int id)
        {

            string msj = proxy.eliminarAgente(id);
            ViewBag.msj = msj;
            return RedirectToAction("Agente");

        }
        public ActionResult Reporte()
        {
            return new ActionAsPdf("Agente",new {nombre="Agente"}) {
            FileName="Agente.pdf"
            };
        }

    }
}