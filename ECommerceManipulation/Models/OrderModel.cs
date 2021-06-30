using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManipulation.Models
{
    public class OrderModel
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public int TotalQuantity { get; set; }
        public double Price {get;set;}
    }
    
}
