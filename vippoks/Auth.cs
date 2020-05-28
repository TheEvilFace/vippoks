using System;
using System.Windows.Forms;

namespace vippoks
{
    public partial class Auth : Form
    {
        private readonly AuthApiClient _authApiClient;
        
        public Auth()
        {
            InitializeComponent();
            _authApiClient = new AuthApiClient();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isAuth = _authApiClient.Auth(textBox1.Text, textBox2.Text);
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
