using Model;

namespace WinFormsPresentation
{
    public partial class ReadDialog : Form
    {
        /// <summary>
        /// Конструктор, который инициализирует форму чтения фермера: представляет информацию о фермере в удобный пользователю вид
        /// </summary>
        /// <param name="farmer"></param>
        public ReadDialog(Farmer farmer)
        {
            InitializeComponent();

            farmerName.Text += farmer.farmerName;
            farmerSurname.Text += farmer.farmerSurname;
            phoneNumber.Text += phoneNumber.Text;
            financialCapital.Text += farmer.finacialCapital;
            fieldArea.Text += farmer.fieldArea;
            farmType.Text += farmer.farmType;
            farmAddress.Text += farmer.farmAddress;
            registrationDate.Text += farmer.registrationDate.ToString();
            
        }
    }
}
