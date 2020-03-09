using Entity.Classes;
using System.Collections.Generic;

namespace InterfaceBLL
{
    public interface IBLL
    {
        int AddLot(Lot NewData, List<Tag> Tags);
        int AddBet(Bet NewData);
        int AddUser(User NewData);
        void AddPhoto(Photo NewData, int ProductId);

        void DeleteLot(int LotId);
        void DeleteUser(int Id);
        void DeleteBet(int BetId);
        void DeletePhoto(int Id);


        void ChangeUser(User NewData);
        void ChangeLot(Lot NewData);
        void ChangeLotTags(int LotId, List<Tag>SelectedTags);

        Lot GetLotById(int Id);
        User GetUserById(int Id);

        IEnumerable<Lot> GetLots();
        IEnumerable<User> GetUsers();

        IEnumerable<Tag> GetProductTags(int LogId);
        IEnumerable<Bet> GetAllLotsBet(int LotId);

        decimal GetMaxPriceOfLot(int LotId);

        IEnumerable<Tag> GetTags();
        IEnumerable<Bet> GetAllUserBets(int UserId);
    }
}
