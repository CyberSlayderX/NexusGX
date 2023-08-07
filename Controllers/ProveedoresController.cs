using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNexus.ReferenciaServicioProveedores;
using Rotativa;

namespace ProyectoNexus.Controllers
{
    public class ProveedoresController : Controller
    {
        IServicioProveedoresClient proxy = new IServicioProveedoresClient(); 
        // GET: Proveedores
        public ActionResult Proveedor()
        {
            return View(proxy.Proveedores());
        }


        public ActionResult ProveedoresPorNombre(string nombre)
        {

            ViewBag.nombre = nombre;
            return View(proxy.PorveedoresPorNombre(nombre));
        }

        public ActionResult AgregarProveedores()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarProveedores(CProveedores reg)
        {
            string msj = proxy.agregarPorveedor(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Proveedores");
        }


        public ActionResult ModificarProveedores(int id)
        {
            CProveedores reg = proxy.ProveedorPorId(id);
            return View(reg);

        }
        [HttpPost]
        public ActionResult ModificarProveedores(CProveedores reg)
        {
            string msj = proxy.actualizarProveedor(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Proveedores");
        }
        public ActionResult EliminarProveedores(int? id)
        {
            CProveedores reg = proxy.ProveedorPorId((int)id);

            return View(reg);
        }

        [HttpPost]
        public ActionResult EliminarProveedores(int id)
        {
            string msj = proxy.eliminarPorveedor(id);
            ViewBag.msj = msj;
            return RedirectToAction("Proveedores");
        }
        public ActionResult ReporteProveedor()
        {
            return new ActionAsPdf("Proveedor", new { nombre = "Proveedor" })
            {
                FileName = "Proveedor.pdf"
            };
        }

    }
}