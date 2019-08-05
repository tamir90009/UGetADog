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
    public class GiversController : Controller
    {
        private UGetADogContext db = new UGetADogContext();

        // GET: Givers
        public ActionResult Index()
        {

            //might be with no s
            //ViewBag.Selected = "Givers";

            //IEnumerable<Giver> givers = (IEnumerable<Giver>)TempData["Givers"] ?? db.Givers.ToList();

            // return View(givers);

            try
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    return View(db.Givers.ToList());
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

        // GET: Givers/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    goto CanDetails;
                }
                if (Session["GID"].ToString() == id.ToString())
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
                Giver giver = db.Givers.Find(id);
                if (giver == null)
                {
                    return HttpNotFound();
                }
                return View(giver);
            }
            catch
            {
                return RedirectToAction("login", "Users");
            }
        }

        // GET: Givers/Create
        public ActionResult Create()
        {
            try
            {
                if (Session["ID"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("login", "Users");
                }
            }
            catch
            {
                return RedirectToAction("login", "Users");
            }

        }

        // POST: Givers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GiverID,Phone,Rating,Address,Latitude,Longtitude")] Giver giver)
        {
            if (ModelState.IsValid)
            {
                giver.UID = int.Parse(Session["ID"].ToString());
                db.Givers.Add(giver);
                db.SaveChanges();
                Session["Address"] = giver.Address.ToString();
                Session["GID"] = giver.GiverID.ToString();
                return RedirectToAction("MyAccount", "Users");
            }

            return View(giver);
        }

        // GET: Givers/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    goto CanEdit;
                }
                if (Session["GID"].ToString() == id.ToString())
                {
                    goto CanEdit;
                }
                else
                {
                    return RedirectToAction("MyAccount", "Users");
                }
            CanEdit:
                if (id == null)
                {
                    return RedirectToAction("MyAccount", "Users");
                }
                Giver giver = db.Givers.Find(id);
                if (giver == null)
                {
                    return HttpNotFound();
                }
                return View(giver);
            }
            catch
            {
                return RedirectToAction("login", "Users");
            }
        }

        // POST: Givers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GiverID,Phone,Rating,Address,Latitude,Longtitude")] Giver giver)
        {
            if (ModelState.IsValid)
            {
                var oldgiver = db.Givers.Find(giver.GiverID);
                giver.UID = oldgiver.UID;
                //db.Entry(giver).State = EntityState.Modified;
                db.Entry(oldgiver).CurrentValues.SetValues(giver);
                db.SaveChanges();
                return RedirectToAction("MyAccount", "Users");
            }
            return View(giver);
        }

        // GET: Givers/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (Session["Role"].ToString() == "Admin")
                {
                    goto CanDelete;
                }
                if (Session["GID"].ToString() == id.ToString() || Session["Role"].ToString() == "Admin")
                {
                    goto CanDelete;
                }
                else
                {
                    return RedirectToAction("MyAccount", "Users");
                }
            CanDelete:
                if (id == null)
                {
                    return RedirectToAction("MyAccount", "Users");
                }
                Giver giver = db.Givers.Find(id);
                if (giver == null)
                {
                    return HttpNotFound();
                }
                return View(giver);
            }
            catch
            {
                return RedirectToAction("login", "Users");
            }
        }

        // POST: Givers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giver giver = db.Givers.Find(id);
            User user = db.Users.Find(giver.UID);
            if (giver.Comments != null)
            {
                db.Comments.RemoveRange(giver.Comments);

            }
            db.Givers.Remove(giver);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Show(int id)
        {
            Giver giver = db.Givers.Find(id);
            if (giver == null)
            {
                return HttpNotFound();
            }

            TempData["Givers"] = giver;

            return RedirectToAction("Index", "Givers");

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Weather()
        {
            return View();
        }
    }
}
