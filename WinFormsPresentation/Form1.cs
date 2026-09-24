using Model;

namespace WinFormsPresentation
{
    public partial class ReadDialog : Form
    {
        public ReadDialog(Farmer farmer)
        {
            InitializeComponent();

            farmerName.Text += farmer.farmerName;
            financialCapital.Text += farmer.finacialCapital;
            fieldSize.Text += farmer.fieldSize;

            for(int p = 0; p < farmer.lastHarvest.Count; p++)
            {
                harvestList.Items.Add($"{farmer.lastHarvest.Keys.ToList()[p]} - Кол-во: {farmer.lastHarvest.Values.ToList()[p]} - Цена за шт: {farmer.harvestCosts[p]}");
            }

            for (int c = 0; c < farmer.cattleHeadboard.Count; c++)
            {
                cattleList.Items.Add(farmer.cattleHeadboard[c]);
            }

            for (int c = 0; c < farmer.cultivatingCrops.Count; c++)
            {
                cultureList.Items.Add(farmer.cultivatingCrops[c]);
            }
        }
    }
}
