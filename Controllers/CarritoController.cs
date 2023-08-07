using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNexus.Models;
using System.Data.SqlClient;
using System.Data;
using ProyectoNexus.Models;
namespace ProyectoNexus.Controllers
{
    public class CarritoController : Controller
    {
        PROYECTONEXUSGXEntities db = new PROYECTONEXUSGXEntities();
        
        public ActionResult Productos()
        { if (Session["carrito"] == null)
            {
                List<tb_productos> detalle = new List<tb_productos>();
                Session["carrito"] = detalle;
            }
            return View(db.tb_productos.ToList());
        }


       
       

       

       
    }


}