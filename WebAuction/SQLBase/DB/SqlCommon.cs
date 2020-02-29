using Entity.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLBase.DB
{
    internal class SqlCommon
    {
        public void Delete(string TableName, string ConnectionString, int Id)
        {
            var SqlCommand = $"DELETE FROM {TableName} WHERE Id={Id}";
            SendToDB(ConnectionString, SqlCommand);
        }

        public void SendToDB(string ConnectionString, string SqlCommand)
        {
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.ExecuteNonQuery();      //command.ExecuteScalar();  //can return id of added data?
            }
        }
    }
}
