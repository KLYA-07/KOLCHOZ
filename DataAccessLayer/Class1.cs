using Model;

namespace DataAccessLayer
{
    public class EntityRepository : IRepository<Farmer>
    {
        private EFDBContext dbContext;

        public EntityRepository(EFDBContext context)
        {
            dbContext = context;
        }
    }
}
