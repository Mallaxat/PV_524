using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static System.Console;

namespace Lesson_1_Connection
{
    internal class Program
    {
        /* Connection - подключение с БД SqlConnection
         
         * Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
         * Server=(имя сервера) myServerAddress;Database= (наша база) myDataBase;Trusted_Connection=True;
         * Trusted_Connection=True;(это подключение через Вин-аутентификацию
         * 
         string connectionstring = "Data Source=127.0.0.1; Database=Academy; Trusted_Connection=True";
           // 1 вариант 
           SqlConnection conn = new SqlConnection();
           conn.ConnectionString = connectionstring;
           // 2 вариант
           SqlConnection conn = new SqlConnection(connectionstring);
           // 3 вариант создавая анонимную строку 
           SqlConnection conn = new SqlConnection("Data Source=127.0.0.1; Database=Academy; Trusted_Connection=True");


         
         * Query -запросы и команды
          нужно создавать КОМАНДЫ запросов

         * SqlCommand  -  
            * ExecuReader() - table                                                 Прочитать данные из таблицы с фильтром  
            * ExecuteScalar() - функции агрегирования (count, summ, avg, min/max )  Функции агрегирования(подсчет, мин мах и тд)
            * ExecuteNonQuery() - int, ( insert, update, delete)                    Запрос по выполнению действий к записям таблиц

         * Read query data - чтение данных
         */
        static void Main(string[] args)
        {
/*            string connectionstring = "Data Source=DESKTOP-SAUNGMH; Database=PV_524_CompanyDB_Lapkina; Trusted_Connection=True";
            //"Data Source=DESKTOP-SAUNGMH(в данном случае имя компа);

            //// 1 вариант 
            SqlConnection conn = new SqlConnection();       //Создаем объект класса для подключения
            conn.ConnectionString = connectionstring;       //ConnectionString использует строку используемую для открытия бд

            //// 2 вариант
            //SqlConnection conn = new SqlConnection(connectionstring); //все тоже самое но мы сразу передаем параметр в конструкторе
            //// 3 вариант создавая анонимную строку 
            ///Здесь в качестве конструктора просто строку сразу даем
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SAUNGMH; Database=PV_524_CompanyDB_Lapkina; Trusted_Connection=True");

            */
           
            string connect = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;
            //ConnectionString привести к типу одна строка из массива строк
            //При работе с внешними ресурсами using обязателен
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();                                         //Открывает подключение к БД
                                                                     //1) ExecuteReader()
                /*                string sqlcommand = "select * from dbo.Employee";    //Сам SQL - запрос

                                SqlCommand cmd = new SqlCommand(sqlcommand, conn);   //Объект команды с командой и то что откроет бд
                                SqlDataReader dr = cmd.ExecuteReader();              // SqlDataReader- по сути двумерный массив данных из бд

                                while (dr.Read())
                                {
                                    var f0 = dr["EmployeeID"]; 
                                    var f2 = dr["LastName"];
                                    var f5 = dr["Salary"];
                                    WriteLine($" {f0,5} {f2,15} {f5,10}");

                                }*/

                //2) ExecuteScalar()
                /*                string sqlcommand = "select sum(Salary) from Employee"; //SQL запрос
                                SqlCommand cmd = new SqlCommand(sqlcommand, conn);      //Объект команды с командой и то что откроет бд
                                object res = cmd.ExecuteScalar();
                                WriteLine($" Salary total = {res}");*/

                // 3) ExecuteNonQuery()
                /*
                                string sqlcommand = "insert into Position(PositionName) values('Boss')";

                                SqlCommand cmd=new SqlCommand(sqlcommand, conn);

                                object res=cmd.ExecuteNonQuery();

                                WriteLine(res);*/
                //delete
                /*               string sqlcommand = "delete Employee where Salary>=1800";
                               SqlCommand cmd = new SqlCommand(sqlcommand, conn);
                               object res = cmd.ExecuteNonQuery();
                               WriteLine(res);*/


                //UODATE
                string command = "UPDATE Employee " +
                    "SET FirstName='ПЕЕЕЕЕТР' " +
                    "WHERE EmployeeID=3";

                SqlCommand cmd = new SqlCommand(command,conn);
                Console.WriteLine($"Изменений: {cmd.ExecuteNonQuery()}");


                //чтение

                command = "select * from dbo.Employee";
                cmd.CommandText= command;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var f1 = reader["EmployeeID"];
                    var f2 = reader["FirstName"];
                    var f3 = reader["LastName"];
                    Console.WriteLine($"Айди: {f1,5} Имя:{f2,10} Фамилия: {f3,10}");


                }


            }







        }
    }
}
