using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class NeedsAdd : Form
    {
        private readonly ClientApiClient _clientApiClient;
        private readonly Needs _needs;
        private readonly NeedsApiClient _needsApiClient;
        private readonly RealtiesApiClient _realtiesApiClient;
        private readonly RealtorApiClient _realtorApiClient;

        public NeedsAdd(Needs owner)
        {
            InitializeComponent();
            _needs = owner;
            FormClosing += NeedsAdd_FormClosing;
            _needsApiClient = new NeedsApiClient();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _needsApiClient.Create(int.Parse(client.SelectedValue.ToString()),
                    int.Parse(realtor.SelectedValue.ToString()), double.Parse(MinPrice.Text),
                    double.Parse(MaxPrice.Text), int.Parse(type.SelectedValue.ToString()));
                Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NeedsAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _needs.table();
        }
    }
}