﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LunchOrder.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int FoodId { get; set; }
        public int Count { get; set; }
        public System.DateTime DataCreated { get; set; }
        public virtual Food Food { get; set; }
    }
}