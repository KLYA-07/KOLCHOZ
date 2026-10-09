using DataAccessLayer;
using Model;
//using DataAccessLayer;

namespace BusinessLogic
{
    public class Logic
    {
        public const float fieldUnitCost = 15525;
        private IRepository<Farmer> allFarmers;

        public Logic(IRepository<Farmer> repository)
        {
            allFarmers = repository;
        }

        public List<string> AllFarmers
        {
            get
            {
                return allFarmers.ReadAll().ToList().Select(f => $"{f.farmerName} {f.farmerSurname} ({f.finacialCapital}₽)").ToList();
            }
        }

        public List<int> AllFarmersIDs
        {
            get
            {
                return allFarmers.ReadAll().ToList().Select(f => f.ID).ToList();
            }
        }

        /// <summary>
        /// Метод, добавляющий фермера в список фермеров
        /// </summary>
        /// <param name="farmer"></param>
        public void AddFarmer(Farmer farmer)
        {
            allFarmers.Create(farmer);
        }

        /// <summary>
        /// Метод, удаляющий фермера из списка по заданному индексу
        /// </summary>
        /// <param name="farmerIndex">Индекс фермера в списке</param>
        public void RemoveFarmer(int farmerIndex)
        {
            allFarmers.Delete(allFarmers.ReadByID(AllFarmersIDs[farmerIndex]));
        }

        /// <summary>
        /// Метод, предоставляющий доступ для чтения фермера
        /// </summary>
        /// <param name="farmerIndex">Индекс выбранного фермера в списке</param>
        /// <returns></returns>
        public Farmer ReadFarmer(int farmerIndex)
        {
            return allFarmers.ReadByID(AllFarmersIDs[farmerIndex]);
        }

        /// <summary>
        /// Метод, меняющий фермера в списке путем замены
        /// </summary>
        /// <param name="farmer">Экземпляр фермера, на которого нужно заменить</param>
        public void ChangeFarmer(Farmer farmer)
        {
            allFarmers.Update(farmer);
        }

        /// <summary>
        /// Метод, осуществляющий продажу земли между фермерами
        /// </summary>
        /// <param name="payerFarmerIndex">Индекс фермера-покупателя в списке</param>
        /// <param name="sellerFarmerIndex">Индекс фермера-продавца в списке</param>
        /// <param name="fieldArea">Площадь покупаемой земли</param>
        /// <returns></returns>
        public int ExchangeField(int payerFarmerIndex, int sellerFarmerIndex, float fieldArea)
        {
            Farmer payer = allFarmers.ReadByID(AllFarmersIDs[payerFarmerIndex]);
            Farmer seller = allFarmers.ReadByID(AllFarmersIDs[sellerFarmerIndex]);

            decimal sum = (decimal)(fieldUnitCost * fieldArea);

            if (payer.finacialCapital >= sum && seller.fieldArea >= fieldArea)
            {
                payer.finacialCapital -= sum;
                seller.finacialCapital += sum;

                payer.fieldArea += fieldArea;
                seller.fieldArea -= fieldArea;

                allFarmers.Update(payer);
                allFarmers.Update(seller);

                return 1;
            }
            else
            {
                if(seller.fieldArea < fieldArea)
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
        public List<int> FarmTypeGroup(string farmType)
        {
            return allFarmers.ReadAll().Where(f => f.farmType == farmType).Select(f => allFarmers.ReadAll().ToList().IndexOf(f)).ToList();
        }
    }
}
