using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace vippoks
{
    public partial class rieltor : Form
    {
        const string API_URL = "http://213.80.189.122:6782/api";
        public rieltor()
        {
            InitializeComponent();
        }
        DataTable dt;
        int id;

        public void table()
        {
            string url = API_URL + @"/realtors/get";

            // Заголовки запроса к API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";

            // Отправка запроса 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Переменная для чтения ответа
            string res;

            // Чтение ответа
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();

            api_default api_response = JsonConvert.DeserializeObject<api_default>(res);
            dt = (DataTable)JsonConvert.DeserializeObject(api_response.response.ToString(), (typeof(DataTable)));

            dataGridView1.DataSource = dt;
            try
            {
                dataGridView1.Columns.Remove("id");
            }
            catch (Exception e)
            {
                MessageBox.Show("Егор петух не добавил данных!");
            }
        }

        private void rieltor_Load(object sender, EventArgs e)
        {
            table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                id = Int32.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());
                textBox1.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][1].ToString();
                textBox2.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][2].ToString();
                textBox3.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString();
                textBox4.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][4].ToString();
            }
            catch(Exception exp)
            {

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string url = API_URL + @"/realtors/delete/" + id;
                // Заголовки запроса к API
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json";
                request.Method = "GET";

                // Отправка запроса 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Егор петух не добавил данных!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rieltor_add f1 = new rieltor_add(this);
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }
        private void change_lock()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string url = API_URL + @"/realtors/update/" + id;
            // Заголовки запроса к API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"name\":\"" + textBox1.Text + "\"," +
                                "\"surname\":\"" + textBox2.Text + "\"," +
                                "\"patronymic\":\"" + textBox3.Text + "\", " +
                                "\"part_percentage\":\"" + textBox4.Text + "\"}";
                streamWriter.Write(json);
            }
            try
            {
                // Отправка запроса 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Некорректно введены данные!");
            }
            change_lock();
        }
    }
}
