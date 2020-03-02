using Entity;
using Entity.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SQLBase.DB
{
    public class SqlRead
    {
        private string ConnectionString;
        private string SqlCommand;
        private string Table;

        public SqlRead()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["AuctionDB"].ConnectionString;
        }

        #region add
        public int AddData(User data)
        {
            string sqlExpression = "AddUser";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@id_role", data.Role);
                command.Parameters.AddWithValue("@name", data.Name).SqlDbType = SqlDbType.VarChar;
                command.Parameters.AddWithValue("@pass", data.Password).SqlDbType = SqlDbType.VarChar;
                int.TryParse(command.ExecuteScalar().ToString(),out int result);
                return result;
            }
        }
        public int AddData(Bet data)
        {
            string sqlExpression = "AddBet";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@id_User", Value = data.Customer.Id });
                command.Parameters.Add(new SqlParameter { ParameterName = "@id_Lot", Value = data.Lot.Id });
                command.Parameters.Add(new SqlParameter { ParameterName = "@price", Value = data.Price });
                command.Parameters.Add(new SqlParameter { ParameterName = "@date", Value = data.Date});

                int.TryParse(command.ExecuteScalar().ToString(), out int result);
                return result;
            }
        }
        public int AddData(Lot data)
        {
            string sqlExpression = "AddLot";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@id_Seller", Value = data.Seller.Id });
                command.Parameters.Add(new SqlParameter { ParameterName = "@id_Product", Value = data.Product.Id });
                command.Parameters.Add(new SqlParameter { ParameterName = "@price", Value = data.Price });
                command.Parameters.Add(new SqlParameter { ParameterName = "@dateStart", Value = data.DateStart });
                command.Parameters.Add(new SqlParameter { ParameterName = "@dateEnd", Value = data.DateEnd });

                int.TryParse(command.ExecuteScalar().ToString(), out int result);
                return result;
            }
        }
        public int AddData(Photo data)
        {
            string sqlExpression = "AddPhoto";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@url", Value = data.Path });
                command.Parameters.Add(new SqlParameter { ParameterName = "@comment", Value = data.Comment });

                int.TryParse(command.ExecuteScalar().ToString(), out int result);
                return result;
            }
        }
        public int AddData(Product data)
        {
            string sqlExpression = "AddProduct";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@id_status", Value = data.Status });
                command.Parameters.Add(new SqlParameter { ParameterName = "@title", Value = data.Title });
                command.Parameters.Add(new SqlParameter { ParameterName = "@company", Value = data.Company });

                int.TryParse(command.ExecuteScalar().ToString(), out int result);
                return result;
            }
        }
        public int AddTag(string title)
        {
            string sqlExpression = "AddTag";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@title", Value = title });

                int.TryParse(command.ExecuteScalar().ToString(), out int result);
                return result;
            }
        }

        public int AddConnectPhotoToProduct(int Photo, int Product)
        {
            string sqlExpression = "AddPhotoToProduct";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@id_photo", Value = Photo });
                command.Parameters.Add(new SqlParameter { ParameterName = "@id_product", Value = Product });

                int.TryParse(command.ExecuteScalar().ToString(), out int result);
                return result;
            }
        }
        public int AddConnectTagToLot(int Tag, int Lot)
        {
            string sqlExpression = "AddTagToLot";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@id_tag", Value = Tag });
                command.Parameters.Add(new SqlParameter { ParameterName = "@id_lot", Value = Lot });

                int.TryParse(command.ExecuteScalar().ToString(), out int result);
                return result;
            }
        }
        #endregion

        #region delete
        public void DeleteUser(int id)
        {
            Delete("UserTable", id);
        }
        public void DeleteBet(int id)
        {
            Delete("BetTable", id);
        }
        public void DeleteLot(int id)
        {
            Delete("LotTable", id);
        }
        public void DeletePhoto(int id)
        {
            Delete("PhotoTable", id);
        }
        public void DeleteProduct(int id)
        {
            Delete("ProductTable", id);
        }
        public void DeleteTag(int id)
        {
            Delete("TagTable", id);
        }

        public void DeleteProductPhoto(int id)
        {
            Delete("ProductPhoto", id);
        }
        public void DeleteLotTags(int id)
        {
            Delete("LotTags", id);
        }

        private void Delete(string TableName, int Id)
        {
            var SqlCommand = $"DELETE FROM {TableName} WHERE Id={Id}";
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region edit
        #endregion

        #region get
        private Lot GetLotshortInfo(int id)
        {
            var LotInfo = new Lot();
            LotInfo.Product = new Product();
            LotInfo.Product.Photos = new List<Photo>();
            var photo = new Photo();
            string sqlExpression = "GetLotShortInfo";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LotInfo.Id = (int)reader[0];
                        LotInfo.DateStart = (DateTime)reader[1];
                        LotInfo.DateEnd = (DateTime)reader[2];
                        LotInfo.Price = (decimal)reader[3];
                        LotInfo.Seller = new User() { Id = (int)reader[4] };
                        photo.Path = reader[5].ToString();
                        photo.Comment = reader[6].ToString();
                        LotInfo.Product.Photos.Add(photo);
                    }
                }
                reader.Close();
            }
            return LotInfo;
        }
        private IEnumerable<int> GetLotsId()
        {
            var result = new List<int>();
            string sqlExpression = "GetLotsId";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add((int)reader["id_lot"]);
                    }
                }
            }
            return result;
        }
        public IEnumerable<Lot> GetAllShortLotInfo()
        {
            var Id = GetLotsId();
            var Lots = new List<Lot>();
            foreach (var item in Id)
            {
                Lots.Add(GetLotshortInfo(item));
            }
            return Lots;
        }

        public IEnumerable<User> GetAllUser()
        {
            var result = new List<User>();
            string sqlExpression = "GetUsers";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var data = new User
                        {
                            Id = (int)reader[0],
                            Name = reader[1].ToString(),
                            Password = reader[2].ToString(),
                            Role = (Common.Role)Enum.Parse(typeof(Common.Role), reader[3].ToString())
                        };
                        result.Add(data);
                    }
                }
            }
            return result;
        }
        public User GetUserById(int id)
        {
            var UserInfo = new User();
            string sqlExpression = "GetUserById";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserInfo.Id = id;
                        UserInfo.Name = reader[0].ToString();
                        UserInfo.Password = reader[1].ToString();
                        UserInfo.Role = (Common.Role)Enum.Parse(typeof(Common.Role), reader[2].ToString());
                    }
                }
                reader.Close();
            }
            return UserInfo;
        }


        public Lot GetLotById(int id)
        {
            var LotInfo = GetViewLotInfo(id);
            LotInfo.Product.Photos = GetAllProductPhotoById(LotInfo.Product.Id).ToList();

            return LotInfo;
        }
        public IEnumerable<Tag>GetProductTags(int LogId)
        {
            var Tags = new List<Tag>();
            string sqlExpression = "GetTagByLotId";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = LogId });

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tags.Add(new Tag()
                        {
                            Id = (int)reader[0],
                            Title = reader[1].ToString()
                        });
                    }
                }
                reader.Close();
            }
            return Tags;
        }
        public IEnumerable<Bet> GetAllLotsBet(int LotId)
        {
            var Bets = new List<Bet>();
            string sqlExpression = "GetBetsAtLot";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = LotId });

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bets.Add(new Bet()
                        {
                            Id = (int)reader[0],
                            Customer = new User() { Id = (int)reader[1] },
                            Price = (decimal)reader[2],
                            Date = (DateTime)reader[3]
                        });
                    }
                }
                reader.Close();
            }
            return Bets;
        }
        private Lot GetViewLotInfo(int id)
        {
            var LotInfo = new Lot();
            LotInfo.Id = id;
            string sqlExpression = "GetViewLotInfo";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LotInfo.Seller = new User() { Id = (int)reader[0] };
                        LotInfo.Price = (decimal)reader[1];
                        LotInfo.DateStart = (DateTime)reader[2];
                        LotInfo.DateEnd = (DateTime)reader[3];
                        LotInfo.Product = new Product()
                        {
                            Title = reader[4].ToString(),
                            Company = reader[5].ToString(),
                            Id = (int)reader[6],
                            Status = (Common.Status)Enum.Parse(typeof(Common.Status), reader[7].ToString())
                        };
                    }
                }
                reader.Close();
            }
            return LotInfo;
        }
        private IEnumerable<Photo>GetAllProductPhotoById(int ProductId)
        {
            var Photos = new List<Photo>();
            string sqlExpression = "GetProductPhotos";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = ProductId });

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Photos.Add(new Photo()
                        {
                            Id = (int)reader[0],
                            Comment = reader[1].ToString(),
                            Path = reader[2].ToString()
                        });
                    }
                }
                reader.Close();
            }
            return Photos;
        }

        public Product GetProductById()
        {
            return null;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            SqlCommand = "ProductSummary";
            var result = new List<Product>();
            int id;
            Product data;

            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.CommandType = CommandType.StoredProcedure;

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
                                Photos = new List<Photo>(),
                                Company = reader["company"].ToString(),
                                Id = (int)reader["id"],
                                Title = reader["ProductTitle"].ToString(),
                                Status = (Common.Status)Enum.Parse(typeof(Common.Status), reader["StatusTitle"].ToString())
                            };
                            result.Add(data);
                        }
                        data.Photos.Add(new Photo()
                        {
                            Path = reader["url"].ToString(),
                            Comment = reader["comment"].ToString()
                        });
                    }
                }
            }
            return result;
        }
        


        #endregion
        public void Edit(User Edited)
        {
            SqlCommand = $"UPDATE {Table} SET name = '{Edited.Name}', password = '{Edited.Password}', id_role = {Edited.Role} WHERE Id={Edited.Id}";

           // var common = new SqlCommon();
            //common.SendToDB(ConnectionString, SqlCommand);
        }

        public IEnumerable<User> GetAll_1()
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
                            Role = (Entity.Common.Role)Enum.Parse(typeof(Entity.Common.Role), reader["title"].ToString())
                        };
                        result.Add(data);
                    }
                }
            }
            return result;
        }

        private void Add111(string name, int age)
        {
            string sqlExpression = "sp_InsertUser";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                var nameParam = new SqlParameter { ParameterName = "@name", Value = name };
                command.Parameters.Add(nameParam);

                var ageParam = new SqlParameter { ParameterName = "@age", Value = age };
                command.Parameters.Add(ageParam);

                var result = command.ExecuteScalar();
            }
        }
        
        private void Get111()
        {
            string sqlExpression = "sp_GetUsers";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                    }
                }
                reader.Close();
            }
        }
        
    }
}
