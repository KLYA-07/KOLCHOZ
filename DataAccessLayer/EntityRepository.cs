using Model;

namespace DataAccessLayer
{
    public class EntityRepository : IRepository<Farmer>
    {
        private EFDBContext dbContext;

        public EntityRepository()
        {
            dbContext = new EFDBContext();
        }

        public void Create(Farmer obj)
        {
            dbContext.Set<Farmer>().Add(obj);
            dbContext.SaveChanges();
        }

        public IEnumerable<Farmer> ReadAll()
        {
            return new List<Farmer>(dbContext.Set<Farmer>());
        }

        public Farmer ReadByID(int id)
        {
            return dbContext.Farmers.Where(o => o.ID == id).FirstOrDefault();
        }

        public void Update(Farmer obj)
        {
            Farmer origin = dbContext.Farmers.Where(o => o.ID == obj.ID).FirstOrDefault();

            origin.farmerName = obj.farmerName;
            origin.finacialCapital = obj.finacialCapital;
            origin.fieldSize = obj.fieldSize;
            origin.lastHarvest = obj.lastHarvest;
            origin.harvestCosts = obj.harvestCosts;
            origin.cattleHeadboard = obj.cattleHeadboard;
            origin.cultivatingCrops = obj.cultivatingCrops;

            dbContext.SaveChanges();
        }

        public void Delete(Farmer obj)
        {
            dbContext.Set<Farmer>().Remove(obj);
            dbContext.SaveChanges();
        }
    }
}
