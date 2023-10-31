using Ninject.Modules;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.Concrete;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;

namespace RealEstateAutomation.Business.DependencyResolvers
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();
        }
    }
}