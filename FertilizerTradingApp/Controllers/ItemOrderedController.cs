using FertilizerTradingApp.Models;
using FertilizerTradingApp.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FertilizerTradingApp.Controllers
{
    public class ItemOrderedController
    {
        private readonly ItemOrderedRepository _itemOrderedRepository;

        public ItemOrderedController()
        {
            _itemOrderedRepository = new ItemOrderedRepository(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        }

        public List<ItemOrdered> GetItemsByOrderId(string orderId)
        {
            return _itemOrderedRepository.GetItemsByOrderId(orderId);
        }
        public void AddItemOrdered(ItemOrdered item)
        {
            _itemOrderedRepository.AddItemOrdered(item);
        }
    }
}
