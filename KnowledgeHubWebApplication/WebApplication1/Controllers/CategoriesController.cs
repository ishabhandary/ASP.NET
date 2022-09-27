using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        //CRUD
        //CUD require 2 action methods 1 view and for read 1 action 1 view
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var categories = db.Categories.ToList();
            if(search != null&&search.Length>0)
            {
                categories = (from c in categories
                              where c.Name.Contains(search) || c.Description.Contains(search)
                              select c).ToList();
            }
            return View(categories);
        }

        //categories/create
        public ActionResult Create()
        {
            return View();
        }

        /*public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            db.Categories.Add(category);
            db.SaveChanges();
            //not return var categories=db.categories.tolist();view("index",categories) as repetition of code
            return RedirectToAction("Index");
        }*/

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            db.Categories.Add(category);
            db.SaveChanges();
            //not return var categories=db.categories.tolist();view("index",categories) as repetition of code
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Category categoryToDelete = db.Categories.Find(id);
            //Only if you want to delete directly
            //db.Categories.Remove(categoryToDelete);db.SaveChanges();
            return View(categoryToDelete);
        }

        public ActionResult ConfirmDelete(int id)
        {
            Category categoryToDelete = db.Categories.Find(id);
            db.Categories.Remove(categoryToDelete); db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Category categoryToEdit = db.Categories.Find(id);
            return View(categoryToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Category categoryToEdit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Categories.AddOrUpdate(categoryToEdit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}