using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.\n");

        Address address1 = new Address("123 Main St", "Miami", "FL", "USA");
        Address address2 = new Address("Calle 50, Edificio Towerbank", "Panamá", "Panamá", "Panama");

        Customer costumer1 = new Customer("John Smith", address1);
        Customer costumer2 = new Customer("Ana Torres", address2);

        List<Product> order1Products = new List<Product>()
        {
            new Product("Keyboard", 101, 25.00, 2),
            new Product("Mouse", 102, 15.00, 1)
        };

        List<Product> order2Products = new List<Product>()
        {
            new Product("Monitor", 201, 120.00, 1),
            new Product("USB Cable", 202, 5.00, 3)
        };

        Order order1 = new Order(order1Products, costumer1);
        Order order2 = new Order(order2Products, costumer2);

        Console.WriteLine(order1.DisplayPackingLabel());
        Console.WriteLine(order1.DisplayShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.OrderTotalCost()}\n");

        Console.WriteLine(order2.DisplayPackingLabel());
        Console.WriteLine(order2.DisplayShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.OrderTotalCost()}\n");
    }
}