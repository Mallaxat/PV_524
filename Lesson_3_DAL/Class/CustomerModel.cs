using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_DAL.Class
{
    internal class CustomerModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public CustomerModel(int Id,string firstName,string lastName,DateTime dateOfBirth)
        {
            ID= Id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return $"{ID,4} {FirstName,15} {LastName,15} {DateOfBirth.ToShortDateString(),15}";
        }
    }
}
