using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNexus.ReferecniaServicioCliente;
using Rotativa;

namespace ProyectoNexus.Controllers
{
    public class ClienteController : Controller
    {
        
        IServicioClienteClient proxy = new IServicioClienteClient();
        public ActionResult Cliente()
        {
            return View(proxy.Cliente());
        }


        public ActionResult ClientesPorNombre(string nombre)
        {

            ViewBag.nombre = nombre;
            return View(proxy.ClientePorNombre(nombre));
        }

        public ActionResult AgregarCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarCliente(CCliente reg)
        {
            string msj = proxy.agregarCliente(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Cliente");
        }


        public ActionResult ModificarCliente(int id)
        {
            CCliente reg = proxy.ClientePorId(id);
            return View(reg);

        }
        [HttpPost]
        public ActionResult ModificarCliente(CCliente reg)
        {
            string msj = proxy.actualizarCliente(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Cliente");
        }
        public ActionResult EliminarCliente(int? id)
        {
            CCliente reg = proxy.ClientePorId((int)id);

            return View(reg);
        }

        [HttpPost]
        public ActionResult EliminarCliente(int id)
        {
            string msj = proxy.eliminarCliente(id);
            ViewBag.msj = msj;
            return RedirectToAction("Cliente");
        }
        public ActionResult ReporteCliente()
        {
            return new ActionAsPdf("Cliente", new { nombre = "Cliente" })
            {
                FileName = "Cliente.pdf"
            };
        }

    }
}