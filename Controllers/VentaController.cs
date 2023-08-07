using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNexus.ReferenciaServicioVenta;
using Rotativa;

namespace ProyectoNexus.Controllers
{
    public class VentaController : Controller
    {
        IServicIoVentaClient proxy = new IServicIoVentaClient();
        
        public ActionResult Venta()
        {
            return View(proxy.Venta());

        }


        public ActionResult VentaPorNombre(string nombre)
        {

            ViewBag.nombre = nombre;
            return View(proxy.VentaPorNombre(nombre));
        }

        public ActionResult AgregarVenta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarVenta(CVenta reg)
        {
            string msj = proxy.agregarVenta(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Venta");
        }


        public ActionResult ModificarVenta(int id)
        {
            CVenta reg = proxy.VentaPorId(id);
            return View(reg);

        }
        [HttpPost]
        public ActionResult ModificarVenta(CVenta reg)
        {
            string msj = proxy.actualizarVenta(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Venta");
        }
        public ActionResult EliminarVenta(int? id)
        {
            CVenta reg = proxy.VentaPorId((int)id);

            return View(reg);
        }

        [HttpPost]
        public ActionResult EliminarVenta(int id)
        {
            string msj = proxy.eliminarVenta(id);
            ViewBag.msj = msj;
            return RedirectToAction("Venta");
        }

        public ActionResult ReporteVenta()
        {
            return new ActionAsPdf("Venta", new { nombre = "Venta" })
            {
                FileName = "Venta.pdf"
            };
        }
    }
}