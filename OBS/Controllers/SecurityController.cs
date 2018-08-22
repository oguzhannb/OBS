using OBS.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OBS.Controllers
{
    
    public class SecurityController : Controller
    {
        // GET: Security
        SisdbEntities1 db = new SisdbEntities1();
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanıcılar kullanıcı,string GirisSec)
        {
            var varmi = db.Kullanıcılar.FirstOrDefault(x => x.k_no == kullanıcı.k_no && x.k_sifre == kullanıcı.k_sifre && x.k_seviye==GirisSec);
            if (varmi!=null && varmi.k_seviye=="Akademisyen")
            {              
                FormsAuthentication.SetAuthCookie(varmi.k_no, true);
                return RedirectToAction("Anasayfa", "Home");
               
            }
            else if (varmi != null && varmi.k_seviye == "Ogrenci")
            {            
                FormsAuthentication.SetAuthCookie(varmi.k_no, true);
                return RedirectToAction("Anasayfa2","Home");
               
            }
            ViewBag.Message = "Geçersiz Kullanıcı Adı veya Şifre!";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}