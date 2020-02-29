using Entity.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLBase.DB
{
    internal class SqlProduct
    {
        private string ConnectionString;
        private string SqlCommand;
        private string Table;

        public SqlProduct()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["AuctionDB"].ConnectionString;
            Table = "product";
        }

        public void AddData(Product data)
        {
            int id = (int)data.Status + 1;
            SqlCommand = $"INSERT INTO {Table}(name, password, id_role) values ('{data.Title}','{data.Company}', {id})";

            var common = new SqlCommon();
            common.SendToDB(ConnectionString, SqlCommand);
        }

        public void Delete(int Id)
        {
            var common = new SqlCommon();
            common.Delete(Table, ConnectionString, Id);
        }

        public void Edit(Product Edited)
        {
            SqlCommand = $"UPDATE {Table} SET name = '{Edited.Status}', password = '{Edited.Company}', id_role = {Edited.Status} WHERE Id={Edited.Id}";

            var common = new SqlCommon();
            common.SendToDB(ConnectionString, SqlCommand);
        }

        public IEnumerable<Product> GetAll()
        {
            SqlCommand = "ProductSummary";
            var result = new List<Product>();
            int id;
            Product data;

            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["id"];
                        data = result.Find(x => x.Id == id);
                        if (data == null)
                        {
                            data = new Product
                            {
                                Company = reader["company"].ToString(),
                                Id = (int)reader["id"],
                                Title = reader["ProductTitle"].ToString(),
                                Status = (Entity.Common.Status)Enum.Parse(typeof(Entity.Common.Status), reader["StatusTitle"].ToString())
                            };
                            result.Add(data);
                        }
                        data.Photos.Add(new Photo() {

                        });

                    }
                }
            }
            return result;
        }
    }
}
