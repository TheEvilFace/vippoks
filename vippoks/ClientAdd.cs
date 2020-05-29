using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace vippoks
{
    public partial class ClientAdd : Form
    {
        private ClientApiClient _clientApiClient;
        
        public ClientAdd(Client owner)
        {
            InitializeComponent();
            f = owner;
            this.FormClosing += new FormClosingEventHandler(this.client_add_FormClosing);
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
                    textBox3.Text, textBox4.Text, textBox5.Text );
                this.Close();

            }catch(Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}"); 
            }
        }

        Client f;

        private void client_add_FormClosing(object sender, FormClosingEventArgs e)
        {
                f.table();
        }
    }
}
