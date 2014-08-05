using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LunchOrder.Models
{

    public class Food
    {
        public int FoodId { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        public string FoodArtUrl  { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}