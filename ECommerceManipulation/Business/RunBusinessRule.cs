using ECommerceManipulation.Constants.CommandsInFile;
using ECommerceManipulation.Models;
using ECommerceManipulation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceManipulation.Business
{
    public static class RunBusinessRule
    {
       
        public static void RunCommands(TextModel textModel) {
            List<ParamModel> paramModels = GetParamFromFile(textModel);
            ProductModel productModel = new ProductModel();
            OrderModel orderModel = new OrderModel();
            CampaignModel campaignModel = new CampaignModel();
            List<OrderModel> orderModels = new List<OrderModel>();
            CampainInfoModel campaignInfoModel = new CampainInfoModel();
            foreach (var paramModel in paramModels) {
                if (String.IsNullOrEmpty(paramModel.Command)){
                    return;
                }
                if (paramModel.Param.Count <= 0) {
                    Console.WriteLine("Undefined Command Please Make Sure Your Command");
                    return;
                }
                if (paramModel.Command.Contains(Commands.create_product))
                {
                    productModel = RunCreateProductCommand(paramModel); 
                }
                if (paramModel.Command.Contains(Commands.create_campaign)) {
                    // Console.WriteLine("Campaign Command Runs");
                    campaignModel = RunCreateCampaignCommand(paramModel);

                }
                if (paramModel.Command.Contains(Commands.create_order))
                {
                    orderModel = RunCreateOrderCommand(paramModel,productModel);
                    orderModel.Price = productModel.Price;
                    productModel = RunUpdateStockInProduct(productModel, orderModel);
                    orderModels.Add(orderModel);
                    campaignModel.OrderModels = orderModels;
                    //Console.WriteLine("Order Command Runs");

                }
                if (paramModel.Command.Contains(Commands.get_product_info)) {

                    RunGetProductInfo(paramModel.Param.ElementAt(0), productModel);                  

                }
                if (paramModel.Command.Contains(Commands.increase_time)) {
                    int hour = int.Parse(paramModel.Param.ElementAt(0));
                    campaignModel.IncreasedTime +=  RunIncreaseTime(hour);
                    productModel = RunApplyCampaign(productModel,campaignModel);
                }
                if (paramModel.Command.Contains(Commands.get_campaign_info))
                {
                    string name = paramModel.Param.ElementAt(0);
                    campaignInfoModel = RunGetCampaignInfo(name,campaignModel);
                }
            }
            
        }

        /// <summary>
        /// Read File from Commands and Parameters
        /// </summary>
        /// <param name="textModel"></param>
        /// <returns></returns>
        private static List<ParamModel> GetParamFromFile(TextModel textModel) {
            ReadFiles.ReadFiles readFiles = new ReadFiles.ReadFiles();
            
            return readFiles.ReadFile(textModel.InputFile);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramModel"></param>
        /// <returns></returns>
        private static ProductModel RunCreateProductCommand(ParamModel paramModel) {
            ProductModel productModel = new ProductModel
            {
                ProductCode = paramModel.Param.ElementAt(0),
                Price = double.Parse(paramModel.Param.ElementAt(1)),
                Stock = int.Parse(paramModel.Param.ElementAt(2))
            };
            ProductManager productManager = new ProductManager();
            var response = productManager.CreateProduct(productModel);
            Console.WriteLine("Created Product Code: " + response.ProductCode +
                "Price: " + response.Price +
                "Stock: " + response.Stock);
            HoldProductInfo(response);
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramModel"></param>
        /// <returns></returns>
        private static CampaignModel RunCreateCampaignCommand(ParamModel paramModel) {
            CampaignManager campaignManager = new CampaignManager();
            CampaignModel campaignModel = new CampaignModel {
                Name = paramModel.Param.ElementAt(0),
                ProductCode = paramModel.Param.ElementAt(1),
                Duration = int.Parse(paramModel.Param.ElementAt(2)),
                PriceManipulationLimit = double.Parse(paramModel.Param.ElementAt(3)),
                TargetSalesCount = int.Parse(paramModel.Param.ElementAt(4))
            };
           return campaignManager.CreateCampaign(campaignModel);
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramModel"></param>
        /// <param name="productModel"></param>
        /// <returns></returns>
        private static OrderModel RunCreateOrderCommand(ParamModel paramModel,ProductModel productModel) {
            OrderManager orderManager = new OrderManager();
            OrderModel orderModel = new OrderModel {
                ProductCode = paramModel.Param.ElementAt(0),
                Quantity = int.Parse(paramModel.Param.ElementAt(1))
            };
            ProductModel _productModel = RunGetProductInfo(paramModel.Param.ElementAt(0),productModel);
            if (!IsAvailableProduct(orderModel,_productModel)) {
                Console.WriteLine("There no product with " +orderModel.ProductCode + " code.");
            }
            if (!IsAvailableQuantity(orderModel,productModel)) {
                Console.WriteLine("There no stock with " + orderModel.ProductCode + " code. available stock: " + productModel.Stock);
            }
            return orderManager.CreateOrder(orderModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productModel"></param>
        /// <returns></returns>
        private static ProductModel RunGetProductInfo(string productCode,ProductModel productModel) {
            ProductManager productManager = new ProductManager();
            return productManager.GetProductInfo(productCode,productModel);
        }

        private static bool IsAvailableProduct(OrderModel order, ProductModel product)
        {
            return order.ProductCode.Equals(product.ProductCode);
        }
        private static bool IsAvailableQuantity(OrderModel order, ProductModel product)
        {
            return product.Stock >= order.Quantity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productModel"></param>
        /// <param name="orderModel"></param>
        /// <returns></returns>
        private static ProductModel RunUpdateStockInProduct(ProductModel productModel,OrderModel orderModel) {
            ProductManager productManager = new ProductManager();
            return productManager.UpdateProductStock(productModel, orderModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hour"></param>
        private static int RunIncreaseTime(int hour) {
            CampaignManager campaignManager = new CampaignManager();
            return campaignManager.IncreaseTime(hour);
        }
        private static ProductModel HoldProductInfo(ProductModel productModel) {
            ProductManager productManager = new ProductManager();
            return productManager.HoldProductInfo(productModel);
        }
        private static CampainInfoModel RunGetCampaignInfo(string name,CampaignModel campaignModel){
            CampaignManager campaignManager = new CampaignManager();
            return campaignManager.GetAfterCampaignInfo(name,campaignModel);
        }
        private static ProductModel RunApplyCampaign(ProductModel productModel, CampaignModel campaignModel) {
            CampaignManager campaignManager = new CampaignManager();
            return campaignManager.ApplyCampaign(productModel,campaignModel);
        }
    }
}
