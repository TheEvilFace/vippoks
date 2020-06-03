using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class Offers : Form
    {
        private readonly OffersApiClient _offersApiClient;
        private DataTable dt;
        private int id;

        public Offers()
        {
            InitializeComponent();
            _offersApiClient = new OffersApiClient();
        }
        public void table()
        {
            var apiResponse = _offersApiClient.GetTypes(); ;

            // dt = (DataTable)apiResponse;

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

        private void Offers_Load(object sender, EventArgs e)
        {
            table();
        }
    }
}
