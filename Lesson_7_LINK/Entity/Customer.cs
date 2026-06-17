using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson_7_LINK.Entity
{
    //using System.Data.Linq.Mapping; нужен для того, чтобы описать сущность
    //была связь, по мапингу будет использоваться декорирование по соотвествию ключей и таблиц

    [Table(Name = "Customers")]
    public class Customer
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column(CanBeNull = true)]
        public DateTime DateOfBirth { get; set; }
        public override string ToString()
        {
            return $" {ID,4} {FirstName,15} {LastName,15} {DateOfBirth.ToShortDateString(),15}";
        }
    }
}
