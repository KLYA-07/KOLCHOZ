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
            if(farmerIndex >= 0 && farmerIndex < allFarmers.Count)
            {
                allFarmers.RemoveAt(farmerIndex);
            }
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
        /// Метод, осуществляющий продажу между фермерами
        /// </summary>
        /// <param name="payerFarmerIndex">Индекс фермера-покупателя в списке</param>
        /// <param name="sellerFarmerIndex">Индекс фермера-продавца в списке</param>
        /// <param name="itemIndex">Индекс продукта в списке урожая фермера-продавца</param>
        /// <param name="itemsCount">Количество покупаемых предметов</param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод, осуществляющий сортировку списка фермеров по общему объему собранного урожая
        /// </summary>
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
