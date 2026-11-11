using DataAccessLayer;
using Model;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        private IRepository<Farmer> allFarmers;
        private IBusinessService service;
        private IFarmerFormatter formatter;

        public Logic(IRepository<Farmer> repository, IFarmerFormatter formatter, IBusinessService service)
        {
            allFarmers = repository;
            this.service = service;
            this.formatter = formatter;
        }

        public List<string> AllFarmers
        {
            get
            {
                return formatter.GetFarmersStrings(allFarmers.ReadAll().ToList());
            }
        }

        public List<int> AllFarmersIDs
        {
            get
            {
                return formatter.GetFarmersIDs(allFarmers.ReadAll().ToList());
            }
        }

        public void AddFarmer(Farmer farmer)
        {
            allFarmers.Create(farmer);
        }

        public void RemoveFarmer(int farmerIndex)
        {
            Farmer farmer = allFarmers.ReadAll().ToList()[farmerIndex];
            allFarmers.Delete(farmer);
        }

        public Farmer ReadFarmer(int farmerIndex)
        {
            return allFarmers.ReadByID(AllFarmersIDs[farmerIndex]);
        }

        public void ChangeFarmer(Farmer farmer)
        {
            allFarmers.Update(farmer);
        }

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

        public List<int> FarmTypeGroup(string farmType)
        {
            List<Farmer> farmers = allFarmers.ReadAll().ToList();

            return service.GetFarmTypeGroup(farmers, farmType);
        }
    }
}
