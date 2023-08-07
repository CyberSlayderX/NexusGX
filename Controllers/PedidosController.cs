using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNexus.ReferenciaServicioPedidos;
using Rotativa;

namespace ProyectoNexus.Controllers
{
    public class PedidosController : Controller
    {

        IServicioPedidosClient proxy = new IServicioPedidosClient();
        // GET: Pedidos
        public ActionResult Pedidos()
        {
            return View(proxy.Pedidos());
        }


        public ActionResult PedidosPorNombre(string nombre)
        {

            ViewBag.nombre = nombre;
            return View(proxy.PedidosPorNombre(nombre));
        }

        public ActionResult AgregarPedido()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarPedido(CPedidos reg)
        {
            string msj = proxy.agregarPedidos(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Pedidos");
        }


        public ActionResult ModificarPedido(int id)
        {
            CPedidos reg = proxy.PedidosPorId(id);
            return View(reg);

        }
        [HttpPost]
        public ActionResult ModificarPedido(CPedidos reg)
        {
            string msj = proxy.actualizarPedidos(reg);
            ViewBag.msj = msj;
            return RedirectToAction("Pedidos");
        }
        public ActionResult EliminarPedido(int? id)
        {
            CPedidos reg = proxy.PedidosPorId((int)id);

            return View(reg);
        }

        [HttpPost]
        public ActionResult EliminarPedido(int id)
        {
            string msj = proxy.eliminarPedidos(id);
            ViewBag.msj = msj;
            return RedirectToAction("Pedidos");
        }
        public ActionResult ReportePedidos()
        {
            return new ActionAsPdf("Pedidos", new { nombre = "Pedidos" })
            {
                FileName = "Pedidos.pdf"
            };
        }

    }
}