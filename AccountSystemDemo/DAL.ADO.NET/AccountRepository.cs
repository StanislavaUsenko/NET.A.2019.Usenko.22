using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL.ADO.NET
{
    public class AccountRepository : BaseRepository, IRepository<BankAccount>
    {

        /// <summary>
        /// sql For Insert Cabinet
        /// </summary>
        private const string sqlForInsertCabinet = "INSERT INTO BankAccount(name,lastName,amount,bonus,cardStatus) VALUES (@name, @lastName, @dateBirth,@amount,@bonus,@cardStatus)";
        /// <summary>
        /// sql For Delete Cabinet
        /// </summary>
        private const string sqlForDeleteCabinet = "truncate table BankAccount";
        /// <summary>
        /// sql For Select All Cabinets
        /// </summary>
        private const string sqlForSelectAllCabinets = "SELECT * FROM BankAccount";
        /// <summary>
        /// sql For Select Cabinet By Id
        /// </summary>
        private const string sqlForSelectCabinetById = "Select * From BankAccount Where cardId = @cardId";
        /// <summary>
        /// convert data from DataReader to user class Cabinet
        /// </summary>
        private Func<IDataReader, BankAccount> converter = (reader) => new BankAccount(
            (int)reader["cardId"],
            reader["name"].ToString(),
            reader["lastName"].ToString(),
            (double)reader["amount"],
            (int)reader["bonus"],
            (CardStatusEnum)reader["cardStatus"]);
        public AccountRepository() : base()
        {
        }

        public void AppendToEnd(BankAccount obj)
        {
            base.PostData(sqlForInsertCabinet, SQLParameters(obj, false, obj.CardID));
        }

        public List<BankAccount> Read()
        {
            return base.GetData<BankAccount>(sqlForSelectAllCabinets,converter, null));
        }

        public void Write(List<BankAccount> listObj)
        {
            base.PostData(sqlForDeleteCabinet, null);
            foreach(var c in listObj)
            {
                base.PostData(sqlForInsertCabinet, SQLParameters(c, false, c.CardID));
            }
        }

        private List<SqlParameter> SQLParameters(BankAccount item, bool forFinbById, int? id)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (!forFinbById)
            {
                sqlParameters.Add(new SqlParameter("@amount", item.Amount));
                sqlParameters.Add(new SqlParameter("@bonus", item.BonusAmount));
                sqlParameters.Add(new SqlParameter("@firstName", item.Name));
                sqlParameters.Add(new SqlParameter("@lastName", item.LastName));
                sqlParameters.Add(new SqlParameter("@cardStatus", (int)item.CardStatus));
                sqlParameters.Add(new SqlParameter("@id", item.CardID));
            }
            else
            {
                if (id != null)
                    sqlParameters.Add(new SqlParameter("@id", id));
                else
                    throw new ArgumentNullException();
            }
            return sqlParameters;
        }
    }
}
