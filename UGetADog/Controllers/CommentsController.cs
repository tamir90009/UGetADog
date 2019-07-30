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
    //did only create and show
    public class CommentsController : Controller
    {
        private UGetADogContext db = new UGetADogContext();

        // GET: Comments
        public ActionResult Index(int? id)
        {
            var comments = (IEnumerable<Comment>)TempData["Comments"] ?? db.Comments.Include(c => c.Giver).ToList();
            if (id != null)
            {
                return View(comments.Where(c => c.GiverID == id));
            }
            return View(comments);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }


        // GET: Comments/Create
        public ActionResult Create()
         {
            return View();
         }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,GiverID,DogName,Sendername,Content")] Comment comment , int id )
        {
            MLsController mls = new MLsController();
            if (ModelState.IsValid)
            {
                var giver = db.Givers.Find(id);
                if (giver != null)
                {
                    comment.GiverID = giver.GiverID;
                    comment.Giver = giver;
                    int dog_id = int.Parse(Session["DogID"].ToString());
                    var d= db.Dogs.Where(b => b.DogID.Equals(dog_id)).FirstOrDefault();
                    if (d != null)
                    {
                        comment.DogName = d.Name;
                        db.Comments.Add(comment);
                        giver.Comments.Add(comment);                       
                        db.SaveChanges();


                        //add choise to machine learnin
                     
                        int user_id = int.Parse(Session["ID"].ToString());
                        var user = db.Users.Where(b => b.UserID.Equals(user_id)).FirstOrDefault();
                        if(user != null)
                        {
                            
                            mls.Create(user_id,d.DogID,user.Age, user.Gender, user.FirstName, d.Breed);
                        }
                        
                        //return after
                        // return RedirectToAction("Index", "FullGivers");

                    }
                    return RedirectToAction("Index", "Dogs");
                }
            }

            return RedirectToAction("Index", "Dogs");
        }


 
        // GET: Comments/Edit/5
        /*  public ActionResult Edit(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Comment comment = db.Comments.Find(id);
              if (comment == null)
              {
                  return HttpNotFound();
              }
              ViewBag.GiverID = new SelectList(db.Givers, "GiverID", "Username", comment.GiverID);
              //check if unauthorized
              return View(comment);
          }
          */

        /* // POST: Comments/Edit/5
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "CommentID,GiverID,DogName,Username,Content")] Comment comment)
         {

             //check if unauthorized
             if (ModelState.IsValid)
             {
                 db.Entry(comment).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             ViewBag.GiverID = new SelectList(db.Givers, "GiverID", "Username", comment.GiverID);
             return View(comment);
         }
         */

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Search( )
        {
            if ((Session["Role"].ToString()).ToUpper() == "GIVER")
            {
                int id = int.Parse(Session["GID"].ToString());
                var g = db.Givers.Where(b => b.GiverID.Equals(id)).FirstOrDefault();
                if(g != null)
                {
                    IEnumerable<Comment> Comments = db.Comments.ToList();
                    Comments = Comments.Where(c => c.GiverID.Equals(id));
                    
                    TempData["Comments"] = Comments;
                    return RedirectToAction("Index", "Comments");
                }

                //error
                return RedirectToAction("Home");
            }
            //error 
            return RedirectToAction("Home");
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
