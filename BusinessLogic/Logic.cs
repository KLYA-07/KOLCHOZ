using DataAccessLayer;
using Model;

namespace BusinessLogic
{
    public class Logic : IModel<Farmer>
    {
        public event EventHandler DataChanged;
        private IRepository<Farmer> repository;
        private IBusinessService service;

        public Logic(IRepository<Farmer> repository, IBusinessService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public void AddFarmer(Farmer farmer)
        {
            repository.Create(farmer);
        }

        public void RemoveFarmer(int farmerID)
        {
            Farmer farmer = repository.ReadAll().Where(f => f.ID == farmerID).FirstOrDefault();

            if(farmer != null)
            {
                repository.Delete(farmer);
            }
        }

        public Farmer ReadFarmer(int farmerID)
        {
            return repository.ReadByID(farmerID);
        }

        public void ChangeFarmer(Farmer farmer)
        {
            repository.Update(farmer);
        }

        public List<Farmer> AllFarmers()
        {
            return repository.ReadAll().ToList();
        }

        public int ExchangeField(int payerFarmerID, int sellerFarmerID, float fieldArea)
        {
            Farmer payer = repository.ReadByID(payerFarmerID);
            Farmer seller = repository.ReadByID(sellerFarmerID);

            int result = service.DoFieldExchange(payer, seller, fieldArea);

            if(result == 1)
            {
                repository.Update(payer);
                repository.Update(seller);
            }

            return result;
        }

        public List<Farmer> FarmTypeGroup(string farmType)
        {
            List<Farmer> farmers = repository.ReadAll().ToList();

            return service.GetFarmTypeGroup(farmers, farmType);
        }
    }
}
