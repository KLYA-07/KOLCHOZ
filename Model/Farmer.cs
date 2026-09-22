namespace Model
{
    public class Farmer
    {
        public string farmerName { get; set; } = string.Empty;
        public int finacialCapital { get; set; }
        public float fieldSize { get; set; }
        public Dictionary<string, int> lastHarvest { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> harvestCosts { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> cattleHeadboard { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> cultivatingCrops { get; set; } = new Dictionary<string, int>();

        public Farmer(string farmerName, int finacialCapital, float fieldSize, Dictionary<string, int> lastHarvest, Dictionary<string, int> harvestCosts, Dictionary<string, int> cattleHeadboard, Dictionary<string, int> cultivatingCrops)
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
