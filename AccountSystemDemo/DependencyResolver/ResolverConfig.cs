using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using BLL.Mappers;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;
using DAL.ADO.NET;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IService <BankAccount>>().To<StandartBankAccountService>();
            //kernel.Bind<IRepository<DAL.Interface.DTO.BankAccount>>().To<BinaryRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IRepository<DAL.Interface.DTO.BankAccount>>().To<AccountRepository>();
            kernel.Bind<IConverter<BankAccount, DAL.Interface.DTO.BankAccount>>().To<ConvertBLLBankAccountToDALBankAccount>();
            kernel.Bind<IConverter<DAL.Interface.DTO.BankAccount, BankAccount>>().To<ConvertDALBankAccountToBLLBankAccount>();

            //kernel.Bind<IRepository>().To<FakeRepository>();
            //kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
