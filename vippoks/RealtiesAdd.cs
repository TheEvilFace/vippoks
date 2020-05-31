using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class RealtiesAdd : Form
    {
        private readonly RealtiesApiClient _realtiesApiClient;
        Realties _realties;
        public RealtiesAdd(Realties owner)
        {
            InitializeComponent();
            _realties = owner;
            this.FormClosing += new FormClosingEventHandler(this.RealtiesAdd_FormClosing);
            _realtiesApiClient = new RealtiesApiClient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RealtiesAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _realties.table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _realtiesApiClient.Create(Int32.Parse(floor.Text),
                city.Text, street.Text,
                house.Text, Int32.Parse(type_id.SelectedValue.ToString()),
                Int32.Parse(flat.Text), float.Parse(area.Text),
                Int32.Parse(floors_count.Text), latitude.Text,
                longitude.Text);
                this.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void RealtiesAdd_Load(object sender, EventArgs e)
        {
            List<RealtyTypeEntity> realtyTypeEntities = _realtiesApiClient.GetTypes();
            type_id.DataSource = realtyTypeEntities;
            type_id.DisplayMember = "Name";
            type_id.ValueMember = "Id";
        }
    }
}