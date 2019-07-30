using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UGetADog.Models;



namespace UGetADog.Controllers
{
    public class UsersController : Controller
    {
        private UGetADogContext db = new UGetADogContext();

        // GET: Users
        public ActionResult Index()
        {
            try
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    return View(db.Users.ToList());
                }
                else
                {
                    return RedirectToAction("MyAccount", "Users");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult MyAccount()
        {
            try
            {
                IEnumerable<User> users = db.Users.ToList();
                int id = int.Parse(Session["ID"].ToString());
                users = db.Users.Where(d => d.UserID == id).ToList();
                //TempData["Dogs"] = dogs;

                //return RedirectToAction("Index", "Dogs");
                return View(users);
            }
            catch
            {
                return RedirectToAction("Index", "Home");

            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (Session["ID"].ToString() == id.ToString())
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
                else
                {
                    return RedirectToAction("MyAccount", "Users");
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
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
                if (user.Role.ToString() == "Giver")
                {
                    return RedirectToAction("Create", "Givers");
                }
                return RedirectToAction("MyAccount", "Users");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if(Session["ID"].ToString()==id.ToString())
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
                else
                {
                    return RedirectToAction("MyAccount", "Users");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

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
                Session["Role"] = user.Role.ToString();
                if (user.Role.ToString() == "Giver")
                {
                    int id = int.Parse(Session["GID"].ToString());
                    string path = "Edit/" + id;
                    return RedirectToAction(path, "Givers");
                }
                return RedirectToAction("MyAccount", "Users");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (Session["ID"].ToString() == id.ToString())
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
                else
                {
                    return RedirectToAction("MyAccount", "Users");
                }

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
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
                    if (v.Role.ToString() == "Giver")
                    {
                    var g = db.Givers.Where(b => b.UID.Equals(v.UserID)).FirstOrDefault();
                    Session["Address"]= g.Address.ToString();
                    Session["GID"] = g.GiverID.ToString();
                    }

                FormsAuthentication.SetAuthCookie(user.Email, false);

                return RedirectToAction("MyAccount", "Users");
            }


            return View(); //change for error view
        }

        [HttpGet]
        public bool IsUserAdmin(HttpSessionStateBase session)
        {
            bool IsUserAdmin = false;
            if (session["Role"].ToString() == "Admin")
            {
                IsUserAdmin = true;
            }
            return IsUserAdmin;
        }

        [HttpGet]
        public bool IsUserGiver(HttpSessionStateBase session)
        {
            bool IsUserGiver = false;
            if (Session["Role"].ToString() == "Giver")
            {
                IsUserGiver = true;
            }
            return IsUserGiver;
        }
    }
}
