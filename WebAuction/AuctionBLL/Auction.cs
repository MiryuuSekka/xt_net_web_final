using Entity.Classes;
using InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            #region add
            public int AddBet(Bet NewData)
            {
                return Dal.AddBet(NewData);
            }

            public int AddLot(Lot NewData)
            {
                return Dal.AddLot(NewData);
            }

            public int AddProduct(Product NewData)
            {
                return Dal.AddProduct(NewData);
            }

            public int AddUser(User NewData)
            {
                return Dal.AddUser(NewData);
            }
            #endregion

            #region change
            public void ChangeBet(Bet NewData)
            {
                Dal.ChangeBet(NewData);
            }

            public void ChangeLot(Lot NewData)
            {
                Dal.ChangeLot(NewData);
            }

            public void ChangeProduct(Product NewData)
            {
                Dal.ChangeProduct(NewData);
            }

            public void ChangeUser(User NewData)
            {
                Dal.ChangeUser(NewData);
            }
            #endregion

            #region delete
            public void DeleteBet(int Id)
            {
                var bet = GetBetById(Id);
                if (bet != null)
                {
                    Dal.DeleteBet(Id);
                }
            }

            public void DeleteLot(int Id)
            {
                var lot = GetLotById(Id);
                if (lot != null)
                {
                    Dal.DeleteLot(Id);
                }
            }

            public void DeleteProduct(int Id)
            {
                var product = GetProductById(Id);
                if (product != null)
                {
                    Dal.DeleteProduct(Id);
                }
            }

            public void DeleteUser(int Id)
            {
                var user = GetUserById(Id);
                if (user != null)
                {
                    Dal.DeleteUser(Id);
                }
            }
            #endregion

            #region get
            public Bet GetBetById(int Id)
            {
                return Dal.GetBetById(Id);
            }

            public IEnumerable<Bet> GetBets()
            {
                return Dal.GetBets();
            }

            public Lot GetLotById(int Id)
            {
                return Dal.GetLotById(Id);
            }

            public IEnumerable<Lot> GetLotByTag(string Tag)
            {
                return Dal.GetLotByTag(Tag);
            }

            public IEnumerable<Lot> GetLots()
            {
                return Dal.GetLots();
            }

            public Product GetProductById(int Id)
            {
                return Dal.GetProductById(Id);
            }

            public IEnumerable<Product> GetProducts()
            {
                return Dal.GetProducts();
            }

            public User GetUserById(int Id)
            {
                return Dal.GetUserById(Id);
            }

            public IEnumerable<User> GetUsers()
            {
                return Dal.GetUsers();
            }
            #endregion

            public IEnumerable<Tag> GetProductTags(int LogId)
            {
                return Dal.GetProductTags(LogId);
            }
            public IEnumerable<Bet> GetAllLotsBet(int LotId)
            {
                return Dal.GetAllLotsBet(LotId);
            }
        }
    }
}
