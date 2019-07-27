using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UGetADog.Models;

namespace UGetADog.Controllers
{
    public class FullGiversController : Controller
    {
        private UGetADogContext db = new UGetADogContext();
        
        // GET: FullGivers
        /*public ActionResult Index()
        {
            var GiversAndUsers = (from g in db.Givers
                                  join u in db.Users on g.UID equals u.UserID
                                  select new FullGiver
                                  {
                                      giver = g,
                                      user = u
                                  });

            return View(GiversAndUsers);
        }*/
        // GET: Givers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var currgiver = (from g in db.Givers
                                  join u in db.Users on g.UID equals u.UserID
                                  where g.GiverID == id
                                  select new FullGiver
                                  {
                                      giver = g,
                                      user = u
                                  });


            return View(currgiver);

        }


        [HttpGet]
        public ActionResult Index([Bind(Include = "FirstName,LastName")] User fullGiver)
        {

            if (!string.IsNullOrEmpty(fullGiver.FirstName) && !string.IsNullOrEmpty(fullGiver.LastName))
            {
                var fullGivers = (from g in db.Givers
                               join u in db.Users on g.UID equals u.UserID
                               where u.FirstName == fullGiver.FirstName &&
                               u.LastName == fullGiver.LastName
                               select new FullGiver
                               {
                                   giver = g,
                                   user = u
                               });
                TempData["FullGivers"] = fullGivers;
                return View(fullGivers);
            }
            else if (!string.IsNullOrEmpty(fullGiver.FirstName))
            {
                var fullGivers = (from g in db.Givers
                               join u in db.Users on g.UID equals u.UserID
                               where u.FirstName == fullGiver.FirstName
                               select new FullGiver
                               {
                                   giver = g,
                                   user = u
                               });
                TempData["FullGivers"] = fullGivers;
                return View(fullGivers);
            }
            else if (!string.IsNullOrEmpty(fullGiver.LastName))
            {
                var fullGivers = (from g in db.Givers
                               join u in db.Users on g.UID equals u.UserID
                               where u.LastName == fullGiver.LastName
                               select new FullGiver
                               {
                                   giver = g,
                                   user = u
                               });
                TempData["FullGivers"] = fullGivers;
                return View(fullGivers);
            }
            else
            {
                var GiversAndUsers = (from g in db.Givers
                                      join u in db.Users on g.UID equals u.UserID
                                      select new FullGiver
                                      {
                                          giver = g,
                                          user = u
                                      });

                return View(GiversAndUsers);
            }
        }
    }
}