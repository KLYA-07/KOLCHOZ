using DataAccessLayer;
using Ninject.Modules;
using Model;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Farmer>>().To<DapperRepository<Farmer>>().InSingletonScope();
        }
    }
}
