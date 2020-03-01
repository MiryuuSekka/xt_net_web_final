using Entity.Classes;
using InterfaceBLL;
using Resolver;
using System.Linq;

namespace Auction.Code
{
    public class Logic
    {
        public static User CurrentUser = GetDefaultUser();

        public IBLL Code;
        public Logic()
        {
            Code = AuctionResolver.GetBll();
        }

        private static User GetDefaultUser()
        {
            var Code = AuctionResolver.GetBll();
            return Code.GetUserById(2);
        }

        public bool CheckUserData(string name, string password)
        {
            var all = Code.GetUsers();
            all = all.Where(x => x.Name == name);
            all = all.Where(x => x.Password == password);
            return all.Count() > 0;
        }
        public bool IsUserExist(string name)
        {
            var all = Code.GetUsers();
            all = all.Where(x => x.Name == name);
            return all.Count() > 0;
        }
    }
}