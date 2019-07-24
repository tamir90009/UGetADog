using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UGetADog.Models;



namespace UGetADog.Controllers
{
    public class UsersController : Controller
    {
        private UGetADogContext db = new UGetADogContext();

        // GET: Users
        public ActionResult Index()
        {
                return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Email,Password,FirstName,LastName,Age,Gender,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                Session["user"] = user.FirstName.ToString() + " " + user.LastName.ToString();
                Session["ID"] = user.UserID.ToString();
                Session["Role"] = user.Role.ToString();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Email,Password,FirstName,LastName,Age,Gender,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        // GET: Login
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login([Bind(Include ="Email,Password")] User user)
        {
            //add try and catch
                var v = db.Users.Where(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["user"] = v.FirstName.ToString()+" "+v.LastName.ToString();
                    Session["ID"] = v.UserID.ToString();
                    Session["Role"] = v.Role.ToString();
                    if (v.Role.ToString() == "GIVER")
                    {
                    var g = db.Givers.Where(b => b.UID.Equals(v.UserID)).FirstOrDefault();
                    Session["Address"]= g.Address.ToString();
                    Session["GID"] = g.GiverID.ToString();
                    }

                return RedirectToAction("Index", "Dogs");
                }
            return View(); //change for error view
        }

        [HttpGet]
        public bool IsUserAdmin(HttpSessionStateBase session)
        {
            bool IsUserAdmin = false;
            if (session["Role"].ToString() == "ADMIN")
            {
                IsUserAdmin = true;
            }
            return IsUserAdmin;
        }

        [HttpGet]
        public bool IsUserGiver(HttpSessionStateBase session)
        {
            bool IsUserGiver = false;
            if (Session["Role"].ToString() == "GIVER")
            {
                IsUserGiver = true;
            }
            return IsUserGiver;
        }
    }
}
