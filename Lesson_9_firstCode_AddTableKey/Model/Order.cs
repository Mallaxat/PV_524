using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_9_firstCode_AddTableKey.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Product { get; set; }
        public string Price { get; set; }

        //Это связи
        //Это внешний ключ
        public int CusomerId { get; set; }
        //Это навигация
        public virtual Customer Customer { get; set; }

    }
}
