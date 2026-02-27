using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.domain
{
    class OrderItem
    {
        public string ProductName { get; }
        public int Quantity { get; }
        public double UnitPriceAtTheTimeOfPurchase { get; }

        public OrderItem(string productName, int quantity, double unitPriceAtTheTimeOfPurchase)
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPriceAtTheTimeOfPurchase = unitPriceAtTheTimeOfPurchase;
        }

        public double getTotal()
        {
            return Quantity * UnitPriceAtTheTimeOfPurchase;
        }
    }
}
