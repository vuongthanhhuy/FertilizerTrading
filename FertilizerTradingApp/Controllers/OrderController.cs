﻿using FertilizerTradingApp.Models;
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
        public List<Order> GetOrdersOfCustomer(DateTime startDate, DateTime endDate, string customer_phone)
        {
            return _orderService.GetOrdersOfCustomer(startDate, endDate, customer_phone);
        }
        public List<Order> GetOrdersByTime(DateTime startDate, DateTime endDate)
        {
            return _orderService.GetOrdersByTime(startDate, endDate);
        }
        public void AddOrder(Order order)
        {
            _orderService.AddOrder(order);
        }
        public string getNewestOrderId()
        {
            return _orderService.getNewestOrderId();
        }
        public List<Order> FindOrder(string str)
        {
            return _orderService.FindOrder(str);
        }
        public void UpdateTotalPayment(string orderId, float newTotalPayment)
        {
            _orderService.UpdateTotalPayment(orderId, newTotalPayment);
        }
        public List<Order> GetOrdersByCustomerId(string customerPhone)
        {
            return _orderService.GetOrdersByCustomerId(customerPhone);
        }
    }
}
