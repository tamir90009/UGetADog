using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}