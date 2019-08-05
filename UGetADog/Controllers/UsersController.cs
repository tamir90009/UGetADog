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
                return RedirectToAction("login", "Users");
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
                if (Session["Role"].ToString() == "Admin")
                {
                    goto CanDetails;
                }
                if (Session["ID"].ToString() == id.ToString())
                {
                    goto CanDetails;
                }
                else
                {
                    return RedirectToAction("MyAccount", "Users");
                }
            CanDetails:
                if (id == null)
                {
                    return RedirectToAction("MyAccount", "Users");
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);

            }
            catch
            {
                return RedirectToAction("login", "Users");
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            Session["From"] = "Create";
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
                try
                {
                    if(Session["Role"].ToString() == "Admin")
                    {
                        goto PassSessionInsert;
                    }
                }
                catch
                {
                    
                }
                Session["user"] = user.FirstName.ToString() + " " + user.LastName.ToString();
                Session["ID"] = user.UserID.ToString();
                Session["Role"] = user.Role.ToString();
            PassSessionInsert:
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
                Session["From"] = "Edit";
                Session["EditedUser"] = id;
                if (Session["ID"].ToString()==id.ToString() || Session["Role"].ToString() == "Admin")
                {
                    if (id == null)
                    {
                        return RedirectToAction("MyAccount", "Users");
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
                return RedirectToAction("login", "Users");
            }

        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Email,Password,FirstName,LastName,Age,Gender,Role")] User user)
        {

            try
            {
                
                if (Session["ID"].ToString() == user.UserID.ToString() || Session["Role"].ToString() == "Admin")
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
                else
                {
                    return RedirectToAction("MyAccount", "Users");
                }
            }
            catch
            {
                return RedirectToAction("login", "Users");
            }

        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    goto CanDelete;
                }
                if (Session["ID"].ToString() == id.ToString())
                {
                    goto CanDelete;
                }
                else
                {
                    return RedirectToAction("login", "Users");
                }
            CanDelete:
                if (id == null)
                {
                    return RedirectToAction("MyAccount", "Users");
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);

            }
            catch
            {
                return RedirectToAction("login", "Users");
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
                if (v.Role.ToString() == "Giver" || v.Role.ToString() == "Admin")
                {
                    var g = db.Givers.Where(b => b.UID.Equals(v.UserID)).FirstOrDefault();
                    if (g != null)
                    {
                        Session["Address"] = g.Address.ToString();
                        Session["GID"] = g.GiverID.ToString();
                    }

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

        [HttpPost]
        public JsonResult IsAlreadySigned(string Email)
        {
            if (Session["From"].ToString() == "Create")
            {
                return Json(IsUserAvailable(Email));
            }
            else
            {
                return Json(IsUserAvailableEdit(Email));
            }
        }

        public bool IsUserAvailable(string EmailId)
        {
            // Assume these details coming from database  
            IEnumerable<User> users = db.Users.ToList();

            var RegEmailId = (from u in users
                              where u.Email.ToUpper() == EmailId.ToUpper()
                              select new { EmailId }).FirstOrDefault();

            bool status;
            if (RegEmailId != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }

            return status;
        }
        public bool IsUserAvailableEdit(string EmailId)
        {
            // Assume these details coming from database  
            IEnumerable<User> users = db.Users.ToList();

            User user = db.Users.Find(Session["EditedUser"]);
            if (EmailId.ToString().ToUpper() == user.Email.ToString().ToUpper())
            {
                //Available to use  
                return true;
            }

            var RegEmailId = (from u in users
                              where u.Email.ToUpper() == EmailId.ToUpper()
                              select new { EmailId }).FirstOrDefault();

            bool status;
            if (RegEmailId != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }
            

            return status;
        }
    }
}
