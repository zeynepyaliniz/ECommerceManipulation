using ECommerceManipulation.Constants;
using ECommerceManipulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceManipulation.Services
{
    public class ProductManager
    {
        public ProductManager()
        {

        }

        public ProductModel CreateProduct(ProductModel productModel)
        {
            Console.WriteLine("Product created. "+
                "\n code: "+productModel.ProductCode +
                "\n price: "+productModel.Price +
                "\n stock: "+productModel.Stock);

            return new ProductModel
            {
                ProductCode = productModel.ProductCode,
                Price = productModel.Price,
                Stock = productModel.Stock
            };
        }
        public ProductModel GetProductInfo(string productCode, ProductModel product)
        {
            if (!product.ProductCode.Contains(productCode))
            {
                Console.WriteLine(Messages.ProductMessageNotExist + product.ProductCode);

            }

            Console.WriteLine("Product: " + product.ProductCode +
           "\nPrice: " + product.Price +
           "\nStock " + product.Stock);

            return product;

        }
        public ProductModel UpdateProductStock(ProductModel productModel, OrderModel orderModel) {
            productModel.Stock -= orderModel.Quantity;
            return productModel;
        }
        public AfterSoldProductModel GetAfterSoldProductInfo(ProductModel productModel) {
            AfterSoldProductModel afterSoldProductModel = new AfterSoldProductModel
            {
                ProductModel = productModel
            };
            return afterSoldProductModel;
        }

        public void ApplyCampaignProduct(ProductModel productModel) {
        }
        public ProductModel HoldProductInfo(ProductModel productModel) {
            ProductModel holdProductInfo = new ProductModel();
            holdProductInfo = productModel;
            return holdProductInfo;
        }
    }
}
