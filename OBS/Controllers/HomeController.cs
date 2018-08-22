using OBS.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OBS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        SisdbEntities db = new SisdbEntities();
        SisdbEntities1 db2 = new SisdbEntities1();
        public ActionResult Index()
        {            
          return RedirectToAction("Login", "Security");
        }
        public ActionResult Anasayfa()
        {
            var model = db2.Kullanıcılar.FirstOrDefault(x => x.k_no == HttpContext.User.Identity.Name);
            ViewBag.seviye = model.k_seviye;
            return View("Index");
        }
        public ActionResult Anasayfa2()
        {
            var model = db2.Kullanıcılar.FirstOrDefault(x => x.k_no == HttpContext.User.Identity.Name);
            ViewBag.seviye = model.k_seviye;
            return View("OgrIndex");
        }
        public ActionResult KulProfil()
        {
            var model = db2.Kullanıcılar.FirstOrDefault(x=>x.k_no==HttpContext.User.Identity.Name);
            return View(model);
        }
        public ActionResult Ayarlar()
        {
            var model = db2.Kullanıcılar.FirstOrDefault(x => x.k_no == HttpContext.User.Identity.Name);
            return View(model);
        }
        [HttpPost]
        public ActionResult Ayarlar(Kullanıcılar kullanıcı)
        {

            var model = db2.Kullanıcılar.Find(kullanıcı.k_sifre);
            model.k_no = kullanıcı.k_no;
            model.k_seviye = kullanıcı.k_seviye;
            model.k_sifre = kullanıcı.k_sifre;
            db2.SaveChanges();
            if (kullanıcı.k_seviye=="Ogrenci")
            {
              return  RedirectToAction("AnaSayfa2", "Home");
            }
            else if (kullanıcı.k_seviye=="Akademisyen")
            {
             return   RedirectToAction("AnaSayfa", "Home");

            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}