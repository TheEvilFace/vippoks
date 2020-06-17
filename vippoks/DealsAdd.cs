using System;
using System.Collections.Generic;
using System.Windows.Forms;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class DealsAdd : Form
    {
        private readonly DealsApiClient _dealsApiClient;
        private readonly Deals _dealsForm;
        private readonly NeedsApiClient _needApiClient;

        private readonly OffersApiClient _offerApiClient;
        private readonly List<NeedsEntity> needsEntities;

        private readonly List<OfferEntity> offersEntities;

        public DealsAdd(Deals owner)
        {
            InitializeComponent();
            _dealsApiClient = new DealsApiClient();
            _dealsForm = owner;
            FormClosing += DealsAdd_FormClosing;

            _offerApiClient = new OffersApiClient();
            _needApiClient = new NeedsApiClient();

            offersEntities = _offerApiClient.GetOffers();
            offer.DataSource = offersEntities;
            offer.DisplayMember = "GetOffer";
            offer.ValueMember = "id";

            needsEntities = _needApiClient.GetNeeds();
            need.DataSource = needsEntities;
            need.DisplayMember = "GetNeed";
            need.ValueMember = "id";
        }

        private void DealsAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dealsForm.table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                _dealsApiClient.Create(int.Parse(offer.SelectedValue.ToString()),
                    int.Parse(need.SelectedValue.ToString()));
                Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Calculation()
        {
            if (offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).realtor.part_percentage != 0)
                realtorsell.Text = ((Double.Parse(sell.Text) + Double.Parse(buy.Text)) * offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).realtor.part_percentage / 100).ToString();
            else
                realtorsell.Text = ((double.Parse(sell.Text) + double.Parse(buy.Text)) * 0.45).ToString();

            if (needsEntities.Find(x => x.id == int.Parse(need.SelectedValue.ToString())).realtor.part_percentage != 0)
                realtorbuy.Text = ((double.Parse(sell.Text) + double.Parse(buy.Text)) * needsEntities
                    .Find(x => x.id == int.Parse(need.SelectedValue.ToString())).realtor
                    .part_percentage / 100).ToString();
            else
                realtorbuy.Text = ((double.Parse(sell.Text) + double.Parse(buy.Text)) * 0.45).ToString();

            company.Text = (double.Parse(sell.Text) + double.Parse(buy.Text)).ToString();
        }

        private void offer_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (offer.SelectedIndex == 0) return;
                buy.Text = (offersEntities.Find(x => x.id == int.Parse(offer.SelectedValue.ToString())).price * 0.03)
                    .ToString();
                switch (offersEntities.Find(x => x.id == int.Parse(offer.SelectedValue.ToString())).realty_type.Name)
                {
                    case "Квартира":
                        sell.Text = (36000 + offersEntities.Find(x => x.id == int.Parse(offer.SelectedValue.ToString()))
                            .price * 0.01).ToString();
                        Calculation();
                        break;
                    case "Земля":
                        sell.Text = (30000 + offersEntities.Find(x => x.id == int.Parse(offer.SelectedValue.ToString()))
                            .price * 0.02).ToString();
                        Calculation();
                        break;

                    case "Дом":
                        sell.Text = (30000 + offersEntities.Find(x => x.id == int.Parse(offer.SelectedValue.ToString()))
                            .price * 0.01).ToString();
                        Calculation();
                        break;
                }
            }
            catch (Exception exp)   // Тут не нужно ловить Exception
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}