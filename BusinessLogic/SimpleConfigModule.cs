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
            Bind<IModel>().To<Logic>().InSingletonScope();
            Bind<IFarmerFormatter>().To<FarmerFormatter>().InSingletonScope();
            Bind<IBusinessService>().To<BusinessService>().InSingletonScope();
        }
    }
}
