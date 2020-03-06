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
        private string sqlExpression;

        public SqlRead()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["AuctionDB"].ConnectionString;
        }

        #region add
        public int AddLot(Lot data, List<Tag>Tags)
        {
            for (int i = 0; i < data.Product.Photos.Count; i++)
            {
                data.Product.Photos[i].Id = AddData(data.Product.Photos[i]);
            }
            data.Product.Id = AddData(data.Product);
            foreach (var item in data.Product.Photos)
            {
                AddConnectPhotoToProduct(item.Id, data.Product.Id);
            }
            data.Id = AddData(data);
            foreach (var item in Tags)
            {
                AddConnectTagToLot(item.Id, data.Id);
            }

            return data.Id;
        }
        public int AddData(User data)
        {
            sqlExpression = "AddUser";

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
            sqlExpression = "AddBet";

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

        private int AddData(Lot data)
        {
            sqlExpression = "AddLot";

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
        private int AddData(Photo data)
        {
            sqlExpression = "AddPhoto";

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
        private int AddData(Product data)
        {
            sqlExpression = "AddProduct";

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
            sqlExpression = "AddTag";

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
            sqlExpression = "AddPhotoToProduct";

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
            sqlExpression = "AddTagToLot";

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
            var UserLots = GetAllShortLotInfo().Where(x => x.Seller.Id == id);
            foreach (var item in UserLots)
            {
                DeleteLot(item.Id);
            }
            Delete("BetTable", "id_user", id);
            Delete("UserTable", "id_user", id);
        }
        public void DeleteBet(int id)
        {
            Delete("BetTable", "id_bet", id);
        }
        public void DeleteLot(int id)
        {
            Delete("BetTable", "id_lot", id);
            Delete("LotTags", "id_lot", id);
            Delete("LotTable", "id_lot", id);
        }
        public void DeletePhoto(int id)
        {
            Delete("PhotoTable", "id_photo", id);
            Delete("ProductPhoto", "id_photo", id);
        }
        public void DeleteProduct(int id)
        {
            var Lots = GetAllShortLotInfo().Where(x=>x.Product.Id==id);
            foreach (var item in Lots)
            {
                DeleteLot(item.Id);
            }
            Delete("ProductTable", "id_product", id);
            Delete("ProductPhoto", "id_product", id);
        }
        public void DeleteTag(int id)
        {
            Delete("TagTable", "id_tag", id);
            Delete("LotTags", "id_tag", id);
        }

        private void Delete(string TableName, string ColumnName, int Id)
        {
            var SqlCommand = $"DELETE FROM {TableName} WHERE {ColumnName}={Id}";
            using (var SqlConnection = new SqlConnection(ConnectionString))
            {
                SqlConnection.Open();
                var command = new SqlCommand(SqlCommand, SqlConnection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region edit
        public void Edit(User Edited)
        {
            sqlExpression = "EditUser";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = Edited.Id });
                command.Parameters.Add(new SqlParameter { ParameterName = "@role", Value = Edited.Role });
                command.Parameters.Add(new SqlParameter { ParameterName = "@pass", Value = Edited.Password });
                command.Parameters.Add(new SqlParameter { ParameterName = "@name", Value = Edited.Name });

                var reader = command.ExecuteReader();
            }
        }
        #endregion

        #region get
        private Lot GetLotshortInfo(int id)
        {
            var LotInfo = new Lot();
            LotInfo.Product = new Product();
            LotInfo.Product.Photos = new List<Photo>();
            var photo = new Photo();

            sqlExpression = "GetLotShortInfo";
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
                        LotInfo.Product.Id = (int)reader[7];
                    }
                }
                reader.Close();
            }
            return LotInfo;
        }
        private IEnumerable<int> GetLotsId()
        {
            var result = new List<int>();

            sqlExpression = "GetLotsId";
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

            sqlExpression = "GetUsers";
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

            sqlExpression = "GetUserById";
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

            sqlExpression = "GetTagByLotId";
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

            sqlExpression = "GetBetsAtLot";
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

            sqlExpression = "GetViewLotInfo";
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

            sqlExpression = "GetProductPhotos";
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
            var result = new List<Product>();
            int id;
            Product data;

            SqlCommand = "ProductSummary";
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

        public IEnumerable<Tag> GetTags()
        {
            var Tags = new List<Tag>();

            sqlExpression = "GetTags";
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
        #endregion
    }
}
