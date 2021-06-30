using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManipulation.Models
{
    public class CampaignModel
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public double PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public int IncreasedTime { get; set; }
        public List<OrderModel> OrderModels { get; set; }
        public List<ProductModel> ProductModels { get; set; }

    }

    public class CampainInfoModel {
        public string Status { get; set; }
        public int TotalSales { get; set; }
        public double AvarageItemPrice { get; set; }
        public int Turnover { get; set; }
    }
}
