using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_EF_CF.Models
{
    //Класс контекст он всегда наследуется от дбконтекст
    public class MarketplaceDBContext : DbContext
    {
        //Создаем объекты DbSe содержит коллекцию наших записец 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Country> Countries { get; set; }

        //"Marketplace_db" строка подключения к базе 
        public MarketplaceDBContext() : base("Marketplace_db") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
