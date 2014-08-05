using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LunchOrder.Models;

namespace LunchOrder.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        LunchOrderEntities storeDB = new LunchOrderEntities();

        public ActionResult Index()
        {
            var foods = GetTopSellingFoods(10);
            return View(foods);
        }

        private List<Food> GetTopSellingFoods(int count)
        {
            // Group the order details by food and return
            // the foods with the highest count
            return storeDB.Foods
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

    }
}
