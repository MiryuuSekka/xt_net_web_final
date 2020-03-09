using Entity.Classes;
using System.Collections.Generic;

namespace InterfaceDAL
{
    public interface IDAL
    {
        #region add
        int AddLot(Lot NewData, List<Tag> Tags);

        int AddBet(Bet NewData);

        int AddUser(User NewData);

        void AddPhoto(Photo newData, int ProductId);
        #endregion

        #region edit
        void ChangeLot(Lot NewData);

        void ChangeUser(User NewData);
        void ChangeLotTags(int LotId, List<Tag> SelectedTags);
        #endregion

        #region delete
        void DeleteLot(int Id);

        void DeleteBet(int Id);

        void DeleteProduct(int Id);

        void DeleteUser(int Id);

        void DeletePhoto(int Id);

        #endregion

        #region get
        User GetUserById(int Id);

        Product GetProductById(int Id);

        Lot GetLotById(int Id);
        


        IEnumerable<User> GetUsers();

        IEnumerable<Product> GetProducts();

        IEnumerable<Lot> GetLots();

        IEnumerable<Tag> GetTags();

        IEnumerable<Tag> GetProductTags(int LogId);

        IEnumerable<Bet> GetAllLotsBet(int LotId);

        IEnumerable<Bet> GetAllUserBets(int UserId);
        #endregion
    }
}
