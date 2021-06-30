using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManipulation.Models
{
    public class ProductModel
    {
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
    public class AfterSoldProductModel {
        public ProductModel ProductModel { get; set; }
        public double AvaragePrice { get; set; }
        public int TotalSalesCount { get; set; }
    }    
}
