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
            //might be DOG
            ViewBag.Selected = "Dogs";

            IEnumerable<Dog> dogs = (IEnumerable<Dog>)TempData["Dogs"] ?? db.Dogs.ToList();

            return View(dogs);
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
        public ActionResult Create([Bind(Include = "DogID,Name,Age,Breed,Trained,Immune,Castrated,Gender,Size,Description,File")] Dog dog, HttpPostedFileBase File)
        {
            try
            {

                if (File != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(File.FileName));
                    File.SaveAs(path);
                    dog.File = File.FileName;
                }
                ViewBag.FileStatus = "File uploaded successfully.";
            }
            catch (Exception)
            {

                ViewBag.FileStatus = "Error while file uploading.";
            }
            if (ModelState.IsValid)
            {
                dog.GID = int.Parse(Session["GID"].ToString());
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
                return RedirectToAction("MyDogs");
            }
            //}
            return View(dog);//change to you dont have permissions
            
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
        public ActionResult Edit([Bind(Include = "DogID,GID,Name,Age,Breed,Trained,Immune,Castrated,Gender,Size,Description,File")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                var olddog = db.Dogs.Find(dog.DogID);
                dog.GID = olddog.GID;
                //db.Entry(dog).State = EntityState.Modified;
                db.Entry(olddog).CurrentValues.SetValues(dog);
                db.SaveChanges();
                return RedirectToAction("MyDogs");
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
            return RedirectToAction("MyDogs");
        }


        public ActionResult Contact(int? id)
        {
            Dog dog = db.Dogs.Find(id);
            
            if (dog == null)
            {
                return HttpNotFound();
            }
            Session["DogID"] = id.ToString();
            return RedirectToAction("Details", "FullGivers", new { id = dog.GID } );
        }


        [HttpGet]
        public ActionResult Search([Bind(Include = "Age,Breed,Gender")] Dog dog)
        {
            IEnumerable<Dog> dogs = db.Dogs.ToList();

            if (dog.Age.HasValue)
            {
                dogs = dogs.Where(d => d.Age == dog.Age);
            }

            if (!string.IsNullOrEmpty(dog.Breed))
            {
                dogs = dogs.Where(d => d.Breed.ToUpper().Contains(dog.Breed.ToUpper()));
            }

            if (dog.Gender != null)
            {
                dogs = dogs.Where(d => d.Gender.Equals(dog.Gender));
            }

            TempData["Dogs"] = dogs;

            return RedirectToAction("Index", "Dogs");
        }

        public ActionResult MyDogs()
        {
            try
            {
                IEnumerable<Dog> dogs = db.Dogs.ToList();
                int gid = int.Parse(Session["GID"].ToString());
                dogs = db.Dogs.Where(d => d.GID == gid).ToList();
                //TempData["Dogs"] = dogs;

                //return RedirectToAction("Index", "Dogs");
                return View(dogs);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

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
            var average = (from d in db.Dogs
                           group d by d.Breed into dogsGroup
                           select new
                           {
                               Breed = dogsGroup.Key,
                               Average = dogsGroup.Average(a=> a.Age)
                           }).ToArray(); 

            return Json(average, JsonRequestBehavior.AllowGet);
        }


    }

}
