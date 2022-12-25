using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c=new Context();
        BlogYorum by = new BlogYorum();
        List<Blog> b = new List<Blog>();
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            //by.Deger3=c.Blogs.Take(3).ToList();
            b = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            //son eklenen blogları listeleme
            //by.Deger3 = b.Skip(Math.Max(0, b.Count() - 3)).Take(3).ToList();
            //sondan sıralama descending
            by.Deger3 = b.OrderByDescending(x =>x.ID).Take(3).ToList();
            return View(by); 
        }

        public ActionResult BlogDetay(int id)
        {
            //var blogbul=c.Blogs.Where(x=>x.ID==id).ToList();
            by.Deger1 = c.Blogs.Where(x=>x.ID==id).ToList();
            by.Deger2 = c.Yorumlars.Where(x=>x.Blogid==id).ToList();
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
       
    }
}