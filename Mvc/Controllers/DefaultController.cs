using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbMVCcvEntities db = new DbMVCcvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        { var deneyimler=db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var deneyimler = db.TblEgitimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var deneyimler = db.TblYeteneklerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Hobilerim()
        {
            var deneyimler = db.TblHobilerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Sertifikalarim()
        {
            var deneyimler = db.TblSertifikalarim.ToList();
            return PartialView(deneyimler);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
           
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}