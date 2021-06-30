using ECommerceManipulation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceManipulation.Services
{
    public class OrderManager
    {
        public OrderManager()
        {

        }
        public OrderModel CreateOrder(OrderModel orderModel) {
            Console.WriteLine("Order created " +
                "\n product: "+orderModel.ProductCode +
                "\n quantity: " +orderModel.Quantity);
            int totalQuantity = 0;
            totalQuantity += orderModel.Quantity;
            return new OrderModel {
                ProductCode = orderModel.ProductCode,
                Quantity = orderModel.Quantity,
                TotalQuantity = totalQuantity
            };
        }        

    }
}
