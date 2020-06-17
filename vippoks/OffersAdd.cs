using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class OffersAdd : Form
    {
        private readonly ClientApiClient _clientApiClient;
        private readonly Offers _offers;
        private readonly OffersApiClient _offersApiClient;
        private readonly RealtiesApiClient _realtiesApiClient;
        private readonly RealtorApiClient _realtorApiClient;

        public OffersAdd(Offers owner)
        {
            InitializeComponent();
            _offers = owner;
            FormClosing += OffersAdd_FormClosing;
            _offersApiClient = new OffersApiClient();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OffersAdd_Load(object sender, EventArgs e)
        {
            _offers.table();
        }

        private void OffersAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _offersApiClient.Create(int.Parse(client.SelectedValue.ToString()),
                    int.Parse(realtor.SelectedValue.ToString()), double.Parse(price.Text),
                    int.Parse(type.SelectedValue.ToString()));
                Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}