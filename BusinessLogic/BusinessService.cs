using Model;

namespace BusinessLogic
{
    public class BusinessService
    {
        public static float fieldUnitCost = 15525;

        /// <summary>
        /// Метод, осуществляющий продажу земли между фермерами
        /// </summary>
        /// <param name="payerFarmerIndex">Индекс фермера-покупателя в списке</param>
        /// <param name="sellerFarmerIndex">Индекс фермера-продавца в списке</param>
        /// <param name="fieldArea">Площадь покупаемой земли</param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод, осуществляющий сортировку списка фермеров по финансовому капиталу
        /// </summary>
        public List<int> GetFarmTypeGroup(List<Farmer> farmers, string farmType)
        {
            return farmers.Where(f => f.farmType == farmType).Select(f => farmers.IndexOf(f)).ToList();
        }
    }
}
