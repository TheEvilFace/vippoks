using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace vippoks
{
    public partial class RealtorAdd : Form
    {
        private RealtorApiClient _realtorApiClient;
        Realtor _realtor;
        public RealtorAdd(Realtor owner)
        {
            InitializeComponent();
            _realtor = owner;
            this.FormClosing += new FormClosingEventHandler(this.rieltor_add_FormClosing);
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
                this.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
