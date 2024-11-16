using FertilizerTradingApp.Models;
using FertilizerTradingApp.Repository;
using FertilizerTradingApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FertilizerTradingApp.Controllers
{
    public class OrderController
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService(new OrderRepository(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString));
        }
        public List<Order> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }
        public Order GetOrderById(string orderId)
        {
            return _orderService.GetOrderById(orderId);
        }
    }
}
