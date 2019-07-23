﻿using System;
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
        
      

    }
}