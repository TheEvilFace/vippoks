using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data;
using System.IO;

namespace vippoks
{
    public partial class Client : Form
    {
        private readonly ClientApiClient _clientApiClient;
        DataTable dt;
        int id;
        public Client()
        {
            InitializeComponent();
            _clientApiClient = new ClientApiClient();
        }
        
        public void table()
        {
            ApiDefaultResponse apiResponse = _clientApiClient.Get();
            
            dt = (DataTable)JsonConvert.DeserializeObject(apiResponse.response.ToString(), (typeof(DataTable)));

            dataGridView1.DataSource = dt;
            try
            {
                dataGridView1.Columns.Remove("id");
            }
            catch(Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void client_Load(object sender, EventArgs e)
        {
            table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
            id = Int32.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());
            textBox1.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][1].ToString();
            textBox2.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][2].ToString();
            textBox3.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString();
            textBox4.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][4].ToString();
            textBox5.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][5].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _clientApiClient.Delete(id);
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientAdd f1 = new ClientAdd(this);
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void change_lock()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                _clientApiClient.UpdateById(id, 
                    textBox1.Text, textBox2.Text,
                    textBox3.Text, textBox4.Text, textBox5.Text);
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
            change_lock();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            change_lock();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ApiDefaultResponse apiResponse = _clientApiClient.FindUser(name.Text,
                    surname.Text, patronomic.Text);

                dt = (DataTable)JsonConvert.DeserializeObject(apiResponse.response.ToString(), (typeof(DataTable)));

                dataGridView1.DataSource = dt;
                try
                {
                    dataGridView1.Columns.Remove("id");
                }
                catch (Exception exp)
                {
                    MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }
    }
}
