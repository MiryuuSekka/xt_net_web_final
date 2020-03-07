using Entity.Classes;
using SQLBase.DB;
using System;
using System.Collections.Generic;

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
        #endregion


        #region change

        public void ChangeLot(Lot NewData)
        {
            throw new NotImplementedException();
        }

        public void ChangeProduct(Product NewData)
        {
            throw new NotImplementedException();
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

        public IEnumerable<Bet> GetAllLotsBet(int LotId)
        {
            return DataBase.GetAllLotsBet(LotId);
        }

        public IEnumerable<Bet> GetAllUserBets(int UserId)
        {
            return DataBase.GetAllUserBets(UserId);
        }
        #endregion

        #region get
        public Bet GetBetById(int Id)
        {
            return null;
        }

        public IEnumerable<Bet> GetBets()
        {
            return null;
        }

        public Lot GetLotById(int Id)
        {
            return DataBase.GetLotById(Id);
        }

        public IEnumerable<Lot> GetLotByTag(string Tag)
        {
            return null;
        }

        public IEnumerable<Lot> GetLots()
        {
            return DataBase.GetAllShortLotInfo();
        }

        public Product GetProductById(int Id)
        {
            return DataBase.GetProductById();
        }

        public IEnumerable<Product> GetProducts()
        {
            return DataBase.GetAllProduct();
        }

        public IEnumerable<Tag> GetProductTags(int LogId)
        {
            return DataBase.GetProductTags(LogId);
        }

        public IEnumerable<Tag> GetTags()
        {
            return DataBase.GetTags();
        }

        public User GetUserById(int Id)
        {
            return DataBase.GetUserById(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return DataBase.GetAllUser();
        }
        #endregion
    }
}
