using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LunchOrder.Models;

namespace LunchOrder.Controllers
{
    public class MenuController : Controller
    {
        LunchOrderEntities storeDB = new LunchOrderEntities();
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();
            
            return View(categories);
        }
        //
        // GET: /Menu/Browse
        public ActionResult Browse(string category)
        {
            var categoryModel = storeDB.Categories.Include("Foods").Single(g => g.Name == category);

            return View(categoryModel);
        }
        //
        // GET: /Menu/Details
        public ActionResult Details(int id)
        {
            var food = storeDB.Foods.Find(id);

            return View(food);
        }

        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeDB.Categories.ToList();
            return PartialView(categories);
        }

    }
}
