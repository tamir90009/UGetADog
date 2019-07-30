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
    public class MLsController : Controller
    {
        private UGetADogContext db = new UGetADogContext();

        // GET: MLs
        public ActionResult Index()
        {
            return View(db.MLs.ToList());
        }

        // GET: MLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ML mL = db.MLs.Find(id);
            if (mL == null)
            {
                return HttpNotFound();
            }
            return View(mL);
        }

        // GET: MLs/Create
         public ActionResult Create()
         {

             return View();
         }

        public ActionResult Create(int UserID, int DogID, Double Age, DogGender? Gender, string FirstName, String Breed)
        {
            ML mL= new ML();
            mL.UserID = UserID;
            mL.DogID = DogID;
            mL.Age = Age;
            mL.Gender = Gender;
            mL.FirstName = FirstName;
            mL.Breed = Breed;
            
            db.MLs.Add(mL);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // POST: MLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "UserID,DogID,Age,Gender,FirstName,Breed")] ML mL)
          {
              if (ModelState.IsValid)
              {
                  db.MLs.Add(mL);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }

              return View(mL);
          }*/

        // GET: MLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ML mL = db.MLs.Find(id);
            if (mL == null)
            {
                return HttpNotFound();
            }
            return View(mL);
        }

        
        public Dictionary<string,double> Calc(int ? Session_id )
        {
            // var curr_user = int.Parse(Session["ID"].ToString());
            var current_user_id = Session_id;
            //int numberOfML = db.MLs.ToList().Count();
            int numberOfML = db.MLs.GroupBy(b => b.Breed).Count();
            Dictionary<string, double> breedFit = new Dictionary<string, double>();
            var breed_types = db.MLs.GroupBy(b => b.Breed).ToList(); 
            foreach (var breed in breed_types)
            {
                if(!breedFit.ContainsKey(breed.ToString()))
                    {
                     breedFit.Add((breed.Key).ToString(), 0);
                    }
                
            }
            var all_rows = db.MLs.ToList();
           // int current_user_id = int.Parse(Session["ID"].ToString());
            var currentuser = db.Users.Find(current_user_id);
            if(currentuser != null)
            {
                
                var ids = db.MLs.Select(b => b.ML_ID).ToList();
                double sum_comapre = 0;
                foreach (var id in ids)
                {
                    //var age= (from m in DB.MLs )
                    var entity_ml = db.MLs.Find(id);
                    double compare_pre = 0;
                    if(entity_ml.Gender == currentuser.Gender)
                    {
                        compare_pre += 33;
                        sum_comapre += 33;
                    }
                    if (entity_ml.FirstName == currentuser.FirstName)
                    {
                        compare_pre += 33;
                        sum_comapre += 33;
                    }
                    compare_pre += (34 - ((34 / 100) * Math.Abs(currentuser.Age - entity_ml.Age)));
                    sum_comapre += (34 - ((34 / 100) * Math.Abs(currentuser.Age - entity_ml.Age)));
                    breedFit[entity_ml.Breed] += compare_pre;
                }
                foreach (var breed in breed_types)
                {
                    if (breedFit.ContainsKey((breed.Key).ToString()))
                    {
                        breedFit[(breed.Key).ToString()] = ((breedFit[(breed.Key).ToString()] )/ sum_comapre)*100; 
                    }

                }


            }


            return breedFit ;
        }

        // POST: MLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,DogID,Age,Gender,FirstName,Breed")] ML mL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mL);
        }

        // GET: MLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ML mL = db.MLs.Find(id);
            if (mL == null)
            {
                return HttpNotFound();
            }
            return View(mL);
        }

        // POST: MLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ML mL = db.MLs.Find(id);
            db.MLs.Remove(mL);
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
