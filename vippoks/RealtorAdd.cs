using System;
using System.Windows.Forms;

namespace vippoks
{
    public partial class RealtorAdd : Form
    {
        private readonly Realtor _realtor;
        private readonly RealtorApiClient _realtorApiClient;

        public RealtorAdd(Realtor owner)
        {
            InitializeComponent();
            _realtor = owner;
            FormClosing += rieltor_add_FormClosing;
            _realtorApiClient = new RealtorApiClient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rieltor_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            _realtor.table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _realtorApiClient.Create(textBox1.Text, textBox2.Text,
                    textBox3.Text, textBox4.Text);
                Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}