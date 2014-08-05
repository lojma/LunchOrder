using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LunchOrder.Models;

namespace LunchOrder.Controllers
{
    [Authorize(Roles="Administrator")]
    public class MenuManagerController : Controller
    {
        private LunchOrderEntities db = new LunchOrderEntities();

        //
        // GET: /MenuManager/

        public ActionResult Index()
        {
            var foods = db.Foods.Include(f => f.Category).Include(f => f.Supplier);
            return View(foods.ToList());
        }

        //
        // GET: /MenuManager/Details/5

        public ActionResult Details(int id = 0)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        //
        // GET: /MenuManager/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name");
            return View();
        }

        //
        // POST: /MenuManager/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", food.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", food.SupplierId);
            return View(food);
        }

        //
        // GET: /MenuManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", food.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", food.SupplierId);
            return View(food);
        }

        //
        // POST: /MenuManager/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", food.CategoryId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", food.SupplierId);
            return View(food);
        }

        //
        // GET: /MenuManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        //
        // POST: /MenuManager/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}