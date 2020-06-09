using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class Deals : Form
    {
        private readonly DealsApiClient _dealsApiClient;

        private OffersApiClient _offerApiClient;
        private NeedsApiClient _needApiClient;

        private DataTable dt;
        private int id;

        public Deals()
        {
            InitializeComponent();
            _dealsApiClient = new DealsApiClient();
            dt = new DataTable();
            AddColumns();
            _offerApiClient = new OffersApiClient();
            _needApiClient = new NeedsApiClient();

            List<OfferEntity> offersEntities = _offerApiClient.GetTypes();
            offer.DataSource = offersEntities;
            offer.DisplayMember = "GetOffer";
            offer.ValueMember = "id";
            
            List<NeedsEntity> needsEntities = _needApiClient.GetNeeds();
            need.DataSource = needsEntities;
            need.DisplayMember = "GetNeed";
            need.ValueMember = "id";
        }
        public void table()
        {
            List<DealEntity> dealsEntities = _dealsApiClient.GetTypes();
            FillDt(dealsEntities);
            dataGridView1.DataSource = dt;
            try
            {
                if (dataGridView1.Columns.Contains("id"))
                    dataGridView1.Columns.Remove("id");

                if (dataGridView1.Columns.Contains("Offers_id"))
                    dataGridView1.Columns.Remove("Offers_id");

                if (dataGridView1.Columns.Contains("Needs_id"))
                    dataGridView1.Columns.Remove("Needs_id");
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void Deals_Load(object sender, EventArgs e)
        {
            table();
            change_lock();
        }

        private void FillDt(List<DealEntity> dealsEntities)
        {
            dt.Clear();
            foreach (var dealEntity in dealsEntities)
            {
                DataRow row = dt.NewRow();

                row["id"] = dealEntity.id;

                row["Offers_id"] = dealEntity.offers.id;
                row["Offers"] = $@"{dealEntity.offers.client.GetInitials} {" цена:"} {dealEntity.offers.price}";

                row["Needs_id"] = dealEntity.needs.id;
                row["Needs"] = $@"{dealEntity.needs.client.GetInitials} {" мин:"} {dealEntity.needs.minPrice} {" макс:"} {dealEntity.needs.maxPrice} ";

                dt.Rows.Add(row);
            }
        }

        private void AddColumns()
        {
            dt.Columns.Add("id");

            dt.Columns.Add("Offers_id");
            dt.Columns.Add("Offers");

            dt.Columns.Add("Needs_id");
            dt.Columns.Add("Needs");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _dealsApiClient.Delete(id);
            table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void change_lock()
        {
            offer.Enabled = !offer.Enabled;
            need.Enabled = !need.Enabled;
            button4.Enabled = !button4.Enabled;
            button5.Enabled = !button5.Enabled;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                id = int.Parse(dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString());
                offer.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][2].ToString();
                need.Text = dt.Rows[dataGridView1.CurrentCell.RowIndex][4].ToString();
            }
            catch (Exception exp)
            {
                MessageBox.Show($@"Что-то пошло не так! Сообщение: {exp.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DealsAdd f = new DealsAdd(this);
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
                _dealsApiClient.UpdateById(id,
                    Int32.Parse(offer.SelectedValue.ToString()), Int32.Parse(need.SelectedValue.ToString()));
                change_lock();
                table();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            change_lock();
        }
    }
}
