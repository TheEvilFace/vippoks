﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
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
        public void table()
        {
            List<NeedsEntity> needsEntities = _needsApiClient.GetTypes();
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

        private void FillDt(List<NeedsEntity> offerEntities)
        {
            dt.Clear();
            foreach (var offerEntity in offerEntities)
            {
                DataRow row = dt.NewRow();

                row["id"] = offerEntity.id;
                row["MinPrice"] = offerEntity.minPrice;
                row["MaxPrice"] = offerEntity.maxPrice;

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
            price.Enabled = !price.Enabled;
            button4.Enabled = !button4.Enabled;
            button5.Enabled = !button5.Enabled;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                id = int.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());
                /*price.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][1].ToString();
                client.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString();
                realtor.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][5].ToString();
                type.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][7].ToString();*/
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* OffersAdd f = new OffersAdd(this);
            f.Show();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            change_lock();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*try
            {
                _needsApiClient.UpdateById(id,
                    Int32.Parse(client.SelectedValue.ToString()), Int32.Parse(realtor.SelectedValue.ToString()),
                    Double.Parse(price.Text), Int32.Parse(type.SelectedValue.ToString()));
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }*/
        }
    }
}
