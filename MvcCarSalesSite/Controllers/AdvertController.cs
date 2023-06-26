using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCarSalesSite.Models;

namespace MvcCarSalesSite.Controllers
{
    public class AdvertController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Advert
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var adverts = db.Adverts.Where(x=>x.Username == username).Include(a => a.City).Include(a => a.Model).Include(a => a.Status);
            return View(adverts.ToList());
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

        // GET: Advert/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advert advert = db.Adverts.Find(id);
            if (advert == null)
            {
                return HttpNotFound();
            }
            return View(advert);
        }

        // GET: Advert/Create
        public ActionResult Create()
        {
            ViewBag.brdlist = new SelectList(BringBrand(), "BrandID", "BrandName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName");
            return View();
        }

        public ActionResult Images(int id)
        {
            var advert = db.Adverts.Where(x => x.AdvertID == id).ToList();
            var imgs = db.Pictures.Where(x=>x.AdvertID == id).ToList();
            ViewBag.imgs = imgs;
            ViewBag.advert = advert;
            return View();
        }

        [HttpPost]
        public ActionResult Images(int id, HttpPostedFileBase file)
        {
            string path = Path.Combine("/Content/images/" + file.FileName);
            file.SaveAs(Server.MapPath(path));
            Picture pct = new Picture();
            pct.PictureName = file.FileName.ToString();
            pct.AdvertID = id;
            db.Pictures.Add(pct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Advert/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvertID,AdvertNo,Description,Price,AdvertDate,Kilometer,ModelYear,FuelType,GearType,Username,Phone,StatusID,BrandID,ModelID,CityID")] Advert advert)
        {
            if (ModelState.IsValid)
            {
                advert.Username = User.Identity.Name;
                db.Adverts.Add(advert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brdlist = new SelectList(BringBrand(), "BrandID", "BrandName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", advert.CityID);           
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", advert.StatusID);
            return View(advert);
        }

        // GET: Advert/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advert advert = db.Adverts.Find(id);
            if (advert == null)
            {
                return HttpNotFound();
            }
            ViewBag.brdlist = new SelectList(BringBrand(), "BrandID", "BrandName");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", advert.CityID);
            ViewBag.ModelID = new SelectList(db.Models, "ModelID", "ModelName", advert.ModelID);
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", advert.StatusID);
            return View(advert);
        }

        // POST: Advert/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvertID,AdvertNo,Description,Price,AdvertDate,Kilometer,ModelYear,FuelType,GearType,Username,Phone,StatusID,BrandID,ModelID,CityID")] Advert advert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName", advert.CityID);
            ViewBag.brdlist = new SelectList(BringBrand(), "BrandID", "BrandName");
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", advert.StatusID);
            return View(advert);
        }

        // GET: Advert/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advert advert = db.Adverts.Find(id);
            if (advert == null)
            {
                return HttpNotFound();
            }
            return View(advert);
        }

        // POST: Advert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advert advert = db.Adverts.Find(id);
            db.Adverts.Remove(advert);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
