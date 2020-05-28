using System;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace vippoks
{
    public partial class Realties : Form
    {
        private readonly RealtiesApiClient _realtiesApiClient;
        private DataTable dt;
        private int id;

        public Realties()
        {
            InitializeComponent();
            _realtiesApiClient = new RealtiesApiClient();
        }

        public void table()
        {
            var apiResponse = _realtiesApiClient.Get();

            dt = (DataTable)JsonConvert.DeserializeObject(apiResponse.response.ToString(), typeof(DataTable));

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

        private void change_lock()
        {
            textBox1.Enabled = !textBox1.Enabled;
            textBox2.Enabled = !textBox2.Enabled;
            comboBox1.Enabled = !comboBox1.Enabled;
            textBox3.Enabled = !textBox3.Enabled;
            textBox4.Enabled = !textBox4.Enabled;
            textBox5.Enabled = !textBox5.Enabled;
            textBox6.Enabled = !textBox6.Enabled;
            textBox7.Enabled = !textBox7.Enabled;
            textBox8.Enabled = !textBox8.Enabled;
            button4.Enabled = !button4.Enabled;
            button5.Enabled = !button5.Enabled;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                _realtiesApiClient.UpdateById(id,
                    textBox1.Text, textBox2.Text,
                    textBox3.Text, Int32.Parse(comboBox1.Text),
                    Int32.Parse(textBox4.Text), float.Parse(textBox5.Text),
                    Int32.Parse(textBox6.Text), textBox7.Text, 
                    textBox8.Text);
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Некорректно введены данные! Сообщение: {exp.Message}");
            }

            change_lock();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            change_lock();
        }

        private void Realties_Load(object sender, EventArgs e)
        {
            table();
            change_lock();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            change_lock();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
            id = Int32.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());

            textBox1.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][1].ToString();
            textBox2.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][2].ToString();
            textBox3.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString();

            textBox4.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][4].ToString();
            textBox5.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][5].ToString();
            textBox6.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][6].ToString();  
            textBox7.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][7].ToString();
            textBox8.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][8].ToString();
            textBox8.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][9].ToString();

            comboBox1.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][10].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _realtiesApiClient.Delete(id);
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }
    }
}
