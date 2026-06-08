using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Lesson_4_EF_CF.Models;

namespace Lesson_4_EF_CF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Здесь создаем базу данных 
            using (var db = new MarketplaceDBContext())
            {
                //add  customer 
                Customer c3 = new Customer { Name = "Igor" };
                db.Customers.Add(c3);
                db.SaveChanges();
                WriteLine($"Customer add id = {c3.Id}");
            }
        }
    }
}
