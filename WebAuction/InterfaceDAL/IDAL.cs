using Entity.Classes;
using System.Collections.Generic;

namespace InterfaceDAL
{
    public interface IDAL
    {
        #region Lot
        int AddLot(Lot NewData);
        IEnumerable<Lot> GetLots();
        Lot GetLotById(int Id);
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
        int AddBet(Bet NewData);
        IEnumerable<Bet> GetBets();
        Bet GetBetById(int Id);
        void DeleteBet(int Id);
        void ChangeBet(Bet NewData);
        #endregion

        #region User
        int AddUser(User NewData);
        IEnumerable<User> GetUsers();
        User GetUserById(int Id);
        void DeleteUser(int Id);
        void ChangeUser(User NewData);
        #endregion
    }
}
