using MvcCarSalesSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcCarSalesSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {          
            return View();
        }

        public ActionResult AdvertList()
        {
            var advert = db.Adverts.Include(x => x.Model).Include(x => x.Status).Include(x => x.City).ToList();
            return View(advert);
        }
    }
}