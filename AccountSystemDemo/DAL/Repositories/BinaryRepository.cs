using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System.IO;


namespace DAL.Repositories
{
    public class BinaryRepository: IRepository<BankAccount>
    {
        private readonly string path;

        public BinaryRepository(string path)
        {
            this.path = path;
        }
        public void AppendToEnd(BankAccount obj)
        {
            using (var bw = new BinaryWriter(File.Open(path, FileMode.Append, FileAccess.Write, FileShare.None)))
            {
                Writer(bw, obj);
            }
        }

        public List<BankAccount> Read()
        {
            var accounts = new List<BankAccount>();
            using (var binaryReader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)))
            {
                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    var account = Reader(binaryReader);
                    accounts.Add(account);
                }
            }

            return accounts;
        }

        public void Write(List<BankAccount> listObj)
        {
            using (var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                foreach (var account in listObj)
                {
                    Writer(binaryWriter, account);
                }
            }
        }


        private static void Writer(BinaryWriter binary, BankAccount obj)
        {
            binary.Write(obj.CardID);
            binary.Write(obj.Name);
            binary.Write(obj.LastName);
            binary.Write(obj.Amount);
            binary.Write(obj.BonusAmount);
            binary.Write((int)obj.CardStatus);
        }

        private static BankAccount Reader(BinaryReader binary)
        {
            var cardid = binary.ReadInt32();
            var name = binary.ReadString();
            var lastname = binary.ReadString();
            var amount = binary.ReadDouble();
            var bonusamount = binary.ReadInt32();
            var status = binary.ReadInt32();

            return new BankAccount(cardid, name, lastname, amount, bonusamount, (CardStatusEnum)status);
        }
    }
}
