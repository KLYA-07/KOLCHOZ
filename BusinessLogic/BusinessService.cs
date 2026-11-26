using Model;

namespace BusinessLogic
{
    public class BusinessService : IBusinessService
    {
        public static float fieldUnitCost = 15525;

        public int DoFieldExchange(Farmer payer, Farmer seller, float fieldArea)
        {
            decimal sum = (decimal)(fieldUnitCost * fieldArea);

            if (payer.finacialCapital >= sum && seller.fieldArea >= fieldArea)
            {
                payer.finacialCapital -= sum;
                seller.finacialCapital += sum;

                payer.fieldArea += fieldArea;
                seller.fieldArea -= fieldArea;

                return 1;
            }
            else
            {
                if (seller.fieldArea < fieldArea)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<Farmer> GetFarmTypeGroup(List<Farmer> farmers, string farmType)
        {
            return farmers.Where(f => f.farmType == farmType).ToList();
        }
    }
}
