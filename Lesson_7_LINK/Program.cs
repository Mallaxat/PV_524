using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;
using System.Data.Linq;
using static System.Console;
using Lesson_7_LINK.Entity;

namespace Lesson_8_LINK
{        /*
         * Алгоритмы - функции внутри которых огромная логика
         * Language Integrated Query- Linq
         * Набор методов для обращения к базовым запросам БД
         * Linq to object - для коллекций, хранящихся в оп
         * Linq to XML - для работы с данными с внешних файлов
         * Linq to SQL - 
         */
    //Linq to object
    /* internal class Program
    {

       public class Product
        {
            public string Name_ { get; set; }
            public int Price{ get; set; }
            public override string ToString()
            {
                return $"{Name_,15} {Price,6}";
            }

        }
        static void Main(string[] args)
        {
            //Linq to object
                       List<Product> products = new List<Product>
                       { 
                           new Product{Name_= "111" ,Price = 1},
                           new Product{Name_= "222" ,Price = 2},
                           new Product{Name_= "333" ,Price = 3},
                           new Product{Name_= "4444" ,Price = 4},
                           new Product{Name_= "5555" ,Price = 5},
                       };
                       WriteLine("----- C# -----");
                       foreach (var item in products)
                       {
                           WriteLine(item);
                       }
                       WriteLine("----- Linq to object -----");
                       WriteLine();
                       WriteLine("----- Найти все продукты и вернуть результат -----");
                       WriteLine("----- Синтаксис запросов -----");

                       //a) Найти все продукты и в результат возвращаем результат 
                       var res = from p in products
                                 select p;
                       //select* from product
                       foreach (var item in res)
                       {
                           WriteLine(item);
                       }
                       WriteLine();
                       WriteLine("----- Найти все продукты где цена больше услвоия, отсортируй и выведи -----");

                       //b)Найти все продукты где цена больше услвоия, отсортируй и выведи 
                       var res2 = from p in products
                                 where p.Price > 2
                                 orderby p.Price descending
                                 select p;

                       foreach (var item in res2)
                       {
                           WriteLine(item);
                       }
                       WriteLine();
                       WriteLine("----- В продуктах найти имя с размером больше 4 отсортировать по длине и вывести -----");

                       //c В продуктах найти имя с размером больше 4 отсортировать по длине и вывести
                       var res3 = from p in products
                                  where p.Name_.Length > 3
                                  orderby p.Name_.Length
                                  select p;

                       foreach (var item in res3)
                       {
                           WriteLine(item);
                       }
                       WriteLine();
                       WriteLine("----- Выбери там где имя начинается на П, отсортировать и вывести -----");
                       var res4 = from p in products
                                 where p.Name_.StartsWith("1")
                                 orderby p.Name_ descending
                                 select p;
                       foreach (var item in res4)
                       {
                           WriteLine(item);
                       }

                       WriteLine();
                       WriteLine("----- Синтаксис методов -----");
                       WriteLine("----- В продуктах найти имя с размером больше 4 отсортировать по длине и вывести -----");


                       //d OrderBy и Where это алгоритмы для коллекций
                       var res5 = products.OrderBy(c => c.Name_.Length).Where(c => c.Name_.Length > 3);
                       foreach (var item in res5)
                       {
                           WriteLine(item);
                       }
                       WriteLine();
                       // e вывести максимальное значение по всей коллекции
                       WriteLine("----- Вывести максимальное значение прайса всего списка -----");
                       var maxPrice = products.Select(p => p.Price).Max();
                       WriteLine(maxPrice);

                       WriteLine();
                       WriteLine("---- Вывести первое значение с максимальным числом-----");
                       //First поиск первого элемента в коллекции с таким числом
                       var res6 = products.First(p => p.Price == maxPrice);
                       WriteLine(res6);

        }
    }*/

    //Linq to XML
    /*internal class Program
    {
        //Метод будет создавать XML документ и в нем будет храниться кол-я компьютеров
        //Из двух элементов
        static void CreateXMLDocument()
        {
            XDocument xmldoc = new XDocument(
                new XElement("computers",
                    new XElement("computer",
                        "This is not expensive and reliable computer",
                        new XAttribute("Price", "800"),
                        new XAttribute("Warranty", "2 years"),
                        new XElement("CPU",
                            new XAttribute("Name", "Intel Core i7-6700K"),
                            new XAttribute("GHz", 2.5)
                            ),
                        new XElement("HDD",
                            new XAttribute("Name", "Samsung 850 PRO"),
                            new XAttribute("Size", 1.0)
                        )
                    ),
                    new XElement("computer",
                        new XAttribute("Price", "900"),
                        new XAttribute("Warranty", "2 years"),
                        new XElement("CPU",
                            new XAttribute("Name", "AMD A10-5800K"),
                            new XAttribute("GHz", 2.5)
                            ),
                        new XElement("HDD",
                            new XAttribute("Name", "Transcend ESD400"),
                            new XAttribute("Size", 1.0)
                        )
                    )
                )
            );
            Console.WriteLine(xmldoc);
            string xmlFilePath = @"example.xml";
            xmldoc.Save(xmlFilePath);
        }
        //Метод для чтения XML файла
        static void ReadXMLDocument()
        {
            string xmlFilePath = @"example.xml";
            XDocument xmldoc = XDocument.Load(xmlFilePath);
            WriteLine(xmldoc);

            //var result = from c in xmldoc.Descendants(XName.Get("computer"))
            //             where Convert.ToInt32(c.Attribute(XName.Get("Price")).Value) < 850
            //             select c;

            var result = xmldoc.Descendants(XName.Get("computer")).
                      Where(c => Convert.ToInt32(c.Attribute(XName.Get("Price")).Value) < 850);

            foreach (var item in result)
            {
                WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            CreateXMLDocument();

        }
    }
    */

    //Linq to SQL 
    //Нужные интерфейсы IEnumerable IQueryble
    internal class Program
    {
        static void Main(string[] args)
        {
            string connect = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;
            //Нужно создать класс-котекст
            
            //Создаем класс контекста

            using (DataContext dc = new DataContext(connect))
            {
                //All из базы данных считать всех кастомеров в список
                //Tabl коллекция кастомеров в виде таблиц
                Table<Customer>  cus_all=dc.GetTable<Customer>();

                foreach(var item in cus_all)
                {
                    WriteLine(item);
                }


                /*                //Возьмет первые 2 строчки
                                List<Customer> res1 = cus_all.Take(2).ToList(); //Top

                                foreach (var item in res1)
                                {
                                    WriteLine(item);
                                }
                                WriteLine("--------------------------------");*/


                //b
                /*                var res = from c in cus_all
                                          where c.ID == 100
                                          select c;

                                // if(res==null) //errorMBox
                                foreach (var item in res)
                                {
                                    WriteLine(item);
                                }*/

                //с
                /*                var query = from c in cus_all
                                            where c.DateOfBirth.Year > 2015
                                            select c;
                                foreach (var item in query)
                                {
                                    WriteLine(item);
                                }*/
                //d
                /*             var query = from c in cus_all
                                         where c.FirstName.StartsWith("I")
                                         select c;
                             foreach (Customer item in query)
                             {
                                 Console.WriteLine(item);
                  
                }*/

                //Insert
                /*                Customer cust_new = new Customer { DateOfBirth = new DateTime(1999, 11, 1), LastName = "LN_new_customer", FirstName = "FN_new_customer" };
                                cus_all.InsertOnSubmit(cust_new);
                                //Обновляем данные в памяти
                                dc.SubmitChanges();
                                foreach (Customer item in cus_all)
                                {
                                    Console.WriteLine(item);
                                }*/
                //Гзвфеу
                /*                Customer c_edit = cus_all.Where(c => c.ID == 3).First();
                                c_edit.LastName += "_redacted";
                                WriteLine(c_edit);
                                dc.SubmitChanges();
                                WriteLine("-----------------");
                                foreach (Customer item in cus_all)
                                {
                                    Console.WriteLine(item);
                                }*/
                //delete
                Customer c_del = cus_all.Where(c => c.ID == 1005).First();
                if (c_del != null) //try-catch
                {
                    cus_all.DeleteOnSubmit(c_del);
                    dc.SubmitChanges();
                    foreach (var item in cus_all)
                    {
                        WriteLine(item);
                    }
                }
                else WriteLine("Error");
            }



        }
    }
}
