using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UGetADog.Models;


namespace UGetADog.Controllers
{
    public class DogsController : Controller
    {
        private UGetADogContext db = new UGetADogContext();

        // GET: Dogs
        public ActionResult Index()
        {
            return View(db.Dogs.ToList());
        }

        // GET: Dogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // GET: Dogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DogID,Name,Age,Breed,Trained,Immune,Castrated,Gender,Size,Description,file")] Dog dog, HttpPostedFileBase file)
        {
            try
            {

                if (file != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    dog.file = file.FileName;
                }
                ViewBag.FileStatus = "File uploaded successfully.";
            }
            catch (Exception)
            {

                ViewBag.FileStatus = "Error while file uploading.";
            }
            if (ModelState.IsValid)
            {
                dog.GID = 1;
                db.Dogs.Add(dog);
                var giver = db.Givers.Find(dog.GID);
                if (giver.Dogs == null)
                {
                    giver.Dogs = new List<Dog>();
                    giver.Dogs.Add(dog);
                }
                else
                {
                    giver.Dogs.Add(dog);
                }
                
                db.Entry(giver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dog);
        }

        // GET: Dogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // POST: Dogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DogID,GID,Name,Age,Breed,Trained,Immune,Castrated,Gender,Size,Description,file")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                dog.GID = 1;
                db.Entry(dog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        // GET: Dogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // POST: Dogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dog dog = db.Dogs.Find(id);
            db.Dogs.Remove(dog);
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
