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

        public bool ExchangeProducts(int payerFarmerIndex, int sellerFarmerIndex, int itemIndex, int itemsCount)
        {
            Farmer payer = allFarmers[payerFarmerIndex];
            Farmer seller = allFarmers[sellerFarmerIndex];

            int sum = seller.harvestCosts[itemIndex] * itemsCount;
            string product = seller.lastHarvest.Keys.ToList()[itemIndex];

            if (payer.finacialCapital >= sum && seller.lastHarvest[product] >= itemsCount)
            {
                payer.finacialCapital -= sum;
                seller.finacialCapital += sum;

                if (!payer.lastHarvest.ContainsKey(product))
                {
                    payer.lastHarvest.Add(product, 0);
                    payer.harvestCosts.Add(seller.harvestCosts[itemIndex]);
                }

                payer.lastHarvest[product] += itemsCount;
                seller.lastHarvest[product] -= itemsCount;

                if(seller.lastHarvest[product] == 0)
                {
                    seller.lastHarvest.Remove(product);
                    seller.harvestCosts.RemoveAt(itemIndex);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public void HarvestSort()
        {
            allFarmers = allFarmers.OrderByDescending(h =>
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
