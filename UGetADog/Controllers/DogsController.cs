using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        public ActionResult Create([Bind(Include = "DogID,Name,Age,Breed,Trained,Immune,Castrated,Gender,Size,Description,Image")] Dog dog)
        {
            //UsersController loginController = new UsersController();
            //if (loginController.IsUserAdmin(Session) | loginController.IsUserGiver(Session))
            //{
            if (ModelState.IsValid)
            {
                //dog.GID = int.Parse(Session["ID"].ToString());
                //dog.DogID = int.Parse(Session["ID"].ToString());
                dog.GID = 6;
                dog.DogID = 1;
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //}
            return View(dog);//change to you dont have permissions

            /*return RedirectToAction("login", "Admins");
            if (ModelState.IsValid)
            {
                dog.GID = 6;
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dog);*/
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
        public ActionResult Edit([Bind(Include = "DogID,Name,Age,Breed,Trained,Immune,Castrated,Gender")] Dog dog)
        {
            if (ModelState.IsValid)
            {
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

        public ActionResult AdminIndex()
        {
            //T.D.L:make that only admins will be able to see that page

            return View(db.Dogs.ToList());
        }

        public ActionResult GetDogsPerCity()
        {
            var status = (from d in db.Dogs
                          join g in db.Givers
                          on d.GID equals g.GiverID
                          group d by g.Address into dogsGroup
                          select new { City = dogsGroup.Key, Count = dogsGroup.Count() }).ToArray();
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAverageAgesPerBreed()
        {
            var average = (from d in db.Dogs group d by d.Breed into dogsGroup select new { Breed = dogsGroup.Key, Average = dogsGroup.Average(i => i.Age)}).ToArray();

            return Json(average, JsonRequestBehavior.AllowGet);
        }


    }
}
