using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson_2_Procedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connect = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                //ID
                #region
                /*             //dbo-то же самое что namespace 
                             //Делаем запрос, текст который хранится в процедуре
                             string custID = "dbo.stp_CustomerByID";

                             SqlCommand cmd = new SqlCommand(custID,conn);
                             //В качестве свойства типа команды, нужно сказать что это не строка, а процедура
                             cmd.CommandType = CommandType.StoredProcedure;

                             //Вызов команды с явным и не явным приведением типов
                             //Нам в процедуру сейчас нужно значение передать

                             //1 var явный тип
                             //SqlParameter отвечает за параметры если процедура их должна принимать и говорим какой у неё будет тип
                             *//*SqlParameter c_id = cmd.Parameters.Add("@customerId",SqlDbType.Int);
                             c_id.Value = 2; //А тут собственно значение, которое нам нужно*//*

                             //2 var неявный тип
                             cmd.Parameters.AddWithValue("@customerId", 2);
                             SqlDataReader reader = cmd.ExecuteReader();
                             while (reader.Read())
                             {
                                 var f0 = reader[0];
                                 var f1 = reader[1];
                                 var f2 = reader[3];
                                 Console.WriteLine($"ID: {f0,5} FirstName:{f1,15} LastName: {f2,15}");
                             }*/
                #endregion
                //ADD insert customer OUTPUT
                #region

                /*                string custId = "dbo.stp_CustomerAdd";
                                SqlCommand cmd = new SqlCommand(custId, conn);
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@FirstName", "Ella");
                                cmd.Parameters.AddWithValue("@LastName", "Chornogor");
                                cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.Now.ToShortDateString());

                                //Этот параметр будет возвращаться из процедуры с назначением явного типа
                                SqlParameter cust_id = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                                cust_id.Direction = ParameterDirection.Output;  //указываем, что это выходной параметр
                                                                                //и именно в него вернется в данном случае айди

                                cmd.ExecuteNonQuery();
                                Console.WriteLine((int)cust_id.Value);*/

                // var 2 SqlCommandBuilder  Работа по индексам
                //DeriveParametrs -из какой команды будут неявно команды указываться через индексы
                /*                string custId = "dbo.stp_CustomerAdd";
                                SqlCommand cmd = new SqlCommand(custId, conn);
                                cmd.CommandType = CommandType.StoredProcedure;

                                //В этой команде сопоставляй команды переменной с индексами, которые я ввожу
                                SqlCommandBuilder.DeriveParameters(cmd);

                                cmd.Parameters[1].Value = "NewFN";
                                cmd.Parameters[2].Value = "NewLN";
                                cmd.Parameters[3].Value = DateTime.Now.AddYears(-20).ToShortDateString();
                                cmd.Parameters[4].Value = DBNull.Value;
                                cmd.ExecuteNonQuery();

                                int new_id = (int)cmd.Parameters[4].Value;
                                Console.WriteLine(new_id);
                */
                #endregion

                //ADD insert customer Return
                #region

                /*                string custId = "dbo.stp_CustomerAdd_2";
                                SqlCommand cmd = new SqlCommand(custId, conn);

                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@FirstName", "Ivan");
                                cmd.Parameters.AddWithValue("@LastName", "Ivanov");
                                cmd.Parameters.AddWithValue("@DateOfBirth", "2000-05-10");

                                SqlParameter cust_id = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
                                //То же самое но здесь указываем что это возвращаемый параметр при генерации процедуры
                                cust_id.Direction = ParameterDirection.ReturnValue;

                                cmd.ExecuteNonQuery();
                                int new_id = (int)cmd.Parameters["@CustomerID"].Value; //Parameters[0].Value

                                Console.WriteLine(new_id);
                */

                //Var 2 
                /*              string custId = "dbo.stp_CustomerAdd_2";

                                SqlCommand cmd = new SqlCommand(custId, conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                SqlCommandBuilder.DeriveParameters(cmd);

                                cmd.Parameters[0].Value = DBNull.Value;   //индекс нулевой сразу создаем 
                                cmd.Parameters[1].Value = "NewFN_25";
                                cmd.Parameters[2].Value = "NewLN_25";
                                cmd.Parameters[3].Value = DateTime.Now.AddYears(-25).ToShortDateString();

                                cmd.ExecuteNonQuery();
                                int new_id = (int)cmd.Parameters[0].Value;
                                Console.WriteLine(new_id);*/
                #endregion

                //DELETE
                #region
                /*                string custId = "dbo.stp_CustomerDelete";

                                SqlCommand cmd = new SqlCommand(custId, conn);

                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@customerID", 5);

                                //Если мы создаем объект и нам нужен от неё параметр- мы объявляем явно output
                                //Когда мы удаляем ничего нового не будет и вернется то что есть
                                cmd.Parameters.AddWithValue("@Result", 0);

                                int res = cmd.ExecuteNonQuery();

                                WriteLine(res);
                */
                #endregion


                //ДЗ



                //stp_CustomerALL
                /*                string custALL = "stp_CustomerALL";
                                SqlCommand cmd= new SqlCommand(custALL, conn);
                                cmd.CommandType= CommandType.StoredProcedure;
                                SqlDataReader reader = cmd.ExecuteReader();
                                while (reader.Read())
                                {
                                    var F0 = reader[0];
                                    var F1 = reader[1];
                                    var F2 = reader[2];
                                    var F3 = reader[3];
                                    Console.WriteLine($"{F0,5} {F1,10} {F2,10} {F3,10}");
                                }*/

                //Update 
                string custUP = "dbo.stp_CustomerUpdate";

                SqlCommand cmd2 = new SqlCommand(custUP, conn);
                cmd2.CommandType = CommandType.StoredProcedure;

/*                cmd2.Parameters.AddWithValue("@id", 2);
                cmd2.Parameters.AddWithValue("@FirstName", "Name");
                cmd2.Parameters.AddWithValue("@LastName", "LastName");
                cmd2.Parameters.AddWithValue("@DateOfBirth", DateTime.Now.AddYears(-10));*/

                SqlCommandBuilder.DeriveParameters(cmd2);

                cmd2.Parameters[1].Value = 3;    //индекс нулевой сразу создаем 
                cmd2.Parameters[2].Value = "NewFN_3";
                cmd2.Parameters[3].Value = "NewLN_3";
                cmd2.Parameters[4].Value = DateTime.Now.AddYears(-25).ToShortDateString();

                cmd2.ExecuteNonQuery();
            }
        }
    }
}