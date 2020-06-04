using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class OffersAdd : Form
    {
        private OffersApiClient _offersApiClient;
        private ClientApiClient _clientApiClient;
        private RealtorApiClient _realtorApiClient;
        private RealtiesApiClient _realtiesApiClient;
        Offers _offers;
        public OffersAdd(Offers owner)
        {
            InitializeComponent();
            _offers = owner;
            this.FormClosing += new FormClosingEventHandler(this.OffersAdd_FormClosing);
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
                _offersApiClient.Create(Int32.Parse(client.SelectedValue.ToString()), 
              Int32.Parse(realtor.SelectedValue.ToString()) , Double.Parse(price.Text),
              Int32.Parse(type.SelectedValue.ToString()));
                this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
