using System;
using System.Windows.Forms;

namespace vippoks
{
    public partial class ClientAdd : Form
    {
        private readonly ClientApiClient _clientApiClient;
        private Client clientForm;

        public ClientAdd(Client owner)
        {
            InitializeComponent();
            clientForm = owner;
            FormClosing += client_add_FormClosing;
            _clientApiClient = new ClientApiClient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _clientApiClient.Create(textBox1.Text, textBox2.Text,
                    textBox3.Text, textBox4.Text, textBox5.Text);
                Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }


        private void client_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientForm.table();
        }
    }
}