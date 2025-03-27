using System;
using System.Collections.Generic;

    
class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateOrProvince { get; set; }
    public string Country { get; set; }

    // Constructor to initialize address
    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    // Method to return the full address as a string
    public string GetFullAddress()
    {
        return $"{StreetAddress}\n{City}, {StateOrProvince}\n{Country}";
    }
}

class Customer
{
    public string Name { get; set; }
    public Address CustomerAddress { get; set; }

    // Constructor to initialize customer
    public Customer(string name, Address address)
    {
        Name = name;
        CustomerAddress = address;
    }

    // Method to check if the customer lives in the USA
    public bool IsInUSA()
    {
        return CustomerAddress.IsInUSA();
    }
}

class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    // Constructor to initialize product
    public Product(string name, int productId, double price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    // Method to calculate the total cost of the product
    public double TotalCost()
    {
        return Price * Quantity;
    }
}

class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    // Constructor to initialize order with a list of products and a customer
    public Order(Customer customer)
    {
        Products = new List<Product>();
        Customer = customer;
    }

    // Method to add products to the order
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    // Method to calculate the total cost of the order
    public double CalculateTotalCost()
    {
        double totalProductCost = 0;
        foreach (var product in Products)
        {
            totalProductCost += product.TotalCost();
        }

        // Shipping cost: $5 if in USA, $35 if not
        double shippingCost = Customer.IsInUSA() ? 5 : 35;

        return totalProductCost + shippingCost;
    }

    // Method to return the packing label (Product name and ID)
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    // Method to return the shipping label (Customer name and address)
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{Customer.Name}\n{Customer.CustomerAddress.GetFullAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
{
        // Creating customers and their addresses
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Alice Johnson", address1);
}
}