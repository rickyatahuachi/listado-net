using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using listadoNet.Models;

namespace listadoNet.Controllers
{
    public class HomeController : Controller
    {
            private BD_PRUEBAEntities1 db = new BD_PRUEBAEntities1();

        public ActionResult Index(string searchString)
        {
            var negocios = from s in db.negocios select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                negocios = negocios.Where(s => s.descripcion.Contains(searchString)
                                       || s.nombre.Contains(searchString));
            }
            return View(negocios.ToList());
        }

        public JsonResult ChangeFiltrar(string searchString)
        {
            var negocios = from s in db.negocios select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                negocios = negocios.Where(s => s.descripcion.Contains(searchString)
                                       || s.nombre.Contains(searchString));
            }

            List<negocios> ObjEmp = new List<negocios>();
            /* foreach (negocios in a)
            {
                ObjEmp.Add(a);
            }; */
            //return list as Json    
            return Json(negocios, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            negocios negocios = db.negocios.Find(id);
            if (negocios == null)
            {
                return HttpNotFound();
            }
            return View(negocios);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}