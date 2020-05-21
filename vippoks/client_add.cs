using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace vippoks
{
    public partial class client_add : Form
    {
        const string API_URL = "http://213.80.189.122:6782/api";
        public client_add(client owner)
        {
            InitializeComponent();
            f = owner;
            this.FormClosing += new FormClosingEventHandler(this.client_add_FormClosing);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = API_URL + @"/clients/create";

            // Заголовки запроса к API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json =   "{\"name\":\"" + textBox1.Text + "\"," +
                                "\"surname\":\"" + textBox2.Text + "\"," +
                                "\"patronymic\":\"" + textBox3.Text + "\", " +
                                "\"phone\":\"" + textBox4.Text + "\", " +
                                "\"email\":\"" + textBox5.Text + "\"}";
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

            }catch(Exception exp)
            {
                MessageBox.Show("Ты петух не верно данные ввел!");
            }
        }

        client f;

        private void client_add_FormClosing(object sender, FormClosingEventArgs e)
        {
                f.table();
        }
    }
}
