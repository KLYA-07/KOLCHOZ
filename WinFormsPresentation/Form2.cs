using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace WinFormsPresentation
{
    public partial class ExchangeDialog : Form
    {
        private Farmer payer;
        private Farmer seller;

        public int exchangeCount;

        public ExchangeDialog(Farmer payer, Farmer seller)
        {
            InitializeComponent();

            this.payer = payer;
            this.seller = seller;

            RefreshExchangeField();

            productCount.Text = "0";
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            Farmer temp = payer;

            payer = seller;
            seller = temp;

            RefreshExchangeField();
        }

        private void RefreshExchangeField()
        {
            payerName.Text = payer.farmerName;
            sellerName.Text = seller.farmerName;

            financialCapital.Text = financialCapital.Text.Split(':').First() + ": " + payer.finacialCapital.ToString();

            for (int i = 0; i < seller.lastHarvest.Count; i++)
            {
                allProducts.Items.Add(seller.lastHarvest.Keys.ToList()[i]);
            }
            allProducts.SelectedIndex = 0;

            productCost.Text = productCost.Text.Split(':').First() + ": " + seller.harvestCosts[0].ToString();
        }

        private void allProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (exchangeCount > seller.lastHarvest[seller.lastHarvest.Keys.ToList()[allProducts.SelectedIndex]])
            {
                exchangeCount = seller.lastHarvest[seller.lastHarvest.Keys.ToList()[allProducts.SelectedIndex]];

                productCount.Text = productCount.Text.Split(':').First() + ": " + exchangeCount.ToString();
            }

            UpdateSum();
        }

        private void UpdateSum()
        {
            exchangeSum.Text = exchangeSum.Text.Split(':').First() + ": " + (seller.lastHarvest[seller.lastHarvest.Keys.ToList()[allProducts.SelectedIndex]] * exchangeCount).ToString();
        }

        private void productCount_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(productCost.Text, out int value) && value >= 0)
            {
                if(value <= seller.lastHarvest[seller.lastHarvest.Keys.ToList()[allProducts.SelectedIndex]])
                {
                    exchangeCount = value;
                    UpdateSum();
                }
                else
                {
                    MessageBox.Show("Указанное число превосходит количество имеющихся товаров.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("В этом поле разрешены только неотрицательные числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }
    }
}
