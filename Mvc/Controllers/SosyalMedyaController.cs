using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models.Entity;
using Mvc.Repositories;

namespace Mvc.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var sosyalmedya = repo.List();
            return View(sosyalmedya);
        }
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya p)
        {
          
            repo.TAdd(p);
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SosyalMedyaGetir(TblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID ==p.ID);
            hesap.Ad = p.Ad;
            hesap.Link = p.Link;
            hesap.ikon = p.ikon;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaPasif(int id)
        {
            var hesap = repo.Find(x => x.ID ==id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaAktif(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = true;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaKaldir(int id)
        {
            var medya = repo.Find(x => x.ID == id);
            repo.TDelete(medya);
            return RedirectToAction("Index");
        }
    }
}