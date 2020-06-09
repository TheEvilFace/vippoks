using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class NeedsAdd : Form
    {
        private NeedsApiClient _needsApiClient;
        private ClientApiClient _clientApiClient;
        private RealtorApiClient _realtorApiClient;
        private RealtiesApiClient _realtiesApiClient;
        Needs _needs;
        public NeedsAdd(Needs owner)
        {
            InitializeComponent();
            _needs = owner;
            this.FormClosing += new FormClosingEventHandler(this.NeedsAdd_FormClosing);
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
                _needsApiClient.Create(Int32.Parse(client.SelectedValue.ToString()),
              Int32.Parse(realtor.SelectedValue.ToString()), Double.Parse(MinPrice.Text),
              Double.Parse(MaxPrice.Text), Int32.Parse(type.SelectedValue.ToString()));
                this.Close();
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
