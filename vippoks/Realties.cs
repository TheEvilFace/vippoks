﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;
using vippoks.Api.Entities;

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
            ApiDefaultResponse apiResponse = _realtiesApiClient.Get();

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

        private void change_lock()
        {
            city.Enabled = !city.Enabled;
            street.Enabled = !street.Enabled;
            type_id.Enabled = !type_id.Enabled;
            house.Enabled = !house.Enabled;
            flat.Enabled = !flat.Enabled;
            area.Enabled = !area.Enabled;
            floors_count.Enabled = !floors_count.Enabled;
            latitude.Enabled = !latitude.Enabled;
            longitude.Enabled = !longitude.Enabled;
            button4.Enabled = !button4.Enabled;
            button5.Enabled = !button5.Enabled;
            floor.Enabled = !floor.Enabled;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                _realtiesApiClient.UpdateById(id, int.Parse(floor.Text),
                    city.Text, street.Text,
                    house.Text, int.Parse(type_id.SelectedValue.ToString()),
                    int.Parse(flat.Text), float.Parse(area.Text),
                    int.Parse(floors_count.Text), latitude.Text,
                    longitude.Text);
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
            List<RealtyTypeEntity> TypeEntities = _realtiesApiClient.GetTypes();
            List<RealtyTypeEntity> realtyTypeEntities = _realtiesApiClient.GetTypes();

            type.DataSource = TypeEntities;
            type.DisplayMember = "Name";
            type.ValueMember = "Id";

            realtyTypeEntities.Remove(realtyTypeEntities.Find(x => x.Id == 4));
            type_id.DataSource = realtyTypeEntities;
            type_id.DisplayMember = "Name";
            type_id.ValueMember = "Id";
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
            id = int.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());

            city.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][1].ToString();
            street.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][2].ToString();
            house.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString();

            flat.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][4].ToString();
            floor.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][5].ToString();
            area.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][6].ToString();

            floors_count.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][7].ToString();
            latitude.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][8].ToString();
            longitude.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][9].ToString();

            type_id.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][10].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            RealtiesAdd realtiesAddForm = new RealtiesAdd(this);
            realtiesAddForm.Show();
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (type.SelectedIndex == 0) return;
                ApiDefaultResponse apiResponse = _realtiesApiClient.GetByType(int.Parse(type.SelectedValue.ToString()));

                dt = (DataTable) JsonConvert.DeserializeObject(apiResponse.response.ToString(), typeof(DataTable));

                dataGridView1.DataSource = dt;

                dataGridView1.Columns.Remove("id");
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ApiDefaultResponse apiResponse = _realtiesApiClient.FindByLatLong(float.Parse(x1.Text), float.Parse(у1.Text),
                    float.Parse(x2.Text), float.Parse(у2.Text));

                dt = (DataTable) JsonConvert.DeserializeObject(apiResponse.response.ToString(), typeof(DataTable));

                dataGridView1.DataSource = dt;

                dataGridView1.Columns.Remove("id");
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }
    }
}