using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models.Entity;
using Mvc.Repositories;
namespace Mvc.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);

            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim t)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaGetir");
            }
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Tarih = t.Tarih;
            sertifika.Aciklama = t.Aciklama;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim t)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaEkle");
            }
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var srt = repo.Find(x => x.ID == id);
            repo.TDelete(srt);
            return RedirectToAction("Index");
        }
    }
}