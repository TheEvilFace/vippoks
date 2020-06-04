using System;
using System.Collections;
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
            dt = new DataTable();
            AddColumns();
        }
        public void table()
        {
            List<OfferEntity> offerEntities = _offersApiClient.GetTypes();
            FillDt(offerEntities);
            dataGridView1.DataSource = dt;
            try
            {
                if (dataGridView1.Columns.Contains("id"))
                    dataGridView1.Columns.Remove("id");

                if (dataGridView1.Columns.Contains("Client_id"))
                    dataGridView1.Columns.Remove("Client_id"); 

                if (dataGridView1.Columns.Contains("Realtor_id"))
                    dataGridView1.Columns.Remove("Realtor_id");

                if (dataGridView1.Columns.Contains("Realty_id"))
                    dataGridView1.Columns.Remove("Realty_id");
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

        private void FillDt(List<OfferEntity> offerEntities)
        {
            dt.Clear();
            foreach (var offerEntity in offerEntities)
            {
                DataRow row = dt.NewRow();

                row["id"]  = offerEntity.id;
                row["Price"]  = offerEntity.price;
                
                row["Client_id"] = offerEntity.client.id;
                row["Client"] = $@"{offerEntity.client.surname} {offerEntity.client.name} {offerEntity.client.patronymic}";
                
                row["Realtor_id"] = offerEntity.realtor.id;
                row["Realtor"] = $@"{offerEntity.realtor.surname} {offerEntity.realtor.name} {offerEntity.realtor.patronymic}";
                
                row["Realty_id"] = offerEntity.realty_type.Id;
                row["Realty"] = offerEntity.realty_type.Name;
                
                dt.Rows.Add(row);
            }
        }

        private void AddColumns()
        {
            dt.Columns.Add("id");
            dt.Columns.Add("Price");
            
            dt.Columns.Add("Client_id");
            dt.Columns.Add("Client");
            
            dt.Columns.Add("Realtor_id");
            dt.Columns.Add("Realtor");
            
            dt.Columns.Add("Realty_id");
            dt.Columns.Add("Realty");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _offersApiClient.Delete(id);
            table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                id = int.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OffersAdd f = new OffersAdd(this);
            f.Show();
        }
    }
}
