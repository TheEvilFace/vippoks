using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class Needs : Form
    {
        private readonly NeedsApiClient _needsApiClient;
        private ClientApiClient _clientApiClient;
        private RealtorApiClient _realtorApiClient;
        private RealtiesApiClient _realtiesApiClient;
        private DataTable dt;
        private int id;

        public Needs()
        {
            InitializeComponent();
            _needsApiClient = new NeedsApiClient();
            dt = new DataTable();
            AddColumns();
            _clientApiClient = new ClientApiClient();
            _realtorApiClient = new RealtorApiClient();
            _realtiesApiClient = new RealtiesApiClient();
            
            this.InitCombos();
        }
        public void table()
        {
            List<NeedsEntity> needsEntities = _needsApiClient.GetNeeds();
            FillDt(needsEntities);
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

        private void Needs_Load(object sender, EventArgs e)
        {
            table();
            change_lock();
        }

        private void FillDt(List<NeedsEntity> needsEntities)
        {
            dt.Clear();
            foreach (var needsEntity in needsEntities)
            {
                DataRow row = dt.NewRow();

                row["id"] = needsEntity.id;
                row["MinPrice"] = needsEntity.minPrice;
                row["MaxPrice"] = needsEntity.maxPrice;

                row["Client_id"] = needsEntity.client.id;
                row["Client"] = $@"{needsEntity.client.surname} {needsEntity.client.name} {needsEntity.client.patronymic}";

                row["Realtor_id"] = needsEntity.realtor.id;
                row["Realtor"] = $@"{needsEntity.realtor.surname} {needsEntity.realtor.name} {needsEntity.realtor.patronymic}";

                row["Realty_id"] = needsEntity.realty_type.Id;
                row["Realty"] = needsEntity.realty_type.Name;

                dt.Rows.Add(row);
            }
        }

        private void AddColumns()
        {
            dt.Columns.Add("id");
            dt.Columns.Add("MinPrice");
            dt.Columns.Add("MaxPrice");

            dt.Columns.Add("Client_id");
            dt.Columns.Add("Client");

            dt.Columns.Add("Realtor_id");
            dt.Columns.Add("Realtor");

            dt.Columns.Add("Realty_id");
            dt.Columns.Add("Realty");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _needsApiClient.Delete(id);
            table();
        }

        private void change_lock()
        {
            type.Enabled = !type.Enabled;
            client.Enabled = !client.Enabled;
            realtor.Enabled = !realtor.Enabled;
            MinPrice.Enabled = !MinPrice.Enabled;
            MaxPrice.Enabled = !MaxPrice.Enabled;
            button4.Enabled = !button4.Enabled;
            button5.Enabled = !button5.Enabled;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                id = int.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());
                MinPrice.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][1].ToString();
                MaxPrice.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][2].ToString();
                client.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][4].ToString();
                realtor.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][6].ToString();
                type.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][8].ToString();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NeedsAdd f = new NeedsAdd(this);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            change_lock();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                _needsApiClient.UpdateById(id,
                    Int32.Parse(client.SelectedValue.ToString()), Int32.Parse(realtor.SelectedValue.ToString()),
                    Double.Parse(MinPrice.Text, CultureInfo.InvariantCulture), Double.Parse(MaxPrice.Text, CultureInfo.InvariantCulture),  
                    Int32.Parse(type.SelectedValue.ToString()));
                table();
                change_lock();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void InitCombos()
        {
            List<ClientEntity> clientEntities = _clientApiClient.GetClients();
            client.DataSource = clientEntities;
            client.DisplayMember = "GetInitials";
            client.ValueMember = "id";

            List<RealtorEntity> realtorEntities = _realtorApiClient.GetRealtors();
            realtor.DataSource = realtorEntities;
            realtor.DisplayMember = "GetInitials";
            realtor.ValueMember = "id";


            List<RealtyTypeEntity> realtyTypeEntities = _realtiesApiClient.GetTypes();
            type.DataSource = realtyTypeEntities;
            type.DisplayMember = "Name";
            type.ValueMember = "Id";
        }
    }
}
