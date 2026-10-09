using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using Model;

namespace WinFormsPresentation
{
    public partial class SetupDialog : Form
    {
        private Farmer editingfarmer;
        private Farmer sentFarmer;

        /// <summary>
        /// Конструктор, который инициализирует форму настройки фермера: устанавливает изначальные значения всех полей формы
        /// </summary>
        /// <param name="farmer">Фермер, на основе которого инициализируется форма</param>
        public SetupDialog(Farmer farmer)
        {
            sentFarmer = farmer;

            editingfarmer = new Farmer()
            {
                farmerName = farmer.farmerName,
                farmerSurname = farmer.farmerSurname,
                phoneNumber = farmer.phoneNumber,
                finacialCapital = farmer.finacialCapital,
                fieldArea = farmer.fieldArea,
                farmAddress = farmer.farmAddress,
                farmType = farmer.farmType,
                registrationDate = farmer.registrationDate,
            };

            InitializeComponent();

            farmerName.Text = farmer.farmerName;
            farmerSurname.Text = farmer.farmerSurname;
            phoneNumber.Text = farmer.phoneNumber;
            financialCapital.Text = farmer.finacialCapital.ToString();
            fieldSize.Text = farmer.fieldArea.ToString();
            farmAddress.Text = farmer.farmAddress;
            farmType.SelectedIndex = farmType.FindStringExact(farmer.farmType);
            registrationDate.Value = farmer.registrationDate;
        }

        private bool ValidateText(string text)
        {
            if (string.IsNullOrEmpty(text.TrimStart().TrimEnd()))
            {
                MessageBox.Show("Поле пустое.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private int ValidateValue(string text)
        {
            if (ValidateText(text))
            {
                if (!int.TryParse(text, out int value) || value < 0)
                {
                    MessageBox.Show("В этом поле разрешены только неотрицательные числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля имени фермера, который проверяет введённое значение и при успехе обновляет имя фермера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void farmerName_Validating(object sender, CancelEventArgs e)
        {
            string newValue = farmerName.Text.TrimStart().TrimEnd();
            if (!ValidateText(newValue))
            {
                e.Cancel = true;
            }
            editingfarmer.farmerName = newValue;
        }

        private void farmerSurname_Validating(object sender, CancelEventArgs e)
        {
            string newValue = farmerSurname.Text.TrimStart().TrimEnd();

            if (!ValidateText(newValue))
            {
                e.Cancel = true;
            }
            editingfarmer.farmerName = newValue;
        }

        private void phoneNumber_Validating(object sender, CancelEventArgs e)
        {
            string newValue = phoneNumber.Text.TrimStart().TrimEnd();

            if (!ValidateText(newValue))
            {
                e.Cancel = true;
            }
            else
            {
                if (newValue.ToList()[0] == '+')
                {
                    if (long.TryParse(newValue.Split('+').Last(), out long value) && value >= 0)
                    {
                        editingfarmer.phoneNumber = newValue;
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат номера телефона.", "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (long.TryParse(newValue, out long value) && value >= 0)
                    {
                        editingfarmer.phoneNumber = newValue;
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат номера телефона.", "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля финансового капитала фермера, который проверяет введённое значение и при успехе обновляет капитал фермера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void financialCapital_Validating(object sender, CancelEventArgs e)
        {
            int value = ValidateValue(financialCapital.Text);

            if (value < 0)
            {
                e.Cancel = true;
            }
            else
            {
                editingfarmer.finacialCapital = value;
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля размера поля фермера, который проверяет введённое значение и при успехе обновляет размер поля фермера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fieldSize_Validating(object sender, CancelEventArgs e)
        {
            int value = ValidateValue(fieldSize.Text);

            if (value < 0)
            {
                e.Cancel = true;
            }
            else
            {
                editingfarmer.fieldArea = value;
            }
        }

        /// <summary>
        /// Метод события нажатия на кнопку сохранения фермера, который в экземпляре переданного фермера обновляет все свойства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFarmer_Click(object sender, EventArgs e)
        {
            sentFarmer.farmerName = editingfarmer.farmerName;
            sentFarmer.farmerSurname = editingfarmer.farmerSurname;
            sentFarmer.phoneNumber = editingfarmer.phoneNumber;
            sentFarmer.finacialCapital = editingfarmer.finacialCapital;
            sentFarmer.fieldArea = editingfarmer.fieldArea;
            sentFarmer.farmAddress = editingfarmer.farmAddress;
            sentFarmer.farmType = editingfarmer.farmType;
            sentFarmer.registrationDate = editingfarmer.registrationDate;
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

        private void SetupDialog_Load(object sender, EventArgs e)
        {

        }

        private void farmerAddress_Validating(object sender, CancelEventArgs e)
        {
            string newValue = farmAddress.Text.TrimStart().TrimEnd();

            if (!ValidateText(newValue))
            {
                e.Cancel = true;
            }
            else
            {
                editingfarmer.farmAddress = newValue;
            }
        }

        private void farmType_Validating(object sender, CancelEventArgs e)
        {
            editingfarmer.farmType = farmType.Text;
        }

        private void registrationDate_Validating(object sender, CancelEventArgs e)
        {
            editingfarmer.registrationDate = registrationDate.Value;
        }
    }
}
