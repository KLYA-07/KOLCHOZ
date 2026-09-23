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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsPresentation
{
    public partial class SetupDialog : Form
    {
        private Farmer farmer;
        public SetupDialog(Farmer farmer)
        {
            this.farmer = farmer;

            InitializeComponent();


        }

        private void farmerName_TextChanged(object sender, EventArgs e)
        {
            farmer.farmerName = farmerName.Text;
        }

        private void financialCapital_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(financialCapital.Text))
            {
                return;
            }

            if (!int.TryParse(financialCapital.Text, out int value) || value <= 0)
            {
                e.Cancel = true;

                MessageBox.Show("В этом поле разрешены только неотрицательные числа!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                farmer.finacialCapital = value;
            }
        }

        private void fieldSize_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(fieldSize.Text))
            {
                return;
            }

            if (!int.TryParse(fieldSize.Text, out int value) || value <= 0)
            {
                e.Cancel = true;

                MessageBox.Show("В этом поле разрешены только неотрицательные числа!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                farmer.fieldSize = value;
            }
        }
    }
}
