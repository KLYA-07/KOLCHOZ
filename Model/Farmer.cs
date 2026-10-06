namespace Model
{
    public class Farmer : IDomainObject
    {
        public int ID { get; set; }
        public string farmerName { get; set; }
        public int finacialCapital { get; set; }
        public float fieldSize { get; set; }
        public Dictionary<string, int> lastHarvest { get; set; }
        public List<int> harvestCosts { get; set; }
        public List<string> cattleHeadboard { get; set; }
        public List<string> cultivatingCrops { get; set; }

        public Farmer()
        {
            farmerName = "Новый фермер";
            finacialCapital = 0;
            fieldSize = 0;
            lastHarvest = new Dictionary<string, int>();
            harvestCosts = new List<int>();
            cattleHeadboard = new List<string>();
            cultivatingCrops = new List<string>();
        }
        public Farmer(string farmerName, int finacialCapital, float fieldSize, Dictionary<string, int> lastHarvest, List<int> harvestCosts, List<string> cattleHeadboard, List<string> cultivatingCrops)
        {
            this.farmerName = farmerName;
            this.finacialCapital = finacialCapital;
            this.fieldSize = fieldSize;
            this.lastHarvest = lastHarvest;
            this.harvestCosts = harvestCosts;
            this.cattleHeadboard = cattleHeadboard;
            this.cultivatingCrops = cultivatingCrops;
        }
    }
}
