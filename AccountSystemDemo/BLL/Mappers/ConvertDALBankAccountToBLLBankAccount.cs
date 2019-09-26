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
    public class ConvertDALBankAccountToBLLBankAccount : IConverter<DAL.Interface.DTO.BankAccount, BLL.Interface.Entities.BankAccount>
    {
        public List<Interface.Entities.BankAccount> ConvertList(List<DAL.Interface.DTO.BankAccount> objects)
        {
            if(objects == null && objects.Count == 0)
            {
                throw new ArgumentNullException();
            }

            List<Interface.Entities.BankAccount> accounts = new List<Interface.Entities.BankAccount>();
            foreach(var o in objects)
            {
                accounts.Add(new Interface.Entities.BankAccount(o.CardID, o.Name, o.LastName, o.Amount, o.BonusAmount, (BLL.Interface.Entities.CardStatusEnum) o.CardStatus));
            }

            return accounts;
        }

        public Interface.Entities.BankAccount ConvertObject(DAL.Interface.DTO.BankAccount obj)
        {
            return (obj != null)
                ? new Interface.Entities.BankAccount(obj.CardID, obj.Name, obj.LastName, obj.Amount, obj.BonusAmount, (BLL.Interface.Entities.CardStatusEnum) obj.CardStatus)
                : throw new ArgumentNullException();
        }
    }
}
