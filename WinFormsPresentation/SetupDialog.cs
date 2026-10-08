using System.ComponentModel;
using System.Data;
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

            editingfarmer = new Farmer(sentFarmer.farmerName, sentFarmer.finacialCapital, sentFarmer.fieldArea, new Dictionary<string, int>(sentFarmer.lastHarvest), new List<int>(sentFarmer.harvestCosts), new List<string>(sentFarmer.cattleHeadboard), new List<string>(sentFarmer.cultivatingCrops));

            InitializeComponent();

            farmerName.Text = farmer.farmerName;
            financialCapital.Text = farmer.finacialCapital.ToString();
            fieldSize.Text = farmer.fieldArea.ToString();

            foreach(string item in new List<string>(farmer.lastHarvest.Keys.ToList()))
            {
                harvestList.Items.Add(item);
            }

            foreach (string item in new List<string>(farmer.cattleHeadboard))
            {
                cattleList.Items.Add(item);
            }

            foreach (string item in new List<string>(farmer.cultivatingCrops))
            {
                cultureList.Items.Add(item);
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля имени фермера, который проверяет введённое значение и при успехе обновляет имя фермера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void farmerName_Validating(object sender, CancelEventArgs e)
        {
            string newName = farmerName.Text.TrimStart().TrimEnd();

            if (newName == string.Empty)
            {
                e.Cancel = true;

                MessageBox.Show("Пустая строка. Введите конкретное имя.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            editingfarmer.farmerName = newName;

            if (farmerName.Text != newName)
            {
                farmerName.Validating -= cattleName_Validating;
                farmerName.Text = newName;
                farmerName.Validating += cattleName_Validating;
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля финансового капитала фермера, который проверяет введённое значение и при успехе обновляет капитал фермера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void financialCapital_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(financialCapital.Text))
            {
                return;
            }

            if (!int.TryParse(financialCapital.Text, out int value) || value < 0)
            {
                e.Cancel = true;

                MessageBox.Show("В этом поле разрешены только неотрицательные числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (string.IsNullOrEmpty(fieldSize.Text))
            {
                return;
            }

            if (!int.TryParse(fieldSize.Text, out int value) || value < 0)
            {
                e.Cancel = true;

                MessageBox.Show("В этом поле разрешены только неотрицательные числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                editingfarmer.fieldArea = value;
            }
        }

        /// <summary>
        /// Метод события нажатия кнопки добавления продукта урожая, который добавляет продукт и выделяет его для редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addProduct_Click(object sender, EventArgs e)
        {
            string pName = "Новый продукт_" + (editingfarmer.lastHarvest.Where(p => p.Key.Split('_').First() == "Новый продукт").Count() + 1).ToString();
            editingfarmer.lastHarvest.Add(pName, 0);
            editingfarmer.harvestCosts.Add(0);

            harvestList.Items.Add(pName);

            harvestList.SelectedIndex = harvestList.Items.Count - 1;
        }

        /// <summary>
        /// Метод события выбора элемента списка урожая, который устанавливает значения полей настройки продукта урожая при выборе другого элемента списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void harvestList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (harvestList.SelectedIndex >= 0)
            {
                productName.Validating -= productName_Validating;
                productName.Text = editingfarmer.lastHarvest.Keys.ToList()[harvestList.SelectedIndex].ToString();
                productName.Validating += productName_Validating;

                productCount.Validating -= productCount_Validating;
                productCount.Text = editingfarmer.lastHarvest.Values.ToList()[harvestList.SelectedIndex].ToString();
                productCount.Validating += productCount_Validating;

                productCost.Validating -= productCount_Validating;
                productCost.Text = editingfarmer.harvestCosts[harvestList.SelectedIndex].ToString();
                productCost.Validating += productCount_Validating;
            }
            else
            {
                productName.Validating -= productName_Validating;
                productName.Text = string.Empty;
                productName.Validating += productName_Validating;

                productCount.Validating -= productCount_Validating;
                productCount.Text = string.Empty;
                productCount.Validating += productCount_Validating;

                productCost.Validating -= productCount_Validating;
                productCost.Text = string.Empty;
                productCost.Validating += productCount_Validating;
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля названия продукта урожая, который проверяет введённое значение и при успехе обновляет название продукта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productName_Validating(object sender, CancelEventArgs e)
        {
            if (harvestList.SelectedItem != null)
            {
                int productCount = editingfarmer.lastHarvest[editingfarmer.lastHarvest.Keys.ToList()[harvestList.SelectedIndex]];

                List<string> keys = editingfarmer.lastHarvest.Keys.ToList();
                List<int> values = editingfarmer.lastHarvest.Values.ToList();

                string newValue = productName.Text.TrimStart().TrimEnd();

                if (newValue == string.Empty)
                {
                    MessageBox.Show("Пустая строка. Введите конкретное наименование.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Cancel = true;
                    return;
                }
                if (!keys.Contains(newValue))
                {
                    keys[harvestList.SelectedIndex] = newValue;

                    editingfarmer.lastHarvest.Clear();
                    for (int i = 0; i < keys.Count; i++)
                    {
                        editingfarmer.lastHarvest.Add(keys[i], values[i]);
                    }

                    if (productName.Text != newValue)
                    {
                        productName.Validating -= productName_Validating;
                        productName.Text = newValue;
                        productName.Validating += productName_Validating;
                    }

                    harvestList.SelectedIndexChanged -= harvestList_SelectedIndexChanged;
                    harvestList.Items[harvestList.SelectedIndex] = newValue;
                    harvestList.SelectedIndexChanged += harvestList_SelectedIndexChanged;
                }
                else
                {
                    if (harvestList.SelectedItem.ToString() == newValue)
                    {
                        return;
                    }
                    MessageBox.Show($"Список урожая уже содержит {newValue}. Введите другое наименование.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Cancel = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля количества продукта урожая, который проверяет введённое значение и при успехе обновляет количество продукта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productCount_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(productCount.Text, out int value) && value >= 0)
            {
                editingfarmer.lastHarvest[editingfarmer.lastHarvest.Keys.ToList()[harvestList.SelectedIndex]] = value;
            }
            else
            {
                MessageBox.Show("В этом поле разрешены только положительные числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля цены продукта урожая, который проверяет введённое значение и при успехе обновляет цену продукта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productCost_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(productCost.Text, out int value) && value >= 0)
            {
                editingfarmer.harvestCosts[harvestList.SelectedIndex] = value;
            }
            else
            {
                MessageBox.Show("В этом поле разрешены только неотрицательные числа.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }

        /// <summary>
        /// Метод события нажатия кнопки удаления продукта урожая, который удаляет выбранный продукт из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeProduct_Click(object sender, EventArgs e)
        {
            if(harvestList.SelectedIndex >= 0)
            {
                editingfarmer.lastHarvest.Remove(editingfarmer.lastHarvest.Keys.ToList()[harvestList.SelectedIndex]);
                editingfarmer.harvestCosts.RemoveAt(harvestList.SelectedIndex);

                harvestList.Items.RemoveAt(harvestList.SelectedIndex);
            }
        }

        /// <summary>
        /// Метод события нажатия кнопки добавления вида скота, который добавляет вид скота и выделяет его для редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCattle_Click(object sender, EventArgs e)
        {
            string cName = "Новый вид_" + (editingfarmer.cattleHeadboard.Where(p => p.Split('_').First() == "Новый вид").Count() + 1).ToString();
            editingfarmer.cattleHeadboard.Add(cName);

            cattleList.Items.Add(cName);

            cattleList.SelectedIndex = cattleList.Items.Count - 1;
        }

        /// <summary>
        /// Метод события выбора элемента списка скота, который устанавливает значения поля наименования скота при выборе другого элемента списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cattleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cattleList.SelectedIndex >= 0)
            {
                cattleName.Validating -= cattleName_Validating;
                cattleName.Text = editingfarmer.cattleHeadboard[cattleList.SelectedIndex];
                cattleName.Validating += cattleName_Validating;

            }
            else
            {
                cattleName.Validating -= cattleName_Validating;
                cattleName.Text = string.Empty;
                cattleName.Validating += cattleName_Validating;
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля названия вида скота, который проверяет введённое значение и при успехе обновляет название вида скота
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cattleName_Validating(object sender, CancelEventArgs e)
        {
            string newValue = cattleName.Text.TrimStart().TrimEnd();

            if (newValue == editingfarmer.cattleHeadboard[cattleList.SelectedIndex])
            {
                return;
            }

            if (newValue == string.Empty)
            {
                MessageBox.Show("Пустая строка. Введите конкретное наименование.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
                return;
            }

            if (editingfarmer.cattleHeadboard.Contains(newValue))
            {
                MessageBox.Show($"Список видов скота уже содержит {newValue}. Введите другое наименование.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
                return;
            }

            editingfarmer.cattleHeadboard[cattleList.SelectedIndex] = newValue;

            if (cattleName.Text != newValue)
            {
                cattleName.Validating -= cattleName_Validating;
                cattleName.Text = newValue;
                cattleName.Validating += cattleName_Validating;
            }

            cattleList.SelectedIndexChanged -= cattleList_SelectedIndexChanged;
            cattleList.Items[cattleList.SelectedIndex] = newValue;
            cattleList.SelectedIndexChanged += cattleList_SelectedIndexChanged;
        }

        /// <summary>
        /// Метод события нажатия кнопки удаления вида скота, который удаляет выбранный вид скота из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeCattle_Click(object sender, EventArgs e)
        {
            editingfarmer.cattleHeadboard.RemoveAt(cattleList.SelectedIndex);

            cattleList.Items.RemoveAt(cattleList.SelectedIndex);
        }

        /// <summary>
        /// Метод события нажатия кнопки добавления вида культуры, который добавляет вид культуры и выделяет его для редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCulture_Click(object sender, EventArgs e)
        {
            string cName = "Новый вид_" + (editingfarmer.cultivatingCrops.Where(p => p.Split('_').First() == "Новый вид").Count() + 1).ToString();
            editingfarmer.cultivatingCrops.Add(cName);

            cultureList.Items.Add(cName);

            cultureList.SelectedIndex = cultureList.Items.Count - 1;
        }

        /// <summary>
        /// Метод события выбора элемента списка культур, который устанавливает значения поля наименования культуры при выборе другого элемента списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cultureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cultureList.SelectedIndex >= 0)
            {
                cultureName.Validating -= cultureName_Validating;
                cultureName.Text = editingfarmer.cultivatingCrops[cultureList.SelectedIndex];
                cultureName.Validating += cultureName_Validating;

            }
            else
            {
                cultureName.Validating -= cultureName_Validating;
                cultureName.Text = string.Empty;
                cultureName.Validating += cultureName_Validating;
            }
        }

        /// <summary>
        /// Метод события подтверждения ввода текстового поля названия вида культуры, который проверяет введённое значение и при успехе обновляет название вида культуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cultureName_Validating(object sender, CancelEventArgs e)
        {
            string newValue = cultureName.Text.TrimStart().TrimEnd();

            if (newValue == editingfarmer.cultivatingCrops[cultureList.SelectedIndex])
            {
                return;
            }

            if (newValue == string.Empty)
            {
                MessageBox.Show("Пустая строка. Введите конкретное наименование.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
                return;
            }

            if (editingfarmer.cultivatingCrops.Contains(newValue))
            {
                MessageBox.Show($"Список видов растений уже содержит {newValue}. Введите другое наименование.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
                return;
            }

            editingfarmer.cultivatingCrops[cultureList.SelectedIndex] = newValue;

            if (cultureName.Text != newValue)
            {
                cultureName.Validating -= cultureName_Validating;
                cultureName.Text = newValue;
                cultureName.Validating += cultureName_Validating;
            }

            cultureList.SelectedIndexChanged -= cultureList_SelectedIndexChanged;
            cultureList.Items[cultureList.SelectedIndex] = newValue;
            cultureList.SelectedIndexChanged += cultureList_SelectedIndexChanged;
        }

        /// <summary>
        /// Метод события нажатия кнопки удаления вида культуры, который удаляет выбранный вид культуры из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeCulture_Click(object sender, EventArgs e)
        {
            editingfarmer.cultivatingCrops.RemoveAt(cultureList.SelectedIndex);

            cultureList.Items.RemoveAt(cultureList.SelectedIndex);
        }

        /// <summary>
        /// Метод события нажатия на кнопку сохранения фермера, который в экземпляре переданного фермера обновляет все свойства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFarmer_Click(object sender, EventArgs e)
        {
            sentFarmer.farmerName = editingfarmer.farmerName;
            sentFarmer.finacialCapital = editingfarmer.finacialCapital;
            sentFarmer.fieldArea = editingfarmer.fieldArea;
            sentFarmer.lastHarvest = editingfarmer.lastHarvest;
            sentFarmer.harvestCosts = editingfarmer.harvestCosts;
            sentFarmer.cattleHeadboard = editingfarmer.cattleHeadboard;
            sentFarmer.cultivatingCrops = editingfarmer.cultivatingCrops;
        }
        
        /// <summary>
        /// Метод события нажатия на клавишу всех полей формы, который принудительно подтвержает ввод при нажатии на Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeaveEditingOnEnter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
