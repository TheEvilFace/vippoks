using System;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace vippoks
{
    public partial class Realtor : Form
    {
        private readonly RealtorApiClient _realtorApiClient;
        private DataTable dt;
        private int id;


        public Realtor()
        {
            InitializeComponent();
            _realtorApiClient = new RealtorApiClient();
        }
        
        public void table()
        {
            var apiResponse = _realtorApiClient.Get();
            dt = (DataTable) JsonConvert.DeserializeObject(apiResponse.response.ToString(), typeof(DataTable));

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

        private void rieltor_Load(object sender, EventArgs e)
        {
            table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                id = int.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());
                textBox1.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][1].ToString();
                textBox2.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][2].ToString();
                textBox3.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString();
                textBox4.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][4].ToString();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _realtorApiClient.Delete(id);
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}"); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f1 = new RealtorAdd(this);
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
            try
            {
                _realtorApiClient.UpdateById(id,
                    textBox1.Text, textBox2.Text,
                    textBox3.Text, textBox4.Text);
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Некорректно введены данные! Сообщение: {exp.Message}");
            }

            change_lock();
        }
    }
}