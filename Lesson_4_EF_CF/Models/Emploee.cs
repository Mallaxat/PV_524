using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4_EF_CF.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int Code { get; set; }// табельный номер
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
         public Position Position { get; set; }//должность

}
 
}
