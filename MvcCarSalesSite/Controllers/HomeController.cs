using MvcCarSalesSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcCarSalesSite.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int page = 1)
        {
            var imgs = db.Pictures.ToList();
            ViewBag.imgs = imgs;
            var advert = db.Adverts.Include(m => m.Model).ToList().ToPagedList(page, 3);
            return View(advert);
        }

        public ActionResult MenuFilter(int id)
        {
            var imgs = db.Pictures.ToList();
            ViewBag.imgs = imgs;
            var filter = db.Adverts.Where(x => x.StatusID == id).Include(m => m.Model).Include(m => m.City).Include(m => m.Status).ToList();
            return View(filter);
        }

        public ActionResult Filter(int min, int max, int cityid, int statusid, int brandid, int modelid)
        {
            var imgs = db.Pictures.ToList();
            ViewBag.imgs = imgs;
            var filter = db.Adverts.Where(x => x.Price >= min && x.Price <= max && x.CityID == cityid && x.StatusID == statusid && x.BrandID == brandid && x.ModelID == modelid).Include(m => m.Model).Include(m => m.Status).Include(m => m.City).ToList();
            return View(filter);
        }

        public PartialViewResult FilterPartial()
        {
            ViewBag.brdlist = new SelectList(BringBrand(), "BrandID", "BrandName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName");
            return PartialView();
        }

        public List<Brand> BringBrand()
        {
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }

        public ActionResult BringModel(int BrandID)
        {
            List<Model> modellist = db.Models.Where(x => x.BrandID == BrandID).ToList();
            ViewBag.mdllist = new SelectList(modellist, "ModelID", "ModelName");
            return PartialView("ModelPartial");
        }

        public ActionResult Search(string q)
        {
            var img = db.Pictures.ToList();
            ViewBag.imgs = img;
            var find = db.Adverts.Include(m => m.Model);

            if (!string.IsNullOrEmpty(q))
            {
                find = find.Where(x => x.Description.Contains(q) || x.Model.ModelName.Contains(q)); 
            }
            return View(find.ToList());
        }

        public ActionResult Detail(int id)
        {
            var advert = db.Adverts.Where(x=>x.AdvertID == id).Include(m => m.Model).Include(m => m.Status).Include(m => m.City).FirstOrDefault();

            var imgs = db.Pictures.Where(x => x.AdvertID == id).ToList();

            ViewBag.imgs = imgs;
            return View(advert);
        }

        public PartialViewResult Slider()
        {
            var advert = db.Adverts.ToList().Take(5);
            var imgs = db.Pictures.ToList();
            ViewBag.imgs = imgs;
            return PartialView(advert);
        }

    }
}