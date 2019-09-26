using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BankAccount
    {
        public int CardID { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public double Amount { get; set; }
        public int BonusAmount { get; set; }
        public CardStatusEnum CardStatus { get; private set; }

        public BankAccount(int cardId, string name, string lastName, CardStatusEnum cardStatus)
        {
            switch ((int)cardStatus)
            {
                case 0: this.BonusAmount = 100; break;
                case 1: this.BonusAmount = 200; break;
                case 2: this.BonusAmount = 300; break;
                default: throw new ArgumentException();
            }
            this.CardID = cardId;
            this.Name = name;
            this.LastName = lastName;
            this.CardStatus = cardStatus;
        }
        public BankAccount(int cardId, string name, string lastName, double amount, int bonus, CardStatusEnum cardStatus)
        {
            this.BonusAmount = bonus;
            this.CardID = cardId;
            this.Name = name;
            this.LastName = lastName;
            this.Amount = amount;
            this.CardStatus = cardStatus;
        }

        public override string ToString()
        {
            return $"{Name} {LastName} на вашем счету {Amount} у.е. и {BonusAmount} бонусов";
        }

    }
}
