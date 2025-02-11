﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using FertilizerTradingApp.Models;
using FertilizerTradingApp.Repository;

namespace FertilizerTradingApp.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetAllOrders()
        {
            try
            {
                return _orderRepository.GetOrders();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving orders: {ex.Message}");
                return new List<Order>();
            }
        }
        public Order GetOrderById(string orderId)
        {
            try
            {
                var orders = _orderRepository.GetOrders();
                return orders.FirstOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving order with ID {orderId}: {ex.Message}");
                return null;
            }
        }
		public List<Order> GetOrdersOfCustomer(DateTime startDate, DateTime endDate, string customer_phone)
		{
			return _orderRepository.GetOrdersOfCustomer(startDate, endDate, customer_phone);
		}
		public List<Order> GetOrdersByTime(DateTime startDate, DateTime endDate)
		{
			return _orderRepository.GetOrdersByTime(startDate, endDate);
        }
        public List<Order> FindOrder(string str)
        {
			return _orderRepository.FindOrder(str);
		}
        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }
        public string getNewestOrderId()
        {
            return _orderRepository.GetNewestOrderId();
        }
        public void UpdateTotalPayment(string orderId, float newTotalPayment)
        {
            _orderRepository.UpdateTotalPayment(orderId, newTotalPayment);
        }
        public List<Order> GetOrdersByCustomerId(string customerPhone)
        {
           return _orderRepository.GetOrdersByCustomerId(customerPhone);
        }
    }
}
