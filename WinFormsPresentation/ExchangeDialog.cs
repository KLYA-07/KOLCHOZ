using System.ComponentModel;
using Model;

namespace WinFormsPresentation
{
    public partial class ExchangeDialog : Form
    {
        private Farmer payer;
        private Farmer seller;

        public float exchangeArea;
        public bool isOppositeOrder;
        public int exchangeResult = 1;

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

            fieldCost.Text = fieldCost.Text.Split(":").First() + ": " + Program.FieldUnitCost.ToString();
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
            payerName.Text = payerName.Text.Split(':').First() + ": " + payer.farmerName;
            sellerName.Text = sellerName.Text.Split(':').First() + ": " + seller.farmerName;

            financialCapital.Text = financialCapital.Text.Split(':').First() + ": " + payer.finacialCapital.ToString();

            totalFieldArea.Text = totalFieldArea.Text.Split(":").First() + ":\n" + seller.fieldArea.ToString();

            UpdateSum();
        }


        /// <summary>
        /// Метод, который обновляет итоговую сумму покупки
        /// </summary>
        private void UpdateSum()
        {
            exchangeSum.Text = exchangeSum.Text.Split(':').First() + ": " + (Program.FieldUnitCost * exchangeArea).ToString();
        }

        /// <summary>
        /// Метод события нажатия кнопки продажи, который переводит выполнение кода на основную форму, где выполняется логика продажи и возвращение в эту форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exchangeButton_Click(object sender, EventArgs e)
        {
            if (exchangeArea > 0)
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
            if (exchangeResult <= 0)
            {
                if(exchangeResult == 0)
                {
                    MessageBox.Show("Недостаточно средств.", "Ошибка оплаты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Выбранная площадь превосходит площадь продажи.", "Ошибка оплаты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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

        private void fieldArea_Validating(object sender, CancelEventArgs e)
        {
            string text = fieldArea.Text.TrimStart().TrimEnd();

            if(text != string.Empty)
            {
                if(!float.TryParse(text, out float value) || value <= 0)
                {
                    MessageBox.Show("Значение должно быть числом больше нуля.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    exchangeArea = value;
                    UpdateSum();
                }
            }
            else
            {
                MessageBox.Show("Поле пустое.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
