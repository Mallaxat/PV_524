using Lesson_3_DAL.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Lesson_3_DAL.DataLayer;

//System.Data;
//Lesson_3_DAL.Class; подключаем пространство имен


namespace Lesson_3_DAL.DataLayer
{
    internal class DL
    {
        //Не совсем правильный вариант, он должен быть свойством
        //string connect = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;
        public static string ConnectionString { get; set; } = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;


        static SqlConnection conn;

        public static class Castomer
        {
            //1 By ID
            public static CustomerModel ByID(int custID)
            {
                //Должны вернуть объект класса модели
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand getCust = new SqlCommand("stp_CustomerByID", conn);

                    getCust.Parameters.AddWithValue("customerID", custID);

                    getCust.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = getCust.ExecuteReader();

                    CustomerModel cm = null;

                    while (dr.Read())
                    {
                        int id = (int)dr[0];
                        string FirstName = dr[1].ToString();
                        string LastName = dr[2].ToString();
                        DateTime bd = DateTime.Parse(dr[3].ToString());
                        cm = new CustomerModel(id, FirstName, LastName, bd);
                    }
                    dr.Close();//Закрытие дата ридера
                    return cm;
                }

            }

            //2 INSERT
            public static int Insert(CustomerModel customer)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string cust_add = "dbo.stp_CustomerAdd";
                    SqlCommand cmd = new SqlCommand(cust_add, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(cmd);

                    cmd.Parameters[4].Value = DBNull.Value;//он был output поэтому он 4 индекс
                    cmd.Parameters[1].Value = customer.FirstName;
                    cmd.Parameters[2].Value = customer.LastName;
                    cmd.Parameters[3].Value = customer.DateOfBirth;

                    cmd.ExecuteNonQuery();

                    int new_id = (int)cmd.Parameters[4].Value;
                    return new_id;
                }
            }
            //3 ALL Customer
            public static List<CustomerModel> All()
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string cust_add = "dbo.stp_CustomerAll";
                    SqlCommand cmd = new SqlCommand(cust_add, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CustomerModel> list_customers = new List<CustomerModel>();
                    while (dr.Read())
                    {
                        list_customers.Add(new CustomerModel
                            (
                                (int)dr[0],
                                dr[1].ToString(),
                                dr[2].ToString(),
                                (DateTime)dr[3]
                            ));
                    }
                    dr.Close();
                    return list_customers;
                }
            }
            
            //3 DELETE
            public static int Delete(int id)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string custDel = "stp_CustomerDelete";
                    SqlCommand cmd = new SqlCommand(custDel, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerID", id);
                    cmd.Parameters.AddWithValue("@Result", id);
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }

            public static int ADD2(CustomerModel customer)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string custId = "dbo.stp_CustomerAdd_2";
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

                    return new_id;

                }
            }

            public static void Update(CustomerModel customer)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string custUP = "dbo.stp_CustomerUpdate";

                    SqlCommand cmd2 = new SqlCommand(custUP, conn);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    SqlCommandBuilder.DeriveParameters(cmd2);

                    cmd2.Parameters[1].Value = customer.ID;    //индекс нулевой сразу создаем 
                    cmd2.Parameters[2].Value = customer.FirstName;
                    cmd2.Parameters[3].Value = customer.LastName;
                    cmd2.Parameters[4].Value = customer.DateOfBirth;

                    cmd2.ExecuteNonQuery();
                }
            }

            public static void Update(CustomerModel customer,int index)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string custUP = "dbo.stp_CustomerUpdate";

                    SqlCommand cmd2 = new SqlCommand(custUP, conn);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    SqlCommandBuilder.DeriveParameters(cmd2);

                    cmd2.Parameters[1].Value = index;  
                    cmd2.Parameters[2].Value = customer.FirstName;
                    cmd2.Parameters[3].Value = customer.LastName;
                    cmd2.Parameters[4].Value = customer.DateOfBirth;

                    cmd2.ExecuteNonQuery();
                }
            }
        }

        }
    }
