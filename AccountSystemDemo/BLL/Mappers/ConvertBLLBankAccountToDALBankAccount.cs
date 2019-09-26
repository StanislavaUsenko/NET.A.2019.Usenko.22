using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public class ConvertBLLBankAccountToDALBankAccount : IConverter<BLL.Interface.Entities.BankAccount, DAL.Interface.DTO.BankAccount>
    {
        public List<DAL.Interface.DTO.BankAccount> ConvertList(List<Interface.Entities.BankAccount> objects)
        {
            if (objects == null && objects.Count == 0)
            {
                throw new ArgumentNullException();
            }

            List<DAL.Interface.DTO.BankAccount> accounts = new List<DAL.Interface.DTO.BankAccount>();
            foreach (var o in objects)
            {
                accounts.Add(new DAL.Interface.DTO.BankAccount(o.CardID, o.Name, o.LastName, o.Amount, o.BonusAmount, (DAL.Interface.DTO.CardStatusEnum)o.CardStatus));
            }

            return accounts;
        }

        public DAL.Interface.DTO.BankAccount ConvertObject(Interface.Entities.BankAccount obj)
        {
            return (obj != null)
                ? new DAL.Interface.DTO.BankAccount(obj.CardID, obj.Name, obj.LastName, obj.Amount, obj.BonusAmount, (DAL.Interface.DTO.CardStatusEnum)obj.CardStatus)
                : throw new ArgumentNullException();
        }
    }
}
