using Entity.Classes;
using System.Collections.Generic;

namespace InterfaceBLL
{
    public interface IBLL
    {
        int AddBet(Bet NewData);
        int AddUser(User NewData);

        void DeleteUser(int Id);
        
        void ChangeUser(User NewData);

        Lot GetLotById(int Id);
        User GetUserById(int Id);

        IEnumerable<Lot> GetLots();
        IEnumerable<User> GetUsers();

        IEnumerable<Tag> GetProductTags(int LogId);
        IEnumerable<Bet> GetAllLotsBet(int LotId);

        decimal GetMaxPriceOfLot(int LotId);

        /*
        #region Lot
        int AddLot(Lot NewData);
        IEnumerable<Lot> GetLots();
        IEnumerable<Lot> GetLotByTag(string Tag);
        void DeleteLot(int Id);
        void ChangeLot(Lot NewData);
        #endregion

        #region Product
        int AddProduct(Product NewData);
        IEnumerable<Product> GetProducts();
        Product GetProductById(int Id);
        void DeleteProduct(int Id);
        void ChangeProduct(Product NewData);
        #endregion

        #region Bet
        IEnumerable<Bet> GetBets();
        Bet GetBetById(int Id);
        void DeleteBet(int Id);
        #endregion

        #region User
        #endregion
        */


    }
}
