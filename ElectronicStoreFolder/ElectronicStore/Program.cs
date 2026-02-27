using ElectronicStore.domain;

class Program
{
    static void Main()
    {
        var orders = new List<Order>();
        var order1 = new Order(1, "Daniel");
        order1.AddItem(new OrderItem("Laptop", 1, 450));
        order1.AddItem(new OrderItem("Mouse", 2, 20));

        var order2 = new Order(2, "Mihai");
        order2.AddItem(new OrderItem("Monitor", 1, 499));

        var order3 = new Order(3, "Robert");
        order3.AddItem(new OrderItem("Monitor", 1, 250));

        orders.Add(order1);
        orders.Add(order2);
        orders.Add(order3);

        string customer = GetCustomerNameWithMostMoneySpent(orders);
        Console.WriteLine($"Customer: {customer}\n");

        var popularProducts = GetMostPopularProducts(orders);
        Console.WriteLine("Popular products: \n");
        foreach(var product in popularProducts)
        {
            Console.WriteLine($"{product.ProductName} - {product.TotalQuantity}");
        }

    }

    static string GetCustomerNameWithMostMoneySpent(List<Order> orders)
    {
        if (orders == null || orders.Count == 0) return null;
        return orders.GroupBy(order => order.CustomerName)
            .Select(g => new
            {
                Name = g.Key,
                Total = g.Sum(i => i.CalculateTotal())
            })
            .OrderByDescending(order => order.Total)
            .ToList()
            .First()
            .Name;
    }

    static List<(string ProductName, int TotalQuantity)> GetMostPopularProducts(List<Order> orders)
    {
        if (orders == null || orders.Count == 0) return null;
        var grouped = orders.SelectMany(order => order.items)
            .GroupBy(item => item.ProductName)
            .Select(g => new
            {
                ProductName = g.Key,
                TotalQuantity = g.Sum(item => item.Quantity)
            })
            .ToList();

        int maxQuantity = grouped.Max(item => item.TotalQuantity);

        return grouped.Where(item => item.TotalQuantity == maxQuantity)
            .Select(item => (item.ProductName, item.TotalQuantity))
            .ToList();
    }
}