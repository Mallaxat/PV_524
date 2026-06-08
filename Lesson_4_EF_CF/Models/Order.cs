using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_EF_CF.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]//декоратор говорит о том, что требуется обязательно NOT NULL
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
