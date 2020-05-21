using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace vippoks
{
    public partial class Form1 : Form
    {
        const string API_URL = "http://213.80.189.122:6782/api";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = API_URL + @"/auth";

            // Заголовки запроса к API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"login\":\"" + textBox1.Text + "\",\"password\":\"" + textBox2.Text + "\"}";
                streamWriter.Write(json);
            }

            // Отправка запроса 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Переменная для чтения ответа
            string res;

            // Чтение ответа
            StreamReader reader = new StreamReader(response.GetResponseStream());
            res = reader.ReadToEnd();
            api_default auth = JsonConvert.DeserializeObject<api_default>(res);
            if (auth.response.Equals(true))
            {
                Главное_меню f1 = new Главное_меню();
                f1.Show();
            }else {
                MessageBox.Show("Дарова епта, пароль или логин не правильный!");
            }
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
