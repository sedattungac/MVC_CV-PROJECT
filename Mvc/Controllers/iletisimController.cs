using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models.Entity;
using Mvc.Repositories;
namespace Mvc.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
        public ActionResult MesajSil(int id)
        {
            var msj = repo.Find(x => x.ID == id);
            repo.TDelete(msj);
            return RedirectToAction("Index");
        }
    }
}