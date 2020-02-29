using Entity.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLBase.DB
{
    internal class SqlUser
    {
        private string ConnectionString;
        private string SqlCommand;
        private string Table;

        public SqlUser()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["AuctionDB"].ConnectionString;
            Table = "Users";
        }

        public void AddData(User data)
        {
            int id = (int)data.Role + 1;
            SqlCommand = $"INSERT INTO {Table}(name, password, id_role) values ('{data.Name}','{data.Password}', {id})";

            var common = new SqlCommon();
            common.SendToDB(ConnectionString, SqlCommand);
        }

        public void Delete(int Id)
        {
            var common = new SqlCommon();
            common.Delete(Table, ConnectionString, Id);
        }

        public void Edit(User Edited)
        {
            SqlCommand = $"UPDATE {Table} SET name = '{Edited.Name}', password = '{Edited.Password}', id_role = {Edited.Role} WHERE Id={Edited.Id}";

            var common = new SqlCommon();
            common.SendToDB(ConnectionString, SqlCommand);
        }

        public IEnumerable<User> GetAll()
        {
            SqlCommand = $"SELECT {Table}.id, {Table}.name, {Table}.password, roles.title FROM {Table} LEFT JOIN roles ON roles.id = {Table}.id_role";
            var result = new List<User>();
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new User
                        {
                            Name = reader["name"].ToString(),
                            Id = (int)reader["id"],
                            Password = reader["password"].ToString(),
                            Role = (Entity.Common.Role) Enum.Parse(typeof(Entity.Common.Role), reader["title"].ToString())
                        };
                        result.Add(data);
                    }
                }
            }
            return result;
        }
    }
}
