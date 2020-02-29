using AuctionBLL;
using InterfaceBLL;
using InterfaceDAL;

namespace Resolver
{
    public class AuctionResolver
    {
            public static IBLL GetBll()
            {
                return new Auction.App(GetDAL());
            }

            public static IDAL GetDAL()
            {
                return new SQLBase.SqlDal();
            }
            /*
                Logger.InitLogger();//инициализация - требуется один раз в начале

                Logger.Log.Info("Ура заработало!");
             */
    }
}
