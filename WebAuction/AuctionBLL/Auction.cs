using Entity.Classes;
using InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AuctionBLL
{
    public class Auction
    {
        public class App : InterfaceBLL.IBLL
        {
            internal IDAL Dal;

            public App(IDAL Dal)
            {
                this.Dal = Dal;
            }

            #region Add
            public int AddBet(Bet NewData)
            {
                return Dal.AddBet(NewData);
            }
            public int AddUser(User NewData)
            {
                Regex.Replace(NewData.Name, @"\s+", "");
                Regex.Replace(NewData.Password, @"\s+", "");
                if (NewData.Name.Length < 3)
                {
                    throw new ArgumentException("too short name");
                }
                if (NewData.Password.Length < 5)
                {
                    throw new ArgumentException("too short password");
                }
                return Dal.AddUser(NewData);
            }
            public int AddLot(Lot NewData, List<Tag> Tags)
            {
                if (NewData.Product.Company.Length < 2)
                {
                    throw new ArgumentException("too short company name");
                }
                if (NewData.Product.Title.Length < 3)
                {
                    throw new ArgumentException("too short title");
                }
                if (NewData.Price < 0)
                {
                    throw new ArgumentException("price must be above 0");
                }
                if (NewData.DateStart > NewData.DateEnd)
                {
                    throw new ArgumentException("Start date must be before end date");
                }
                if (NewData.DateStart > DateTime.Now)
                {
                    throw new ArgumentException("auction can't be started before create");
                }
                return Dal.AddLot(NewData, Tags);
            }
            public void AddPhoto(Photo NewData, int ProductId)
            {
                Dal.AddPhoto(NewData, ProductId);
            }
            #endregion

            #region delete            
            public void DeleteUser(int Id)
            {
                var user = GetUserById(Id);
                if (user != null)
                {
                    Dal.DeleteUser(Id);
                }
            }
            public void DeleteLot(int LotId)
            {
                Dal.DeleteLot(LotId);
            }
            public void DeleteBet(int BetId)
            {
                Dal.DeleteBet(BetId);
            }
            public void DeletePhoto(int Id)
            {
                Dal.DeletePhoto(Id);
            }

            #endregion

            #region edit
            public void ChangeUser(User NewData)
            {
                Dal.ChangeUser(NewData);
            }
            public void ChangeLot(Lot NewData)
            {
                if (NewData.Product.Company.Length < 2)
                {
                    throw new ArgumentException("too short company name");
                }
                if (NewData.Product.Title.Length < 3)
                {
                    throw new ArgumentException("too short title");
                }
                if (NewData.Price < 0)
                {
                    throw new ArgumentException("price must be above 0");
                }
                if (NewData.DateStart > NewData.DateEnd)
                {
                    throw new ArgumentException("Start date must be before end date");
                }
                if (NewData.DateStart > DateTime.Now)
                {
                    throw new ArgumentException("auction can't be started before create");
                }
                Dal.ChangeLot(NewData);
            }

            #endregion

            #region get       
            public Lot GetLotById(int Id)
            {
                return Dal.GetLotById(Id);
            }
            public User GetUserById(int Id)
            {
                return Dal.GetUserById(Id);
            }
            public decimal GetMaxPriceOfLot(int LotId)
            {
                var Lot = GetLotById(LotId);
                var bets = GetAllLotsBet(LotId);
                decimal Max;
                if (bets.Count()>0)
                {
                    Max = bets.Max(x => x.Price);
                    return Max;
                }
                return Lot.Price;
            }

            public IEnumerable<Lot> GetLots()
            {
                return Dal.GetLots();
            }
            public IEnumerable<User> GetUsers()
            {
                return Dal.GetUsers();
            }
            public IEnumerable<Tag> GetTags()
            {
                return Dal.GetTags();
            }

            public IEnumerable<Tag> GetProductTags(int LogId)
            {
                return Dal.GetProductTags(LogId);
            }
            public IEnumerable<Bet> GetAllLotsBet(int LotId)
            {
                return Dal.GetAllLotsBet(LotId);
            }
            public IEnumerable<Bet> GetAllUserBets(int UserId)
            {
                return Dal.GetAllUserBets(UserId);
            }

            public void ChangeLotTags(int LotId, List<Tag> SelectedTags)
            {
                Dal.ChangeLotTags(LotId, SelectedTags);
            }
            #endregion
        }
    }
}
