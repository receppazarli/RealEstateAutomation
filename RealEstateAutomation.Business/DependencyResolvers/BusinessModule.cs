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

            Bind<IAdminService>().To<AdminManager>().InSingletonScope();
            Bind<IAdminDal>().To<EfAdminDal>().InSingletonScope();

            Bind<ICityService>().To<CityManager>().InSingletonScope();
            Bind<ICityDal>().To<EfCityDal>().InSingletonScope();

            Bind<ICountyService>().To<CountyManager>().InSingletonScope();
            Bind<ICountyDal>().To<EfCountyDal>().InSingletonScope();

            Bind<IEmployeeService>().To<EmployeeManager>().InSingletonScope();
            Bind<IEmployeeDal>().To<EfEmployeeDal>().InSingletonScope();

            Bind<IExpenseService>().To<ExpenseManager>().InSingletonScope();
            Bind<IExpensesDal>().To<EfExpenseDal>().InSingletonScope();

            Bind<IFieldService>().To<FieldManager>().InSingletonScope();
            Bind<IFieldDal>().To<EfFieldDal>().InSingletonScope();

            Bind<IHouseService>().To<HouseManager>().InSingletonScope();
            Bind<IHouseDal>().To<EfHouseDal>().InSingletonScope();

            Bind<IIncomeService>().To<IncomeManager>().InSingletonScope();
            Bind<IIncomeDal>().To<EfIncomeDal>().InSingletonScope();

            Bind<IOwnerService>().To<OwnerManager>().InSingletonScope();
            Bind<IOwnerDal>().To<EfOwnerDal>().InSingletonScope();

            Bind<IPlotService>().To<PlotManager>().InSingletonScope();
            Bind<IPlotDal>().To<EfPlotDal>().InSingletonScope();

            Bind<IPropertyService>().To<PropertyManager>().InSingletonScope();
            Bind<IPropertyDal>().To<EfPropertyDal>().InSingletonScope();

            Bind<ISaleService>().To<SaleManager>().InSingletonScope();
            Bind<ISaleDal>().To<EfSaleDal>().InSingletonScope();

            Bind<IShopService>().To<ShopManager>().InSingletonScope();
            Bind<IShopDal>().To<EfShopDal>().InSingletonScope();

            Bind<IUserAuthorizationService>().To<UserAuthorizationManager>().InSingletonScope();
            Bind<IUserAuthorizationDal>().To<EfUserAuthorizationDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

        }
    }
}