using Entity.Classes;
using SQLBase.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLBase
{
    public class SqlDal : InterfaceDAL.IDAL
    {
        SqlRead DataBase;

        public SqlDal()
        {
            DataBase = new SqlRead();
        }

        #region add
        public int AddBet(Bet NewData)
        {
            return DataBase.AddData(NewData);
        }

        public int AddLot(Lot NewData, List<Tag> Tags)
        {
            return DataBase.AddLot(NewData, Tags);
        }

        public int AddUser(User NewData)
        {
            return DataBase.AddData(NewData);
        }

        public void AddPhoto(Photo newData, int ProductId)
        {
            var id = DataBase.AddData(newData);
            DataBase.AddConnectPhotoToProduct(id, ProductId);
        }
        #endregion

        #region change
        public void ChangeLot(Lot NewData)
        {
            try
            {
                DataBase.Edit(NewData.Product);
                DataBase.Edit(NewData);
                var photos = DataBase.GetAllProductPhotoById(NewData.Product.Id);
                foreach (var item in NewData.Product.Photos)
                {
                    if (!photos.ToList().Contains(item))
                    {
                        var id = DataBase.AddData(item);
                        DataBase.AddConnectPhotoToProduct(id, NewData.Product.Id);
                    }
                }
                foreach (var item in photos)
                {
                    if (!NewData.Product.Photos.Contains(item))
                    {
                        DataBase.DeletePhoto(item.Id);
                    }
                }
            }
            catch (Exception e)
            {
                Entity.Helpers1.Logger.Log.Error("Error ChangeLot "+e.Message);
            }
        }
        
        public void ChangeUser(User NewData)
        {
            DataBase.Edit(NewData);
        }
        #endregion

        #region delete
        public void DeleteBet(int Id)
        {
            DataBase.DeleteBet(Id);
        }

        public void DeleteLot(int Id)
        {
            DataBase.DeleteLot(Id);
        }

        public void DeleteProduct(int Id)
        {
            DataBase.DeleteProduct(Id);
        }

        public void DeleteUser(int Id)
        {
            DataBase.DeleteUser(Id);
        }

        public void DeletePhoto(int Id)
        {
            DataBase.DeletePhoto(Id);
        }

        #endregion

        #region get
        public User GetUserById(int Id)
        {
            return DataBase.GetUserById(Id);
        }

        public Lot GetLotById(int Id)
        {
            return DataBase.GetLotById(Id);
        }

        public Product GetProductById(int Id)
        {
            return DataBase.GetProductById();
        }



        public IEnumerable<Bet> GetAllLotsBet(int LotId)
        {
            return DataBase.GetAllLotsBet(LotId);
        }

        public IEnumerable<Bet> GetAllUserBets(int UserId)
        {
            return DataBase.GetAllUserBets(UserId);
        }

        public IEnumerable<Tag> GetProductTags(int LogId)
        {
            return DataBase.GetProductTags(LogId);
        }

        public IEnumerable<Tag> GetTags()
        {
            return DataBase.GetTags();
        }

        public IEnumerable<User> GetUsers()
        {
            return DataBase.GetAllUser();
        }

        public IEnumerable<Lot> GetLots()
        {
            return DataBase.GetAllShortLotInfo();
        }

        public IEnumerable<Product> GetProducts()
        {
            return DataBase.GetAllProduct();
        }

        public void ChangeLotTags(int LotId, List<Tag> SelectedTags)
        {
            var LotTags = DataBase.GetProductTags(LotId);
            var Tags = DataBase.GetTags();
            foreach (var item in Tags)
            {
                var NowChecked = SelectedTags.Where(x => x.Id == item.Id).FirstOrDefault() != null;
                var WasChecked = LotTags.Where(x => x.Id == item.Id).FirstOrDefault() != null;
                
                if (!NowChecked && WasChecked)
                {
                    DataBase.DeleteConnectTagToLot(item.Id, LotId);
                }
                if (NowChecked && !WasChecked)
                {
                    DataBase.AddConnectTagToLot(item.Id, LotId);
                }
            }
        }

        #endregion
    }
}
