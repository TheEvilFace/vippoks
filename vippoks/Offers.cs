using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class Offers : Form
    {
        private readonly OffersApiClient _offersApiClient;
        private readonly ClientApiClient _clientApiClient;
        private readonly RealtiesApiClient _realtiesApiClient;
        private readonly RealtorApiClient _realtorApiClient;
        private readonly DataTable dt;
        private int id;

        public Offers()
        {
            InitializeComponent();
            _offersApiClient = new OffersApiClient();
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
            realtyTypeEntities.Remove(realtyTypeEntities.Find(x => x.Id == 4));
            type.DataSource = realtyTypeEntities;
            type.DisplayMember = "Name";
            type.ValueMember = "Id";


            List<ClientEntity> comboClientEntities = _clientApiClient.GetClients();
            comboClientEntities.Add(new ClientEntity
                {name = " ", id = 0, patronymic = " ", surname = "Любой", phone = " ", email = " "});
            comboClient.DataSource = comboClientEntities;
            comboClient.DisplayMember = "GetInitials";
            comboClient.ValueMember = "id";

            var comboRealtorEntities = _realtorApiClient.GetRealtors();
            comboRealtorEntities.Add(new RealtorEntity
                {name = " ", id = 0, part_percentage = 0, patronymic = " ", surname = "Любой"});
            rieltor.DataSource = comboRealtorEntities;
            rieltor.DisplayMember = "GetInitials";
            rieltor.ValueMember = "id";
        }

        public void table()
        {
            List<OfferEntity> offerEntities = _offersApiClient.GetOffers();
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
            change_lock();
        }

        private void FillDt(List<OfferEntity> offerEntities)
        {
            dt.Clear();
            foreach (var offerEntity in offerEntities)
            {
                DataRow row = dt.NewRow();

                row["id"] = offerEntity.id;
                row["Price"] = offerEntity.price;

                row["Client_id"] = offerEntity.client.id;
                row["Client"] =
                    $@"{offerEntity.client.surname} {offerEntity.client.name} {offerEntity.client.patronymic}";

                row["Realtor_id"] = offerEntity.realtor.id;
                row["Realtor"] =
                    $@"{offerEntity.realtor.surname} {offerEntity.realtor.name} {offerEntity.realtor.patronymic}";

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
                price.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][1].ToString();
                client.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString();
                realtor.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][5].ToString();
                type.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][7].ToString();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new OffersAdd(this);
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
                _offersApiClient.UpdateById(id,
                    int.Parse(client.SelectedValue.ToString()), int.Parse(realtor.SelectedValue.ToString()),
                    double.Parse(price.Text, CultureInfo.InvariantCulture), int.Parse(type.SelectedValue.ToString()));
                change_lock();
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var offerEntities = _offersApiClient.Find(int.Parse(comboClient.SelectedValue.ToString()),
                int.Parse(rieltor.SelectedValue.ToString()));
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
    }
}