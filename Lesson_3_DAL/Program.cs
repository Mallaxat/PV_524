using Lesson_3_DAL.DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_3_DAL.Class;

namespace Lesson_3_DAL
{
    internal class Program
    {
        /*
         * Data Acecess Layer(DAL)
         * Позволяет инкапсулировать логику доступа в специальный класс
         * код приложения не должен напрямую работать с соединениями и скл запросами

         * UI(WPF/WF)
         * Business Logic Layer (BLL)
         * Data Access Layer(DAL) - SqlConnection,SqlCommand,SqlDataReader  (присоединенный режим)
                                    SqlDataTable,SqlDataAdapter             (отсоединенный режим)
                            
         
         * Database
         * UI(WPF/WF)  - отображение данных пользователя 
         * Business Logic Layer (BLL) - бизнес правила и проверки
         * Data Access Layer(DAL) - хранилище данных
         */

        /* 
         * Польза:
         * Разделение ответственности-Бизнес-логика не зависит от SQL
         * Повторное использование кода - запросы находятся в одном месте
         * Удобство сопровождения - изменение структуры БД требует правок только в DAL
         * Тестируемость - легче подменять доступ к данным заглушками
         * Безопасность - проще централизированно использовать параметризированные запросы
         * 
         */

        /*
         * Паттерн репозиторий 
         * Алгоритм DAL
         * 1) Классы-модели-таблицы(то есть для каждой сущности делаем свой класс запрос) 
         * 
         */


        static void Main(string[] args)
        {
            string connect = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();


                CustomerModel c1 = DL.Castomer.ByID(3);
                Console.WriteLine(c1);

                int id = DL.Castomer.Insert(new CustomerModel (0,"FN_2","LN 3",DateTime.Now));
                Console.WriteLine(id);
/*
                List<CustomerModel> List = DL.Castomer.All();
                foreach (CustomerModel c in List)
                {
                    Console.WriteLine(c);
                }
*/

                //ADD2 
                int id2 = DL.Castomer.ADD2(new CustomerModel(0, "FN_2", "LN 3", DateTime.Now));
                Console.WriteLine(id2);
                
                //UPDATE
                CustomerModel cm = new CustomerModel(8,"FFF","LLL",DateTime.Now);
                DL.Castomer.Update(cm);

                DL.Castomer.Update(cm,7);//перегрузку сделала, можно и так и так




            }
        }
    }
}
