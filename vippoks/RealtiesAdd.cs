using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class RealtiesAdd : Form
    {
        private readonly RealtiesApiClient _realtiesApiClient;
        private readonly Realties _realties;

        public RealtiesAdd(Realties owner)
        {
            InitializeComponent();
            _realties = owner;
            FormClosing += RealtiesAdd_FormClosing;
            _realtiesApiClient = new RealtiesApiClient();

            List<RealtyTypeEntity> realtyTypeEntities = _realtiesApiClient.GetTypes();
            type_id.DataSource = realtyTypeEntities;
            type_id.DisplayMember = "Name";
            type_id.ValueMember = "Id";
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
                _realtiesApiClient.Create(int.Parse(floor.Text),
                    city.Text, street.Text,
                    house.Text, int.Parse(type_id.SelectedValue.ToString()),
                    int.Parse(flat.Text), float.Parse(area.Text),
                    int.Parse(floors_count.Text), latitude.Text,
                    longitude.Text);
                Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}