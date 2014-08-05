using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LunchOrder.Models
{
    public partial class Order
    {
        public int    OrderId    { get; set; }
        public string Username   { get; set; }
        public string FirstName  { get; set; }
        public string LastName   { get; set; }
        public string EmployeDepartmen { get; set; }
        public string EmployeePosition { get; set; }
        public string Country    { get; set; }
        public string Phone      { get; set; }
        public string Email      { get; set; }
        public decimal Total     { get; set; }
        public System.DateTime OrderDate      { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}