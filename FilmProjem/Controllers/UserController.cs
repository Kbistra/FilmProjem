using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using FilmProjem.DB;

namespace FilmProjem.Controllers
{
    public class UserController : Controller
    {
        FilmProjeDBEntities db = new FilmProjeDBEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KullaniciKayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciKayit(Kullanicilar kullanici)
        {
            var dbKullanici = db.Kullanicilar.Where(x => x.Eposta == kullanici.Eposta).FirstOrDefault();
            if (dbKullanici == null)
            {
                db.Kullanicilar.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Login", "User");

            }
            return View(kullanici);

            //return View(kullanici);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar kullanici)
        {
           var dbkullanici = db.Kullanicilar.Where(x => x.Eposta == kullanici.Eposta && x.Şifre == kullanici.Şifre).FirstOrDefault();
           if (dbkullanici != null)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View(kullanici);

            }
        }
    }

}




