using System;
using System.Net;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using vippoks.Api.Entities;

namespace vippoks
{
    public partial class DealsAdd : Form
    {
        private readonly DealsApiClient _dealsApiClient;
        Deals _deals;

        private OffersApiClient _offerApiClient;
        private NeedsApiClient _needApiClient;

        List<OfferEntity> offersEntities;
        List<NeedsEntity> needsEntities;

        public DealsAdd(Deals owner)
        {
            InitializeComponent();
            _dealsApiClient = new DealsApiClient();
            _deals = owner;
            this.FormClosing += new FormClosingEventHandler(this.DealsAdd_FormClosing);

            _offerApiClient = new OffersApiClient();
            _needApiClient = new NeedsApiClient();

            offersEntities = _offerApiClient.GetTypes();
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
            _deals.table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                _dealsApiClient.Create(Int32.Parse(offer.SelectedValue.ToString()), Int32.Parse(need.SelectedValue.ToString()));
                this.Close();
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

        private void need_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void raschet()
        {
            if (offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).realtor.part_percentage != 0)
                realtorsell.Text = ((Double.Parse(sell.Text) + Double.Parse(buy.Text)) * offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).realtor.part_percentage / 100).ToString();
            else
                realtorsell.Text = ((Double.Parse(sell.Text) + Double.Parse(buy.Text)) * 0.45).ToString();

            if (needsEntities.Find(x => x.id == Int32.Parse(need.SelectedValue.ToString())).realtor.part_percentage != 0)
                realtorbuy.Text = ((Double.Parse(sell.Text) + Double.Parse(buy.Text)) * needsEntities.Find(x => x.id == Int32.Parse(need.SelectedValue.ToString())).realtor.part_percentage / 100).ToString();
            else
                realtorbuy.Text = ((Double.Parse(sell.Text) + Double.Parse(buy.Text)) * 0.45).ToString();

            company.Text = (Double.Parse(sell.Text) + Double.Parse(buy.Text)).ToString();
        }

        private void offer_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (offer.SelectedIndex == 0)
                {
                    return;
                }
                buy.Text = (offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).price * 0.03).ToString();
                switch (offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).realty_type.Name)
                {
                    case "Квартира":
                        sell.Text = (36000 + offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).price * 0.01).ToString();
                        raschet();
                        break;
                    case "Земля":
                        sell.Text = (30000 + offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).price * 0.02).ToString(); 
                        raschet();
                        break;

                    case "Дом":
                        sell.Text = (30000 + offersEntities.Find(x => x.id == Int32.Parse(offer.SelectedValue.ToString())).price * 0.01).ToString();
                        raschet();
                        break;
                }

            }
            catch(Exception exp)  // Тут не нужно ловить Exception
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
