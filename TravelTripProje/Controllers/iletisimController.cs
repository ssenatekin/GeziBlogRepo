using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MesajEkle()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult MesajEkle(iletisim i)
        {
            c.iletisims.Add(i);
            c.SaveChanges();
            return View();
        }
    }
}