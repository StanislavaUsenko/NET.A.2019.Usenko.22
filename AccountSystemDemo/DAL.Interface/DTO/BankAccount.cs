using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class BankAccount
    {

        public int CardID { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public double Amount { get; set; }
        public int BonusAmount { get; set; }
        public CardStatusEnum CardStatus { get; private set; }

        public BankAccount(int cardId, string name, string lastName, double amount, int bonus, CardStatusEnum cardStatus)
        {
            this.BonusAmount = bonus;
            this.CardID = cardId;
            this.Name = name;
            this.LastName = lastName;
            this.Amount = amount;
            this.CardStatus = cardStatus;
        }
    }
}
