using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_6_WF
{
    public partial class Form2 : Form
    {

        SqlConnection conn = null;
        SqlDataAdapter adapter= null;
        DataSet dataSet = null;
        string str = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;
        string filename = "";
        SqlCommandBuilder cmd= null;

        public Form2()
        {
            InitializeComponent();
            conn = new SqlConnection(str);
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            //Открываем диалоговое окно
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Графические файлы |*.bmp; *.png; *.jpeg; *.jpg;*.gif";
            //
            ofd.FileName = "";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filename=ofd.FileName;
                LoadPicture();
            }




        }

        private void LoadPicture()
        {
            try
            {
                //Создаем массив байтов
                byte[] bytes = CreateCopy();
                //Открываем соединение
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.Pictures(Customer_ID,_Name,Picture)" +
                    "values (@customerID, @name, @picture);", conn);

                if (textBox1.Text == null || textBox1.Text.Length == 0) return;
                int index = -1; // 0 Это уже выбранный элемент поэтому -1

                int.TryParse(textBox1.Text, out index);

                cmd.Parameters.Add("@customerID", SqlDbType.Int).Value = index;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 255).Value = filename;
                cmd.Parameters.Add("@picture", SqlDbType.Image, bytes.Length).Value = bytes;

                cmd.ExecuteNonQuery();
            }
            catch (Exception) 
            {
               MessageBox.Show("Error");
            }
            finally
            {
                if (conn.State == ConnectionState.Open || conn!=null) conn.Close();
            }
        }

        //Метод который будет картинку подгружать в виде байтов
        private byte[] CreateCopy()
        {
            //filename-это как раз подгруженная картинка
            try
            {
                //Новый класс хранящий изображение
                Image img = Image.FromFile(filename); //FromFile(filename); загружаем картинку

                int maxWidth = 300, maxHeight = 300; //Размер изображения нужный = размер элемента

                //Находим коэфицент масштабирования 
                double ratioX = (double)maxWidth / img.Width;        //
                double ratioY = (double)maxHeight / img.Height;      //
                double ratio = Math.Min(ratioX, ratioY);             //

                //Создаем размеры с нужным нам масштабом
                int newWidth = (int)(img.Width * ratio);
                int newHeight = (int)(img.Height * ratio);

                Image im = new Bitmap(newWidth, newHeight);     //Создаем новую картинку через битмап с новыми свойствами
                Graphics g = Graphics.FromImage(im);            //Загружаем в графику битмап
                g.DrawImage(img, 0, 0, newWidth, newHeight);    //В график объект загружаем нашу картинку, с новыми размерами
                
                MemoryStream ms = new MemoryStream();           //Класс для считывания потока в бинарном формате
                im.Save(ms, ImageFormat.Jpeg);                  //Сохраняем через поток картинку с нужным форматом
                ms.Flush();                                     //Для предотвращения многопоточной загрузки
                ms.Seek(0, SeekOrigin.Begin);                   //Определяет, октуда читать поток SeekOrigin.Begin сколько читать -все
               
                BinaryReader br = new BinaryReader(ms);         //Объект для чтения потока с уже считанным потоком
                byte[] buf = br.ReadBytes((int)ms.Length);      //Преобразуем поток в байты
                return buf;

            }
            catch (Exception)
            {
                MessageBox.Show("Error CreateCopy");
                return null; 
            }

        }

        private void bt_show_one_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == null || textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Укажите id клиента");
                    return;
                }
                int index = -1;
                int.TryParse(textBox1.Text, out index);
                if (index == -1)
                {
                    MessageBox.Show("Укажите id клиента  в правильном формате");
                    return;
                }
                adapter = new SqlDataAdapter("select Picture from dbo.Pictures where Customer_ID=@Id", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(adapter);
                adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = index;
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                byte[] bytes = (byte[])dataSet.Tables[0].Rows[0]["Picture"];
                //открываем поток
                MemoryStream ms = new MemoryStream(bytes);
                //в свойство элемента WF загружаем картинку через метод считывания потока
                pictureBox1.Image = Image.FromStream(ms);

            }
            catch (Exception)
            {
                MessageBox.Show("Error bt_show_one");
            }
            finally
            {
                if (conn.State == ConnectionState.Open || conn != null) conn.Close();

            }
        }

        private void bt_show_all_Click(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("select * from dbo.Pictures;", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(adapter);
                dataSet = new DataSet();
                adapter.Fill(dataSet, "Picture");
                dataGridView1.DataSource = dataSet.Tables["Picture"];

            }
            catch (Exception)
            {
                MessageBox.Show("Error bt_show_all");
            }
            finally
            {
                if (conn.State == ConnectionState.Open || conn != null) conn.Close();

            }
        }
    }
}
