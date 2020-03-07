using Entity.Classes;
using InterfaceBLL;
using Resolver;
using System;
using System.Collections.Generic;
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

        public string GetCoinIcon(Entity.Enums.Role role)
        {
            return "https://cdn1.iconfinder.com/data/icons/business-minimal/512/money_Business_dollar_Cash_Finance_currency_Payment_finance_Coin-128.png";
        }

        public string GetUserIcon(Entity.Enums.Role role)
        {
            switch (role)
            {
                case Entity.Enums.Role.Admin:
                    return "https://cdn3.iconfinder.com/data/icons/stars-5/512/gold_star-512.png";
                case Entity.Enums.Role.Seller:
                    return "https://cdn3.iconfinder.com/data/icons/stars-5/512/silver_star-512.png";
                case Entity.Enums.Role.Customer:
                    return "https://cdn3.iconfinder.com/data/icons/stars-5/512/bronze_star-512.png";
                default:
                    return "https://cdn3.iconfinder.com/data/icons/stars-5/512/disabled_star-512.png";
            }
        }


        public Lot ParseLot(string start, string end, string price)
        {
            var newLot = new Lot();
            
            decimal.TryParse(price, out decimal Price);
            newLot.Price = Price;
            
            DateTime.TryParse(start, out DateTime dateStart);
            newLot.DateStart = dateStart;
            
            DateTime.TryParse(end, out DateTime dateEnd);
            newLot.DateEnd = dateEnd;

            return newLot;
        }

        public Product ParseProduct(string Title, string Company, string status)
        {
            var Product = new Product();
            Product.Title = Title;
            Product.Company = Company;
            int.TryParse(status, out int statusInt);
            statusInt++;
            Product.Status = (Entity.Enums.Status)statusInt;

            return Product;
        }

        public IEnumerable<Photo> ParsePhoto(string Title, string path1, string path2, string path3)
        {
            var Photos = new List<Photo>();
            if (path1.Length>0)
            {
                Photos.Add(new Photo() { Path = path1, Comment = Title });
            }
            if (path2.Length > 0)
            {
                Photos.Add(new Photo() { Path = path2, Comment = Title });
            }
            if (path3.Length > 0)
            {
                Photos.Add(new Photo() { Path = path3, Comment = Title });
            }
            return Photos;
        }
    }
}