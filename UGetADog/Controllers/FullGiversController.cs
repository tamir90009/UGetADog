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
        private const Double V = 20;
        private UGetADogContext db = new UGetADogContext();
        
        // GET: FullGivers
        public ActionResult Index()
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

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private Double Deg2rad(Double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private Double Rad2deg(Double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        public Double Distance(Double lat1, Double lon1, Double lat2, Double lon2)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                Double theta = lon1 - lon2;
                Double dist = Math.Sin(Deg2rad(lat1)) * Math.Sin(Deg2rad(lat2)) + Math.Cos(Deg2rad(lat1)) * Math.Cos(Deg2rad(lat2)) * Math.Cos(Deg2rad(theta));
                dist = Math.Acos(dist);
                dist = Rad2deg(dist);
                dist = dist * 60 * 1.1515;               
                dist = dist * 1.609344;
                return (dist);
            }
        }

         // GET api/user/firstname/lastname/address
        [HttpGet]
        public ActionResult Index([Bind(Include = "FirstName,LastName")] User user, [Bind(Include = "Latitude,Longtitude")] Giver giver)
        //public ActionResult Index(String FirstName, String LastName)
        {
            Func<Giver, Giver, Boolean> CheckDistance = (Giver userloc, Giver g) => { return Distance(userloc.Latitude, userloc.Longtitude, g.Latitude, lon2: g.Longtitude) < 20; };
            if (user.FirstName == null && user.LastName == null)
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
            /*FullGiver fullGiver = new FullGiver();
            fullGiver.user.FirstName = FirstName;
            fullGiver.user.LastName = LastName;*/
            if (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
            {
                
                var fullGivers = (from g in db.Givers.AsEnumerable()
                                  join u in db.Users.AsEnumerable() on g.UID equals u.UserID
                                  where (u.FirstName == user.FirstName) &&
                                  (u.LastName == user.LastName) &&
                                  (CheckDistance(giver, g))
                               select new FullGiver
                               {
                                   giver = g,
                                   user = u
                               });
                TempData["FullGivers"] = fullGivers;
                return View(fullGivers);
            }
            else if (!string.IsNullOrEmpty(user.FirstName))
            {
                var fullGivers = (from g in db.Givers.AsEnumerable()
                                  join u in db.Users.AsEnumerable() on g.UID equals u.UserID
                               where u.FirstName == user.FirstName &&
                               (CheckDistance(giver, g))
                                  select new FullGiver
                               {
                                   giver = g,
                                   user = u
                               });
                TempData["FullGivers"] = fullGivers;
                return View(fullGivers);
            }
            else if (!string.IsNullOrEmpty(user.LastName))
            {
                var fullGivers = (from g in db.Givers.AsEnumerable()
                                  join u in db.Users.AsEnumerable() on g.UID equals u.UserID
                               where u.LastName == user.LastName &&
                               (CheckDistance(giver, g))
                                  select new FullGiver
                               {
                                   giver = g,
                                   user = u
                               });
                TempData["FullGivers"] = fullGivers;
                return View(fullGivers);
            }
            return View();
        }
    }
}