using Model;
//using DataAccessLayer;

namespace BusinessLogic
{
    public class Logic
    {
        private const float fieldUnitCost = 15525;
        private List<Farmer> allFarmers;

        public Logic()
        {
            allFarmers = new List<Farmer>();
        }

        public List<string> AllFarmers
        {
            get
            {
                return allFarmers.Select(f => $"{f.farmerName} {f.farmerSurname} ({f.finacialCapital}₽)").ToList();
            }
        }

        /// <summary>
        /// Метод, добавляющий фермера в список фермеров
        /// </summary>
        /// <param name="farmer"></param>
        public void AddFarmer(Farmer farmer)
        {
            allFarmers.Add(farmer);
        }

        /// <summary>
        /// Метод, удаляющий фермера из списка по заданному индексу
        /// </summary>
        /// <param name="farmerIndex">Индекс фермера в списке</param>
        public void RemoveFarmer(int farmerIndex)
        {
            allFarmers.RemoveAt(farmerIndex);
        }

        /// <summary>
        /// Метод, предоставляющий доступ для чтения фермера
        /// </summary>
        /// <param name="farmerIndex">Индекс выбранного фермера в списке</param>
        /// <returns></returns>
        public Farmer ReadFarmer(int farmerIndex)
        {
            return allFarmers[farmerIndex];
        }

        /// <summary>
        /// Метод, меняющий фермера в списке путем замены
        /// </summary>
        /// <param name="farmerIndex">Индекс выбранного фермера в списке</param>
        /// <param name="farmer">Экземпляр фермера, на которого нужно заменить</param>
        public void ChangeFarmer(int farmerIndex, Farmer farmer)
        {
            allFarmers.RemoveAt(farmerIndex);
            allFarmers.Insert(farmerIndex, farmer);
        }

        /// <summary>
        /// Метод, осуществляющий продажу земли между фермерами
        /// </summary>
        /// <param name="payerFarmerIndex">Индекс фермера-покупателя в списке</param>
        /// <param name="sellerFarmerIndex">Индекс фермера-продавца в списке</param>
        /// <param name="fieldArea">Площадб покупаемой земли</param>
        /// <returns></returns>
        public bool GroupByFarmType(int payerFarmerIndex, int sellerFarmerIndex, int fieldArea)
        {
            Farmer payer = allFarmers[payerFarmerIndex];
            Farmer seller = allFarmers[sellerFarmerIndex];

            decimal sum = (decimal)(fieldUnitCost * fieldArea);

            if (payer.finacialCapital >= sum && seller.fieldArea >= fieldArea)
            {
                payer.finacialCapital -= sum;
                seller.finacialCapital += sum;

                payer.fieldArea += fieldArea;
                seller.fieldArea -= fieldArea;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Метод, осуществляющий сортировку списка фермеров по финансовому капиталу
        /// </summary>
        public void HarvestSort()
        {
            allFarmers = allFarmers.OrderByDescending(f => f.finacialCapital).ToList();
        }
    }
}
