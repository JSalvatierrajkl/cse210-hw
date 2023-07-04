using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Product product1 = new Product("Book of Mormon", "010", 54.99, 16);
        Product product2 = new Product("Bible", "012", 61.59, 12);
        Product product3 = new Product("Triple", "021", 58.19, 14);
        Product product4 = new Product("Preach my Gospel", "059", 42.00, 24);
        Product product5 = new Product("Restauration, Plan of Salvation and Gospel of Jesus Christ Panflets", "063", 38.99, 120);
        Product product6 = new Product("Jesus The Christ", "071", 70.49, 16);
        
        Address address1 = new Address("358 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Keeper", address1);

        Address address2 = new Address("927 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jacob Smith", address2);

        Address address3 = new Address("Oconnor 789", "Moron", "BSAS", "Argenina");
        Customer customer3 = new Customer("Luis Rodriguez", address3);

        Address address4 = new Address("134 Brigham St", "Logan", "UT", "USA");
        Customer customer4 = new Customer("Nate Johnson", address4);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product1);

        Order order3 = new Order(customer3);
        order3.AddProduct(product5);
        order3.AddProduct(product2);

        Order order4 = new Order(customer4);
        order4.AddProduct(product1);
        order4.AddProduct(product3);
        order4.AddProduct(product2);

        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: $ {order1.CalculateTotalPrice()}");

        Console.WriteLine();
        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: $ {order2.CalculateTotalPrice()}");
        
        Console.WriteLine();
        Console.WriteLine("Order 3:");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Price: $ {order3.CalculateTotalPrice()}");

        Console.WriteLine();
        Console.WriteLine("Order 4:");
        Console.WriteLine(order4.GetPackingLabel());
        Console.WriteLine(order4.GetShippingLabel());
        Console.WriteLine($"Total Price: $ {order4.CalculateTotalPrice()}");
    }
}