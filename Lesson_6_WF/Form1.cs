using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_6_WF
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter=null;
        DataSet data_set=null;
        string str = "";
        SqlCommandBuilder cmd = null;


        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            str = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;
            conn.ConnectionString = str;
        }

        private void bt_fill_Click(object sender, EventArgs e)
        {
            try
            {
                conn= new SqlConnection(str);
                data_set = new DataSet();
                string sql_command = textBox1.Text;
                adapter = new SqlDataAdapter(sql_command, conn);
                cmd = new SqlCommandBuilder(adapter);

                adapter.Fill(data_set,"Table_1");
                //Источник дата грид
                //Может быть много таблиц но в разном порядке, поэтому лучше обратить по имени таблиц
                dataGridView1.DataSource = data_set.Tables["Table_1"];

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            adapter.Update(data_set, "Table_1");
        }
    }
}
