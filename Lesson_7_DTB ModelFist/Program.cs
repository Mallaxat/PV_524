using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Lesson_7_DTB_ModelFist.Datalayer;
using Lesson_7_DTB_ModelFist.Models;

namespace Lesson_7_DTB_ModelFist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //All
            //Интерфейс который позволяет перебирать элементы дженерик коллекций
            IEnumerable<CustomerModels> cust_mod = DL.Customer.All();
            foreach(var item in cust_mod)
            {
                WriteLine(item);
            }

            WriteLine("-----");
            
            //By Id
            CustomerModels cm = DL.Customer.ByID(4);
            WriteLine($" CM {cm.LastName}");
           
            WriteLine("-----");
          
            //Add
            int id = DL.Customer.CustomerAdd(new CustomerModels (0,"Fist1","Bong1",DateTime.Now));
            WriteLine(id);
           
            WriteLine("-----");

            //Delete
            int _id = DL.Customer.Delete(4);
            WriteLine(id);
        }
    }
}
