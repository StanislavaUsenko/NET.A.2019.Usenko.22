using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO.NET
{
    public abstract class BaseRepository
    {
        /// <summary>
        /// ctor
        /// </summary>
        public BaseRepository() { }

        /// <summary>
        /// private method for take conection string from config
        /// </summary>
        /// <returns></returns>
        private string SqlConnect()
        {
            string connection = "Data Source=DESKTOP-NCDA0GK;Initial Catalog=AccountCabinet;Integrated Security=True";
            return connection;
        }

        /// <summary>
        /// method for read data from database with help ADO.Met
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlCommand">your sql command for request on database</param>
        /// <param name="converter">your delegate for the correct output of information</param>
        /// <param name="parameters">sql parameters for sql command. Its can be null, if you select all records</param>
        /// <returns>returt list of data from database</returns>
        public List<T> GetData<T>(string sqlCommand, Func<System.Data.IDataReader, T> converter, List<SqlParameter> parameters)
        {
            try
            {
                List<T> item = new List<T>();
                using (SqlConnection connection = new SqlConnection(SqlConnect()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlCommand, connection);
                    if (parameters != null)
                        foreach (var i in parameters)
                            command.Parameters.Add(i);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            T repos = converter(reader);
                            item.Add(repos);
                        }
                    return item;
                }
            }
            catch (SqlException sqlException)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// method for write information on database with help ADO.NET
        /// </summary>
        /// <param name="sqlCommand">your sql command for request on database</param>
        /// <param name="parameters">sql parameters for sql command</param>
        public void PostData(string sqlCommand, List<SqlParameter> parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(SqlConnect()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlCommand, connection);
                    foreach (var i in parameters)
                    {
                        command.Parameters.Add(i);
                    }
                    int number = command.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}


