using Model;

namespace BusinessLogic
{
    public class UI_Adapter
    {
        public List<string> GetFarmersStrings(List<Farmer> farmers)
        {
            return farmers.Select(f => $"{f.farmerName} {f.farmerSurname} ({f.finacialCapital}₽)").ToList();
        }

        public List<int> GetFarmersIDs(List<Farmer> farmers)
        {
            return farmers.Select(f => f.ID).ToList();
        }
    }
}
