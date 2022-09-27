using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class ArticlesController : Controller
    {
        private KnowledgeHubDbContext db=new KnowledgeHubDbContext();
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        // GET: Articles/Create
        public ActionResult Submit()
        {

            var categories = from c in db.Categories
                             select new SelectListItem { Text = c.Name, Value = c.CategoryId.ToString() };
            ViewBag.CategoryId = categories;
            return View();
        }

        // POST: Articles/Create


        //TempData ActionMethod->ActionMethod->View
        [HttpPost]
        public ActionResult Submit(Article article)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Submit");
                }
                article.IsApproved = false;
                article.DateSubmitted = DateTime.Now;
                article.SubmittedBy=User.Identity.Name;
                db.Articles.Add(article);
                db.SaveChanges();
                TempData["Message"] = "Congratulations, the article "+ article.Title+" is submitted successfully for approval.";
                return RedirectToAction("Submit");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Review()
        {
            //send list of articles for review

            var articlesToReview = (from a in db.Articles.Include("Category")
                                   where a.IsApproved == false
                                   select a).ToList();

            return View(articlesToReview);

        }
        public ActionResult Approve()
        {
            //approve the selected articles
            return View();
        }
        public ActionResult Reject()
        {
            //reject the selected articles
            return View();
        }
    }
}
