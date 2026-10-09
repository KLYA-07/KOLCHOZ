using Model;
using BusinessLogic;

namespace WinFormsPresentation
{
    public partial class FarmForm : Form
    {
        private Logic logic;

        /// <summary>
        /// Конструктор, который инициализирует основную форму: обновляет список фермеров
        /// </summary>
        /// <param name="logic"></param>
        public FarmForm(Logic logic)
        {
            InitializeComponent();

            this.logic = logic;

            RefreshFarmersList();
        }

        /// <summary>
        /// Метод, который обновляет ListBox фермеров
        /// </summary>
        public void RefreshFarmersList()
        {
            farmerList.Items.Clear();

            foreach (string farmer in logic.AllFarmers)
            {
                farmerList.Items.Add(farmer);
            }
        }

        /// <summary>
        /// Метод события нажатия кнопки добавления фермера, который осуществляет бизнес-логику добавления фермера, открывает диалог настройки фермера и обновляет ListBox фермеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            Farmer farmer = new Farmer();
            logic.AddFarmer(farmer);

            SetupFarmer(logic.AllFarmers.Count - 1);

            RefreshFarmersList();
        }

        /// <summary>
        /// Метод события нажатия кнопки изменения фермера, который открывает диалог настройки фермера и осуществляет бизнес-функцию изменения фермера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeFarmer_Click(object sender, EventArgs e)
        {
            if (farmerList.SelectedItems.Count != 1)
            {
                MessageBox.Show("Выберите одного фермера для настройки.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetupFarmer(farmerList.SelectedIndex);
        }

        /// <summary>
        /// Метод, который инициализирует и открывает форму настройки фермера и после её закрытия изменяет фермера в логике
        /// </summary>
        /// <param name="index">Индекс выбранного фермера (сущности)</param>
        private void SetupFarmer(int index)
        {
            Farmer neededfarmer = logic.ReadFarmer(index);
            Farmer sendFarmer = new Farmer()
            {
                farmerName = neededfarmer.farmerName,
                farmerSurname = neededfarmer.farmerSurname,
                registrationDate = neededfarmer.registrationDate,
                finacialCapital = neededfarmer.finacialCapital,
                farmAddress = neededfarmer.farmAddress,
                farmType = neededfarmer.farmType,
                fieldArea = neededfarmer.fieldArea,
                phoneNumber = neededfarmer.phoneNumber
            };

            SetupDialog setupDialog = new SetupDialog(sendFarmer);
            setupDialog.ShowDialog(this);

            RefreshFarmersList();

            logic.ChangeFarmer(index, sendFarmer);

            RefreshFarmersList();
        }

        /// <summary>
        /// Метод события нажатия кнопки удаления фермера, который осуществляет бизнес-функцию удаления фермера и обновляет ListBox фермеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (farmerList.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранных фермеров?", "Ошибка ввода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        /// <summary>
        /// Метод события нажатия кнопки чтения фермера, который осуществляет бизнес-функцию чтения фермера и открывает диалог чтения фермера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readFarmer_Click(object sender, EventArgs e)
        {
            if (farmerList.SelectedItems.Count != 1)
            {
                MessageBox.Show("Выберите одного фермера для настройки.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Farmer farmer = logic.ReadFarmer(farmerList.SelectedIndex);

            ReadDialog readDialog = new ReadDialog(farmer);
            readDialog.ShowDialog(this);
        }

        /// <summary>
        /// Метод события нажания кнопки сортировки фермеров, который осцуществляет бизнес-функцию сортировки фермеров по объему урожая и обновляет ListBox фермеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void harvestSort_Click(object sender, EventArgs e)
        {
            logic.HarvestSort();

            RefreshFarmersList();
        }

        /// <summary>
        /// Метод события нажатия кнопки продажи урожая фермеров, который открывает диалог купли-продажи урожая фермеров и после подтверждения продажи осуществляет бизнес-функцию продажи в логике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exchangeProduct_Click(object sender, EventArgs e)
        {
            if (farmerList.SelectedItems.Count != 2)
            {
                MessageBox.Show("Выберите двух фермеров для осуществления купли-продажи.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int payerIndex = farmerList.SelectedIndices[0];
            int sellerIndex = farmerList.SelectedIndices[1];

            Farmer payer = logic.ReadFarmer(payerIndex);
            Farmer seller = logic.ReadFarmer(sellerIndex);

            ExchangeDialog exchangeDialog = new ExchangeDialog(payer, seller);
            exchangeDialog.ShowDialog(this);

            do
            {
                if (exchangeDialog.DialogResult == DialogResult.OK)
                {
                    if (exchangeDialog.isOppositeOrder)
                    {
                        if(logic.GroupByFarmType(sellerIndex, payerIndex, exchangeDialog.exchangeArea) )
                        {
                            exchangeDialog.exchangeResult = true;
                        }
                    }
                    else
                    {
                        if(!logic.GroupByFarmType(payerIndex, sellerIndex, exchangeDialog.exchangeArea))
                        {
                            exchangeDialog.exchangeResult = true;
                        }
                    }

                    exchangeDialog.ShowDialog(this);
                }
            }
            while (exchangeDialog.DialogResult == DialogResult.OK);
        }
    }
}
