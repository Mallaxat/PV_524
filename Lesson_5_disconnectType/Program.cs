using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson_5_disconnectType
{

    /*
     * Создать адаптер (1 таблица 1 адаптер) -SqlDataAdapter
     * Какую таблицу читать(копировать)
     * Создаем объект DataSet для таблиц, которые сюда будет кешировать -DataTable->DataRow(есть строки и считываем по строкам)
     * Запросы без изменений
     * Запросы с изменениями из DataSet обновляем данные сервера
     * 
     */

    internal class Program
    {

        public static void All_position(SqlConnection conn)
        {
            //All_position
            string com_pos = "Select* from Position order by 2";
            //Принимает команду и в неё можно положить сразу проццедуру
            SqlDataAdapter pos_all_adapter = new SqlDataAdapter(com_pos, conn);

            //Считает данные из базы, которые мы использовали в команде
            //По сути готовая табличка считанная из базы
            SqlCommandBuilder cmd_position = new SqlCommandBuilder(pos_all_adapter);
            //Куда будем кешировать данные
            DataSet ds_pos = new DataSet();
            pos_all_adapter.Fill(ds_pos, "Positions");//Заполняем датасет,можно дать название запасной таблицы

            //Это уже скешированные данные
            DataTable dt_pos = ds_pos.Tables["Positions"];
            foreach (DataRow item in dt_pos.Rows)
            {
                Console.WriteLine($"{item[0],5} {item[1],15}");
            }

        }

        public static void All_Customer_Procedure(SqlConnection conn)
        {
            SqlDataAdapter cust_adapter = new SqlDataAdapter();

            cust_adapter.InsertCommand = new SqlCommand("stp_CustomerALL", conn);
            cust_adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            cust_adapter.SelectCommand = cust_adapter.InsertCommand;
            //По сути нужен, чтобы не писать заголовки а работать по индексам
            SqlCommandBuilder cmd_cust = new SqlCommandBuilder(cust_adapter);

            //Куда будем кешировать данные
            DataSet ds_cust = new DataSet();
            cust_adapter.Fill(ds_cust, "Customers");//Заполняем датасет,можно дать название запасной таблицы

            //Это уже скешированные данные
            DataTable dt_cust = ds_cust.Tables["Customers"];

            foreach (DataRow item in dt_cust.Rows)
            {
                Console.WriteLine($"{item[0],5} {item[2],15} {Convert.ToDateTime(item[3]).ToShortDateString(),15}");
            }

        }

        public static void ADD_Customer(SqlConnection conn)
        {
            //Создаем адаптер и выбираем всех кастомеров для адаптер
            SqlDataAdapter cust_add_adap = new SqlDataAdapter("select *from dbo.Customers", conn);
            SqlCommandBuilder cm_builder = new SqlCommandBuilder(cust_add_adap);

            DataSet ds_c = new DataSet();

            cust_add_adap.Fill(ds_c, "Customers");
            DataTable dt_customers = ds_c.Tables["Customers"];
            //Здесь начинаются изменения
            //Создаем новую строку для объекта DataTable
            DataRow new_cust = dt_customers.NewRow();
            //Благодаря  SqlCommandBuilder берем не название столбцов, а индексов 
            new_cust[1] = "New_cust_fn";
            new_cust[2] = "New_cust_ln";
            new_cust[3] = DateTime.Now.ToShortDateString();

            //В коллекцию строк добавляем запись но в кеш данные, не в бд
            dt_customers.Rows.Add(new_cust);

            foreach (DataRow item in dt_customers.Rows)
            {
                WriteLine($" {item[0],5} {item[2],15} {Convert.ToDateTime(item[3]).ToShortDateString(),15}");
            }
            //Обновление самой БД
            WriteLine("-------------------------------");
            //Обновляем данные которые были в DataSet(измененные куда мы добавили строку)
            cust_add_adap.Update(ds_c, "Customers");
            //Очищаем буфер отключенных данных
            dt_customers.Clear();
            //Заполняем DataSet актуальными данными из БД
            cust_add_adap.Fill(ds_c, "Customers");

            foreach (DataRow item in dt_customers.Rows)
            {
                WriteLine($" {item[0],5} {item[2],15} {Convert.ToDateTime(item[3]).ToShortDateString(),15}");
            }


        }

        public static void DELETE_Customer(SqlConnection conn,int num)
        {
            // 4 delete
            SqlDataAdapter cust_add_adap = new SqlDataAdapter("select * from dbo.Customers", conn);
            SqlCommandBuilder cm_builder = new SqlCommandBuilder(cust_add_adap);
            DataSet ds_c = new DataSet();
            cust_add_adap.Fill(ds_c, "Customers");
            DataTable dt_customers = ds_c.Tables["Customers"];
            dt_customers.PrimaryKey = new DataColumn[] { dt_customers.Columns["id"] };
            DataRow row_del = dt_customers.Rows.Find(num);
            row_del.Delete();

            WriteLine("-------------------------------");
            cust_add_adap.Update(ds_c, "Customers");
            dt_customers.Clear();
            cust_add_adap.Fill(ds_c, "Customers");

            foreach (DataRow item in dt_customers.Rows)
            {
                WriteLine($" {item[0],5} {item[2],15} {Convert.ToDateTime(item[3]).ToShortDateString(),15}");
            }

        }

        public static bool Delete_Proc(SqlConnection conn, int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers", conn);

            adapter.DeleteCommand = new SqlCommand("stp_CustomerDelete", conn);

            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;

            // Входной параметр 
            adapter.DeleteCommand.Parameters.Add("@customerID",SqlDbType.Int, 0,"id");
            //DataRowVersion.Original по идее говорит взять значение каким было из базы загружено
            adapter.DeleteCommand.Parameters["@customerID"].SourceVersion = DataRowVersion.Original;

            // Выходной параметр 
            adapter.DeleteCommand.Parameters.Add("@Result",SqlDbType.Bit);
            adapter.DeleteCommand.Parameters["@Result"].Direction = ParameterDirection.Output;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Customers");

            DataTable dt = ds.Tables["Customers"];

            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            DataRow row = dt.Rows.Find(id);

            if (row == null) return false;
            row.Delete();
            adapter.Update(ds, "Customers");
            ds.Clear();
            adapter.Fill(ds,"Customers");
            return Convert.ToBoolean(adapter.DeleteCommand.Parameters["@Result"].Value);
        }

        public static void Update(SqlConnection conn, int index)
        {
            string command = "select * from dbo.Customers";
            SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
            SqlCommandBuilder bilder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            //Находим колонку, по которой будет искать и обновлять данные
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            //Находим в строке нужный нам индекс
            DataRow row = dt.Rows.Find(index);
            row[1] = "Fedr";
            row[2] = "FedrFedr";
            row[3] = DateTime.Now.ToShortDateString();

            foreach (DataRow i in dt.Rows)
            {
                Console.WriteLine($"{i[0],5} {i[1],5} {i[2],5} {i[3],5} ");
            }

            adapter.Update(dt);
            ds.Clear();
            adapter.Fill(ds);
        }
        public static void Update_Proc(SqlConnection conn, int index)
        {
            //Это команда для заполнения дт 
            string command = "select * from dbo.Customers";
            //Это хранение процедуры
            string selectcommand = "stp_CustomerUpdate";


            SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
            //Говорим что есть команда апдейт и она процедура
            adapter.UpdateCommand = new SqlCommand(selectcommand, conn);
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;


            //SqlCommandBuilder bilder = new SqlCommandBuilder(adapter);

            //Заполняем нужные для процедуры параметры
            adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            adapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NChar, 50, "FirstName");
            adapter.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NChar, 50, "LastName");
            adapter.UpdateCommand.Parameters.Add("@DateOfBirth", SqlDbType.Date, 0, "DateOfBirth");


            //Тут получается идет заполнение данных
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];

            //Находим колонку, по которой будет искать и обновлять данные
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            //Находим в строке нужный нам индекс
            DataRow row = dt.Rows.Find(index);
            row[1] = "Ivan";
            row[2] = "Ivan";
            row[3] = DateTime.Now.ToShortDateString();

            adapter.Update(dt);
        }

        static void Main(string[] args)
        {
            string connect = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                //All_position
                //Console.WriteLine("All_position");
                //All_position(conn);

                //Console.WriteLine();

                //ALL ustomers procedure
                //Console.WriteLine("ALL ustomers procedure");
                //All_Customer_Procedure(conn);

                //До этого мы работали без обновления
                //Console.WriteLine();

                //Add Customer
                //Console.WriteLine("Add_Customer");
                //ADD_Customer(conn);


                //ДЗ МЕТОДЫ ДЛЯ СТРУКТУРИЗАЦИИ, А НЕ КАК ЧТО-ТО МАСШТАБИРУЕМОЕ

                //Delete
                //DELETE_Customer(conn, 7);
                //bool result =Delete_Proc(conn, 10);
                //Console.WriteLine(result);

                //Update Запрос
                Update(conn,8);

                //Update Процедура
                Update_Proc(conn, 9);


            }
        }
    }
}
