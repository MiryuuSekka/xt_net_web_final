using Entity;
using Entity.Classes;
using SQLBase.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

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

        public int AddLot(Lot NewData)
        {
           return DataBase.AddData(NewData);
        }

        public int AddProduct(Product NewData)
        {
            return DataBase.AddData(NewData);
        }

        public int AddUser(User NewData)
        {
            return DataBase.AddData(NewData);
        }
        #endregion


        #region change
        public void ChangeBet(Bet NewData)
        {
            throw new NotImplementedException();
        }

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
