using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.domain
{
    class Order
    {
        public int id { get; }
        public string CustomerName { get; }
        public List<OrderItem> items { get; }

        public Order(int id, string customerName)
        {
            this.id = id;
            CustomerName = customerName;
            this.items = new List<OrderItem>();
        }

        public void AddItem(OrderItem orderItem)
        {
            items.Add(orderItem);
        }

        public double CalculateTotal()
        {
            double Total = items.Sum(i => i.getTotal());
            if (Total > 500) Total *= 0.9;
            return Total;
        }

    }
}
