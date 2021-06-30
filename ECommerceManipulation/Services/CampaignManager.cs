using ECommerceManipulation.Constants;
using ECommerceManipulation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ECommerceManipulation.Services
{
    public class CampaignManager
    {
        public CampaignManager()
        {

        }

        public CampaignModel CreateCampaign(CampaignModel campaignModel) {
            Console.WriteLine("Campaign Code: " + campaignModel.Name +
                "\n Product Code: " + campaignModel.ProductCode +
                "\n Duration: "+campaignModel.Duration +
                "\n Price Manipulation Limit: " + campaignModel.PriceManipulationLimit +
                "\n Target Sales Count: " + campaignModel.TargetSalesCount);
            return new CampaignModel { 
                Name = campaignModel.Name,
                ProductCode = campaignModel.ProductCode,
                Duration = campaignModel.Duration,
                PriceManipulationLimit = campaignModel.PriceManipulationLimit,
                TargetSalesCount = campaignModel.TargetSalesCount
            };
        }

        public CampainInfoModel GetAfterCampaignInfo(string name,CampaignModel campaignModel) {
            if (!campaignModel.Name.Contains(name)) {
                Console.WriteLine(Messages.CampaignMessageNotExist+name);
            }
            CampainInfoModel campainInfoModel = new CampainInfoModel
            {
                Status = IsEnded(campaignModel.Duration,campaignModel.IncreasedTime) ? Messages.CampaignStatusPassive : Messages.CampaignStatusActive,
                TotalSales = GetTotalSales(campaignModel.OrderModels),
                AvarageItemPrice = CalculateAveragePrice(campaignModel.OrderModels)

            };
            Console.WriteLine("Campaign Status: " + campainInfoModel.Status +
                "\n Target Sales: " + campaignModel.TargetSalesCount +
                "\n Total Sales: " + campainInfoModel.TotalSales +
                "\n Avarage Price: " + campainInfoModel.AvarageItemPrice);
            return campainInfoModel;

        }
        public int IncreaseTime(int hour) {
            Console.WriteLine("Increase Time : " +hour);           
            return hour;             
        }
        public bool IsEnded(int duration,int increasedTime) {
            return duration <= increasedTime;            
        }

        public ProductModel ApplyCampaign(ProductModel productModel, CampaignModel campaignModel) {
            try
            {
                productModel.Price = ManipulatePrice(campaignModel.PriceManipulationLimit,productModel.Price);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
            return productModel;
        }
        public double ManipulatePrice(double manipulationPriceLimit,double price) {
            Random random = new Random();
            int manipulationLimit = Convert.ToInt32(manipulationPriceLimit);
            double rnd = random.Next(0, manipulationLimit);
            price -= rnd * price / 100;
            
            return Math.Round((Double)price, 2);
        }
        private double CalculateAveragePrice(List<OrderModel> orderModels) {
            double calculatedPrice = GetTotalRevenue(orderModels) / GetTotalSales(orderModels);
            return Math.Round((Double)(calculatedPrice), 2) ;

        }
        private int GetTotalSales(List<OrderModel> orderModels) {            
            return orderModels.Sum(q => q.Quantity);
        }
        private double GetTotalRevenue(List<OrderModel> orderModels) {
            double sum = 0;
            foreach (var order in orderModels) {
                sum += GetProductOfTwoElement(order.Price,order.Quantity);
            }
            return Math.Round((Double)sum,2);
        }
        private double GetProductOfTwoElement(double price,int quantity) {
            return price * quantity;
        }
        

         
       
    }
}
