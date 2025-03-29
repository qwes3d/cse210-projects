using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create Addresses
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create Customers
        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Bob Smith", address2);

        // Create Products
        Product product1 = new Product("Laptop", 101, 899.99, 1);
        Product product2 = new Product("Mouse", 102, 29.99, 2);
        Product product3 = new Product("Keyboard", 103, 49.99, 1);
        Product product4 = new Product("Monitor", 104, 199.99, 1);
        Product product5 = new Product("USB Cable", 105, 9.99, 3);

        // Create Orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display Order Details
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
