using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LunchOrder.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<LunchOrderEntities>
    {
        protected override void Seed(LunchOrderEntities context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "first" },
                new Category { Name = "Напитки" },
            };

            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "MacDonalds" },
                new Supplier { Name = "KFC" }
            };

            new List<Food>
            {
                new Food { Title = "Супец", Category = categories.Single(g => g.Name == "first"), Price = 8.99M, Supplier = suppliers.Single(a => a.Name == "MacDonalds"), FoodArtUrl = "/Content/Images/placeholder.gif" },
                new Food { Title = "Борщец", Category = categories.Single(g => g.Name == "first"), Price = 8.99M, Supplier = suppliers.Single(a => a.Name == "KFC"), FoodArtUrl = "/Content/Images/placeholder.gif" },
                new Food { Title = "Спрайт", Category = categories.Single(g => g.Name == "Напитки"), Price = 8.99M, Supplier = suppliers.Single(a => a.Name == "KFC"), FoodArtUrl = "/Content/Images/placeholder.gif" },
               }.ForEach(a => context.Foods.Add(a));
        }
    }
}