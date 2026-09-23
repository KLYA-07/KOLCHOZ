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
                }, new Dictionary<string, int>()
                {
                    { "Кукуруза", 100 },
                    { "Свекла", 75 },
                    { "Картофель", 20 },
                    { "Курица", 250 }
                }, new Dictionary<string, int>()
                {
                    { "Свинья", 2 },
                    { "Курица", 5 }
                }, new Dictionary<string, int>()
                {
                    { "Кукуруза", 10 },
                    { "Свекла", 15 },
                    { "Подсолнух", 25 }
                }));

            RefreshFarmersList();
            SetupDialog aD = new SetupDialog(logic.AllFarmers[0]);
            aD.ShowDialog(this);
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
            if(farmerList.SelectedItems.Count > 0)
            {

            }
        }
    }
}
