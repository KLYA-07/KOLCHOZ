using System;
using System.Diagnostics.CodeAnalysis;
using Model;

namespace WinFormsPresentation
{
    public partial class FarmForm : Form
    {
        private Logic logic;
        public FarmForm()
        {
            InitializeComponent();

            logic = new Logic();

            logic.AddFarmer(new Farmer("Виктор", 55000, 37.5f,
                new Dictionary<string, int>()
                {
                    { "Кукуруза", 30 },
                    { "Свекла", 25 },
                    { "Картофель", 200 },
                    { "Курица", 7 }
                }, new List<int>()
                {
                    { 100 },
                    { 75 },
                    { 20 },
                    { 250 }
                }, new List<string>()
                {
                    { "Свинья" },
                    { "Курица" }
                }, new List<string>()
                {
                    { "Кукуруза" },
                    { "Свекла" },
                    { "Подсолнух" }
                }));

            RefreshFarmersList();
        }

        public void RefreshFarmersList()
        {
            farmerList.Items.Clear();

            foreach (Farmer farmer in logic.AllFarmers)
            {
                farmerList.Items.Add(farmer.farmerName);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Farmer farmer = new Farmer("Новый фермер", 0, 0, new Dictionary<string, int>(), new List<int>(), new List<string>(), new List<string>());
            logic.AddFarmer(farmer);

            SetupFarmer(logic.AllFarmers.Count - 1);

            RefreshFarmersList();
        }

        private void changeFarmer_Click(object sender, EventArgs e)
        {
            if (farmerList.SelectedItems.Count != 1)
            {
                MessageBox.Show("Выберите одного фермера для настройки.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetupFarmer(farmerList.SelectedIndex);
        }

        private void SetupFarmer(int index)
        {
            Farmer neededfarmer = logic.AllFarmers[index];
            Farmer sendFarmer = new Farmer(neededfarmer.farmerName, neededfarmer.finacialCapital, neededfarmer.fieldSize, new Dictionary<string, int>(neededfarmer.lastHarvest), new List<int>(neededfarmer.harvestCosts), new List<string>(neededfarmer.cattleHeadboard), new List<string>(neededfarmer.cultivatingCrops));

            SetupDialog setupDialog = new SetupDialog(sendFarmer);
            setupDialog.ShowDialog(this);

            RefreshFarmersList();

            logic.ChangeFarmer(index, sendFarmer);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (farmerList.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите ", "Ошибка ввода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < farmerList.SelectedItems.Count; i++)
                    {
                        logic.RemoveFarmer(farmerList.Items.IndexOf(farmerList.SelectedItems[i]));
                    }
                }

                RefreshFarmersList();
            }
        }

        private void readFarmer_Click(object sender, EventArgs e)
        {
            if (farmerList.SelectedItems.Count != 1)
            {
                MessageBox.Show("Выберите одного фермера для настройки.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Farmer farmer = logic.AllFarmers[farmerList.SelectedIndex];

            ReadDialog readDialog = new ReadDialog(farmer);
            readDialog.ShowDialog(this);
        }

        private void harvestSort_Click(object sender, EventArgs e)
        {
            logic.HarvestSort();

            RefreshFarmersList();
        }

        private void exchangeProduct_Click(object sender, EventArgs e)
        {
            if (farmerList.SelectedItems.Count != 2)
            {
                MessageBox.Show("Выберите двух фермеров для осуществления купли-продажи.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Farmer payer = logic.AllFarmers[farmerList.Items.IndexOf(farmerList.Items[0])];
            Farmer seller = logic.AllFarmers[farmerList.Items.IndexOf(farmerList.Items[1])];

            ExchangeDialog exchangeDialog = new ExchangeDialog(payer, seller);
            exchangeDialog.ShowDialog(this);


        }
    }
}
