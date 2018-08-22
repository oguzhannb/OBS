using OBS.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OBS.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        SisdbEntities db = new SisdbEntities();
        SisdbEntities1 db2 = new SisdbEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OgrListele()
        {
            var modell = db2.Kullanıcılar.FirstOrDefault(x => x.k_no == HttpContext.User.Identity.Name);
            ViewBag.seviye = modell.k_seviye;
            var model = db.Ogrenciler.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult OgrEkle()
        {
            var model = db2.Kullanıcılar.FirstOrDefault(x => x.k_no == HttpContext.User.Identity.Name);
            ViewBag.seviye = model.k_seviye;
            return View("OgrForm", new Ogrenciler() {   });
        }
        [HttpPost]
        public ActionResult Kaydet(Ogrenciler ogr)
        {
            if (!ModelState.IsValid)
            {
                return View("OgrForm",ogr);
            }
            if (ogr.ogr_id==0)
            {
                db.Ogrenciler.Add(ogr);
                db.SaveChanges();
            }
            else
            {
                var ogrenci = db.Ogrenciler.Find(ogr.ogr_id);
                if (ogrenci!=null)
                {
                    ogrenci.ogr_isim = ogr.ogr_isim;
                    ogrenci.ogr_soyisim = ogr.ogr_soyisim;
                    ogrenci.ogr_yas = ogr.ogr_yas;
                    ogrenci.ogr_dogumtarih = ogr.ogr_dogumtarih;
                }
            }
            db.SaveChanges();
            return RedirectToAction("OgrListele","Ogrenci");
        }
        public ActionResult OgrGuncelle(int id) {
            var model = db.Ogrenciler.Find(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View("OgrForm",model);
        }
        public ActionResult OgrSil(int id)
        {
            var ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci==null)
            {
                return HttpNotFound();
            }
            db.Ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("OgrListele");
        }
        public ActionResult OgrNot()
        {
            var model = db2.Kullanıcılar.FirstOrDefault(x => x.k_no == HttpContext.User.Identity.Name);
            ViewBag.seviye = model.k_seviye;
            return View();
        }
        public ActionResult OgrDers()
        {
            var model = db2.Kullanıcılar.FirstOrDefault(x => x.k_no == HttpContext.User.Identity.Name);
            ViewBag.seviye = model.k_seviye;
            return View();
        }
    }
}