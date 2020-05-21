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
        private ApiClient apiClient;
        
        
        public Form1()
        {
            InitializeComponent();
            apiClient = new ApiClient();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isAuth = apiClient.Auth(textBox1.Text, textBox2.Text);
            if (isAuth)
            {
                Главное_меню f1 = new Главное_меню();
                f1.Show();
            }else {
                MessageBox.Show("Пароль и/или логин неверны!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
