using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7_DTB_ModelFist.Models
{
    public class CustomerModels
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Picture {  get; set; }

        public CustomerModels(int Id, string firstName, string lastName, DateTime dateOfBirth)
        {
            ID = Id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
        public CustomerModels() {}
        public override string ToString()
        {
            return $"{ID,4} {FirstName,15} {LastName,15} {Convert.ToDateTime(DateOfBirth).ToShortDateString(),15}";
        }
    }
}
