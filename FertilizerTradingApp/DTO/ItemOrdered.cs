using System;

namespace FertilizerTradingApp.Models
{
    public class ItemOrdered
    {
        public int Quantity { get; set; }
        public string FertilizerId { get; set; }
        public string OrderId { get; set; }

        public ItemOrdered(int quantity, string fertilizerId, string orderId)
        {
            Quantity = quantity;
            FertilizerId = fertilizerId;
            OrderId = orderId;
        }
    }
}
