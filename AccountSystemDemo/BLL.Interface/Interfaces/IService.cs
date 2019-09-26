using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IService<T> where T: class
    {
        bool AddBankAccount(T obj);
        bool DeleteBankAccount(int id);
        bool Deposit(int id, double amount);
        bool Withdraw(int id, double amount);
        List<T> GetAll();
    }
}
