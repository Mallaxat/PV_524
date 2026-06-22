using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_9_firstCode_AddTableKey.Model;
using Lesson_9_firstCode_AddTableKey.Data;
using System.Data.Entity;


namespace Lesson_9_firstCode_AddTableKey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Context())
            {
                /*                var customer = new Customer
                                {
                                    Name = "Alex"
                                };

                                db.Customers.Add(customer);
                                db.SaveChanges();
                                Console.WriteLine("Customer added with Id = " + customer.Id);


                                var order = new Order
                                {
                                    Product = "Laptop",
                                    Price = 1200,
                                    CustomerId = customer.Id   // FK
                                };

                                db.Orders.Add(order);*/

                /*              db.SaveChanges();
                              Console.WriteLine("Order added with Id = " + order.Id);
                              var customer = new Customer
                              {
                                  Name = "Georg",
                                  Orders = new List<Order>
                                  {
                                      new Order { Product = "Phone", Price = 500 }
                                  }
                              };

                              db.Customers.Add(customer);
                              db.SaveChanges();*/
                /*
                                var loaded = db.Orders
                                    .Include("Customer")
                                    .FirstOrDefault(o => o.Id == 5);

                                Console.WriteLine(
                                    $"Order: {loaded.Product}, Customer: {loaded.Customer.Name}"
                                );*/
                /*
                                var loaded = db.Orders

                                   .Include("Customer")

                                   .FirstOrDefault(o => o.Id == 1);

                                loaded.Price = "1100";

                                db.SaveChanges();

                                Console.WriteLine("Order updated.");*/

          /*      var loaded = db.Orders.Include("Customer").FirstOrDefault(o => o.Id == 3);
                db.Orders.Remove(loaded);
                db.SaveChanges();
                Console.WriteLine("Order deleted.");

                Console.WriteLine("=== DONE ===");*/


            }
        }
    }
}
