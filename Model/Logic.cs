namespace Model
{
    public class Logic
    {
        private List<Farmer> allFarmers = new List<Farmer>();

        public List<Farmer> AllFarmers
        {
            get
            {
                return allFarmers;
            }
        }

        public void AddFarmer(Farmer farmer)
        {
            allFarmers.Add(farmer);
        }

        public void RemoveFarmer(int farmerIndex)
        {
            if(farmerIndex >= 0 && farmerIndex < allFarmers.Count)
            {
                allFarmers.RemoveAt(farmerIndex);
            }
        }

        public Farmer ReadFarmer(int farmerIndex)
        {
            return allFarmers[farmerIndex];
        }

        public void ChangeFarmer(int farmerIndex, Farmer farmer)
        {
            allFarmers.RemoveAt(farmerIndex);
            allFarmers.Insert(farmerIndex, farmer);
        }

        public bool ExchangeProducts(int payerFarmerIndex, int sellerFarmerIndex, string itemName, int itemsCount)
        {
            Farmer payer = allFarmers[payerFarmerIndex];
            Farmer seller = allFarmers[sellerFarmerIndex];

            int sum = seller.harvestCosts[itemName] * itemsCount;
            if (payer.finacialCapital >= sum)
            {
                payer.finacialCapital -= sum;
                seller.finacialCapital += sum;

                payer.lastHarvest[itemName] += itemsCount;
                seller.lastHarvest[itemName] -= itemsCount;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void HarvestSort()
        {
            allFarmers = allFarmers.OrderBy(h =>
            {
                int sum = 0;
                foreach (var item in h.lastHarvest)
                {
                    sum += item.Value;
                }

                return sum;
            }).ToList();
        }
    }
}
