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

        public string GetCoinIcon(Entity.Common.Role role)
        {
            return "https://cdn1.iconfinder.com/data/icons/business-minimal/512/money_Business_dollar_Cash_Finance_currency_Payment_finance_Coin-128.png";
        }

            public string GetUserIcon(Entity.Common.Role role)
        {
            switch (role)
            {
                case Entity.Common.Role.Admin:
                    return "https://cdn3.iconfinder.com/data/icons/stars-5/512/gold_star-512.png";
                case Entity.Common.Role.Seller:
                    return "https://cdn3.iconfinder.com/data/icons/stars-5/512/silver_star-512.png";
                case Entity.Common.Role.Customer:
                    return "https://cdn3.iconfinder.com/data/icons/stars-5/512/bronze_star-512.png";
                default:
                    return "https://cdn3.iconfinder.com/data/icons/stars-5/512/disabled_star-512.png";
            }
        }
        //main icon https://cdn2.iconfinder.com/data/icons/money-finance/512/auction-hammer-512.png
        //add bet https://cdn0.iconfinder.com/data/icons/auction-and-competition-filled-outline-1/64/offer-offering-hand-give-bid-bidding-auction-512.png
        //sold https://cdn0.iconfinder.com/data/icons/auction-and-competition-filled-outline-1/64/sold-sign-label-tag-512.png
        //view own bet https://cdn0.iconfinder.com/data/icons/auction-and-competition-filled-outline-1/64/cart-shopping_cart-shopping-marketing-512.png
        //view own lot https://cdn0.iconfinder.com/data/icons/auction-and-competition-filled-outline-1/64/sheet-list-name-paper-document-pen-512.png
        //pay https://cdn0.iconfinder.com/data/icons/auction-and-competition-filled-outline-1/64/payment-credit_card-card-visa-512.png
        //add lot https://cdn0.iconfinder.com/data/icons/auction-and-competition-filled-outline-1/64/new_items-sign-tag-new-512.png
        //user management https://cdn0.iconfinder.com/data/icons/auction-and-competition-filled-outline-1/64/auctioneer-auction-hitting-512.png


    }
}