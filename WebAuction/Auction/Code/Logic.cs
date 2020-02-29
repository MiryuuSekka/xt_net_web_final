using Entity.Classes;
using InterfaceBLL;
using Resolver;

namespace Auction.Code
{
    public class Logic
    {
        public static User CurrentUser;

        public IBLL Code;
        public Logic()
        {
            Code = AuctionResolver.GetBll();
        }
    }
}