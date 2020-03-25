using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_TSP_NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Designer First");
            TestPerson();
            TesTOneToMany();
            TestAlbumArtist();
            Console.ReadKey();
        }
        static void TestPerson()
        {
            using (Model1Container context = new Model1Container())
            {
                People p = new People()
                {
                    FirstName = "Julie",
                    LastName = "Andrew",
                    MidleName = "T",
                    TelephonNumber = "1234567890"
                };
                context.Person.Add(p);
                context.SaveChanges();
                var items = context.Person;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }
        static void TesTOneToMany()
        {
            Console.WriteLine("One to many association");
            using (Model2Container context =
           new Model2Container())
            {
                Console.WriteLine("Customer Name:");
                var nume = Console.ReadLine();
                Console.WriteLine("Customer City:");
                var city = Console.ReadLine();

                Customer c = new Customer()
                {
                    
                    Name = nume,
                    City = city
                };
                Console.WriteLine("Customer Order 1 Value:");
                var value = Console.ReadLine();
                Order o1 = new Order()
                {
                    TotalValue = value,
                    Date = DateTime.Now,
                    Customer = c
                };
                Console.WriteLine("Customer Order 2 Value:");
                value = Console.ReadLine();
                Order o2 = new Order()
                {
                    TotalValue = value,
                    Date = DateTime.Now,
                    Customer = c
                };
                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();
                var items = context.Customers;
                foreach (var x in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}",
                   x.CustomerId, x.Name, x.City);
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}",
                       ox.OrderId, ox.Date, ox.TotalValue);
                }
            }
        }

        static void TestAlbumArtist()
        {
            Console.WriteLine("Many to many association");
            using (Model3Container context = new Model3Container())
            {
                Album a = new Album()
                {
                    AlbumName = "NumeAlbum1",
                    
                };
                Artist art = new Artist()
                {
                    FirtsName = "Kurt",
                    LastName = "Cobain",
                   
                };
                
                context.Albums.Add(a);
                context.Artists.Add(art);
                context.SaveChanges();
                
            }
        }
    }
}
