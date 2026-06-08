using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_4_EF_CF.Models
{
    /*Декоратор нужен чтобы назвать табличку не так же, как класс. Если нет-декоратор не нужен*/
    [Table(name: "Countries")]
    public class Country
    {
        //Обязательный декоратор
        [Key] //Можно не ставить, если в классе только одно интовое поле
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Name_country { get; set; } = "Country";

    }
}
