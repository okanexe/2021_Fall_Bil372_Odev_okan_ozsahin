using System.Data;
using System.Data.SqlClient;

namespace WinTicket.Util
{
    public class Operation
    {
        /// <summary>
        /// Get dataset
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string connectionString, string sqlCommand, string dataTable)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, connection))
                {

                    dataAdapter.Fill(dataSet, dataTable);
                }
            }
            return dataSet;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public int Insert(string connectionString, string sqlCommand)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public int Update(string connectionString, string sqlCommand)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public int Delete(string connectionString, string sqlCommand)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
