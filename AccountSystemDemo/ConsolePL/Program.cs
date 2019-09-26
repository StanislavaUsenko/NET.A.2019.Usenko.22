using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IService<BankAccount> service = resolver.Get<IService<BankAccount>>();
            //IAccountNumberCreateService creator = resolver.Get<IAccountNumberCreateService>();

            service.AddBankAccount(new BankAccount(1, "test", "test", CardStatusEnum.Standart));
            service.AddBankAccount(new BankAccount(1, "test", "test", CardStatusEnum.Gold));
            service.AddBankAccount(new BankAccount(1, "test", "test", CardStatusEnum.Platinum));
            //service.OpenAccount("Account owner 1", AccountType.Base, creator);
            //service.OpenAccount("Account owner 2", AccountType.Base, creator);
            //service.OpenAccount("Account owner 3", AccountType.Silver, creator);
            //service.OpenAccount("Account owner 4", AccountType.Base, creator);

            var creditNumbers = service.GetAll().ToList();
            foreach (var t in creditNumbers)
            {
                service.Deposit(t.CardID, 100);
            }

            foreach (var item in service.GetAll())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.Withdraw(t.CardID, 10);
            }

            foreach (var item in service.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
