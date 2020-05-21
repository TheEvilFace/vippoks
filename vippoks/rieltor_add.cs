using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace vippoks
{
    public partial class rieltor_add : Form
    {
        const string API_URL = "http://213.80.189.122:6782/api";
        rieltor f;
        public rieltor_add(rieltor owner)
        {
            InitializeComponent();
            f = owner;
            this.FormClosing += new FormClosingEventHandler(this.rieltor_add_FormClosing);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rieltor_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            f.table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = API_URL + @"/realtors/create";

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

                // Переменная для чтения ответа
                string res;

                // Чтение ответа
                StreamReader reader = new StreamReader(response.GetResponseStream());
                res = reader.ReadToEnd();
                api_default create = JsonConvert.DeserializeObject<api_default>(res);
                MessageBox.Show("ты не петух. Клиент создан");
                this.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
