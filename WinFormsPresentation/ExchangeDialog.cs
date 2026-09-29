using System.ComponentModel;
using Model;

namespace WinFormsPresentation
{
    public partial class ExchangeDialog : Form
    {
        private Farmer payer;
        private Farmer seller;

        public int exchangeCount;
        public int selectedProduct;

        public bool isOppositeOrder;

        /// <summary>
        /// Конструктор, который инициализирует форму осуществления купли-продажи между двумя фермерами: устанавливает изначальные значения всех полей формы
        /// </summary>
        /// <param name="payer">Фермер-покупатель</param>
        /// <param name="seller">Фермер-продавец</param>
        public ExchangeDialog(Farmer payer, Farmer seller)
        {
            InitializeComponent();

            this.payer = payer;
            this.seller = seller;

            FlipExchangeField();

            productCount.Text = "0";
        }

        /// <summary>
        /// Метод события нажатия кнопки переворота продажи, который меняет местами фермеров и обновляет форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switchButton_Click(object sender, EventArgs e)
        {
            Farmer temp = payer;

            payer = seller;
            seller = temp;

            FlipExchangeField();

            isOppositeOrder = true;
        }

        /// <summary>
        /// Метод, который обновляет форму и корректирует значение количества выбранного продукта
        /// </summary>
        private void FlipExchangeField()
        {
            allProducts.Items.Clear();

            payerName.Text = payerName.Text.Split(':').First() + ": " + payer.farmerName;
            sellerName.Text = sellerName.Text.Split(':').First() + ": " + seller.farmerName;

            financialCapital.Text = financialCapital.Text.Split(':').First() + ": " + payer.finacialCapital.ToString();

            for (int i = 0; i < seller.lastHarvest.Count; i++)
            {
                allProducts.Items.Add(seller.lastHarvest.Keys.ToList()[i]);
            }

            if (allProducts.Items.Count > 0)
            {
                allProducts.SelectedIndex = 0;
            }
            if (seller.harvestCosts.Count > 0)
            {
                productCost.Text = productCost.Text.Split(':').First() + ": " + seller.harvestCosts[0].ToString();
            }
            else
            {
                productCost.Text = productCost.Text.Split(':').First() + ": -";
            }

            if (seller.lastHarvest.Count > 0)
            {
                productTotalCount.Text = productTotalCount.Text.Split(':').First() + ": " + seller.lastHarvest[seller.lastHarvest.Keys.ToList()[0]].ToString();
                productCount.Enabled = true;
            }
            else
            {
                productTotalCount.Text = productTotalCount.Text.Split(':').First() + ": -";
                exchangeSum.Text = exchangeSum.Text.Split(':').First() + ": -";
                productCount.Enabled = false;
            }
        }

        /// <summary>
        /// Метод события выбора элемента списка ComboBox продуктов, который обновляет итоговую сумму, поля цены и количества выбранных продуктов, а также корректирует количество продуктов для покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(allProducts.SelectedIndex >= 0)
            {
                if (exchangeCount > seller.lastHarvest[seller.lastHarvest.Keys.ToList()[allProducts.SelectedIndex]])
                {
                    exchangeCount = seller.lastHarvest[seller.lastHarvest.Keys.ToList()[allProducts.SelectedIndex]];

                    productCount.Text = exchangeCount.ToString();
                }

                selectedProduct = allProducts.SelectedIndex;

                productTotalCount.Text = productTotalCount.Text.Split(':').First() + ": " + seller.lastHarvest[seller.lastHarvest.Keys.ToList()[allProducts.SelectedIndex]].ToString();

                productCost.Text = productCost.Text.Split(':').First() + ": " + seller.harvestCosts[allProducts.SelectedIndex];

                UpdateSum();
            }
        }


        /// <summary>
        /// Метод, который обновляет итоговую сумму покупки
        /// </summary>
        private void UpdateSum()
        {
            exchangeSum.Text = exchangeSum.Text.Split(':').First() + ": " + (seller.harvestCosts[allProducts.SelectedIndex] * exchangeCount).ToString();
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля количества выбранных продуктов, который проверяет введённое значение и при успехе обновляет количество
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productCount_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(productCount.Text.Split(':').Last(), out int value) && value >= 0)
            {
                if (value <= seller.lastHarvest[seller.lastHarvest.Keys.ToList()[allProducts.SelectedIndex]])
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

        /// <summary>
        /// Метод события нажатия кнопки продажи, который переводит выполнение кода на основную форму, где выполняется логика продажи и возвращение в эту форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exchangeButton_Click(object sender, EventArgs e)
        {
            if(seller.lastHarvest.Count > 0 && exchangeCount > 0 && allProducts.SelectedIndex >= 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Метод события загрузки формы, который обновляет форму при повторной загрузке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExchangeDialog_Load(object sender, EventArgs e)
        {
            FlipExchangeField();
        }

        /// <summary>
        /// Метод события нажатия на клавишу всех полей формы, который принудительно подтвержает ввод при нажатии на Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeaveEditingOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    ActiveControl = null;
                    e.SuppressKeyPress = true;
                }
            }
        }

        /// <summary>
        /// Метод события нажатия кнопки мыши по форме, который принудительно подтверждает ввод при нажатии вне данного поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeaveEditingOnMouseClick(object sender, MouseEventArgs e)
        {
            if (Validate())
            {
                ActiveControl = null;
            }
        }
    }
}
