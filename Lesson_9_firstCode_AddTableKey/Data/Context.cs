using Lesson_9_firstCode_AddTableKey.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_9_firstCode_AddTableKey.Data
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


    }

}
