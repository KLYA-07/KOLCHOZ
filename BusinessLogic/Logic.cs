using DataAccessLayer;
using Model;

namespace BusinessLogic
{
    public class Logic
    {
        private IRepository<Farmer> allFarmers;
        private BusinessService service;
        private UI_Adapter adapter;

        public Logic(IRepository<Farmer> repository)
        {
            allFarmers = repository;
            service = new BusinessService();
            adapter = new UI_Adapter();
        }

        public List<string> AllFarmers
        {
            get
            {
                return adapter.GetFarmersStrings(allFarmers.ReadAll().ToList());
            }
        }

        public List<int> AllFarmersIDs
        {
            get
            {
                return adapter.GetFarmersIDs(allFarmers.ReadAll().ToList());
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
            Farmer farmer = allFarmers.ReadAll().ToList()[farmerIndex];
            allFarmers.Delete(farmer);
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

            int result = service.DoFieldExchange(payer, seller, fieldArea);

            if(result == 1)
            {
                allFarmers.Update(payer);
                allFarmers.Update(seller);
            }

            return result;
        }

        /// <summary>
        /// Метод, осуществляющий сортировку списка фермеров по финансовому капиталу
        /// </summary>
        public List<int> FarmTypeGroup(string farmType)
        {
            List<Farmer> farmers = allFarmers.ReadAll().ToList();

            return service.GetFarmTypeGroup(farmers, farmType);
        }
    }
}
