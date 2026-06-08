using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Lesson_4_EF_MF
{
    internal class Program
    {
        /*
            EntityFramework - ORM система - Object Relation Mapping
            Object Model - 
            EDM - Entity Data Model -    class C# == table DB

            Conceptual Model - C#
            Mapping -  C# <-> DB
            Storage Model - DB

            Create EDM:
            - I Model First - (структура БД) -> EDM (entity/class/table) ->DB (insert: 1) код в C# (Lesson 1-3)
                                                                                    2) скрипт в БД
                                                                            stor.proc + view + function
                                                                           ) -> WF/WPF - select
            - II Code First - (структура БД) -> C# : class/entity/table -> EDM -> DB (insert: 1) код в C# (Lesson 1-3)
                                                                                    2) скрипт в БД
                                                                            stor.proc + view + function
                                                                           ) -> WF/WPF - select
            - III DB First - DB SQL -> EDM (class/entity/table) -> function
 */
          

        static void Main(string[] args)
        {


        }
    }
}
