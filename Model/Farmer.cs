namespace Model
{
    public class Farmer
    {
        public string farmerName { get; set; } = string.Empty;
        public int finacialCapital { get; set; }
        public float fieldSize { get; set; }
        public Dictionary<string, int> lastHarvest { get; set; } = new Dictionary<string, int>();
        public List<int> harvestCosts { get; set; } = new List<int>();
        public List<string> cattleHeadboard { get; set; } = new List<string>();
        public List<string> cultivatingCrops { get; set; } = new List<string>();

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
