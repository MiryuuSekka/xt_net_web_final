using Entity.Classes;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLBase.DB
{
    internal class SqlPhoto
    {
        private string ConnectionString;
        private string SqlCommand;
        private string Table;


        public SqlPhoto()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["AuctionDB"].ConnectionString;
            Table = "Photo";
        }

        public void AddData(Photo data)
        {
            SqlCommand = $"INSERT INTO {Table}(url, comment) values ('{data.Path}','{data.Comment}')";

            var common = new SqlCommon();
            common.SendToDB(ConnectionString, SqlCommand);
        }

        public void Delete(int Id)
        {
            var common = new SqlCommon();
            common.Delete(Table, ConnectionString, Id);
        }

        public void Edit(Photo Edited)
        {
            SqlCommand = $"UPDATE Photo SET url = '{Edited.Path}', comment = '{Edited.Comment}' WHERE Id={Edited.Id}";

            var common = new SqlCommon();
            common.SendToDB(ConnectionString, SqlCommand);
        }

        public IEnumerable<Photo> GetAll()
        {
            SqlCommand = $"SELECT * FROM {Table}";
            var result = new List<Photo>();

            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new Photo
                        {
                            Path = reader["url"].ToString(),
                            Id = (int)reader["id"],
                            Comment = reader["password"].ToString()};
                        result.Add(data);
                    }
                }
            }
            return result;
        }
    
    }
}
