using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;
namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c=new Context();

        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
          
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir",bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik=b.Baslik;
            blg.BlogImage= b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult MesajListesi()
        {
            var mesajlar = c.iletisims.ToList();
            return View(mesajlar);
        }
        public ActionResult MesajSil(int id)
        {
            var m = c.iletisims.Find(id);
            c.iletisims.Remove(m);
            c.SaveChanges();
            return RedirectToAction("MesajListesi");
        }
        public ActionResult MesajGetir(int id)
        {
            var il = c.iletisims.Find(id);
            return View("MesajGetir", il);
        }
        public ActionResult HakkimdaListe()
        {
            var hakkimda = c.Hakkimdas.ToList();
            return View(hakkimda);
        }
        public ActionResult HakkimdaBul(int id)
        {
            var hk = c.Hakkimdas.Find(id);
            return View("HakkimdaBul", hk);
        }
        public ActionResult HakkimdaGetir(Hakkimda h)
        {
            var hak = c.Hakkimdas.Find(h.ID);
            hak.FotoUrl = h.FotoUrl;
            hak.Aciklama = h.Aciklama;
            c.SaveChanges();
            return RedirectToAction("HakkimdaListe");
        }

    }
}