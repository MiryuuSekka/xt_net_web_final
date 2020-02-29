using Entity;
using Entity.Classes;
using SQLBase.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLBase
{
    public class SqlDal : InterfaceDAL.IDAL
    {

        List<User> Users;
        List<Photo> AllPhotos;
        List<Product> Products;
        List<Lot> Lots;
        List<Bet> Bets;

        public SqlDal()
        {
            Users = new List<User>();
            AllPhotos = new List<Photo>();
            Products = new List<Product>();
            Lots = new List<Lot>();
            Bets = new List<Bet>();

            #region for test
            Users.Add(new User() { Id = 0, Name = "A1", Password = "111", Role = Common.Role.Guest });
            Users.Add(new User() { Id = 1, Name = "B1", Password = "111", Role = Common.Role.Seller });
            Users.Add(new User() { Id = 2, Name = "C1", Password = "111", Role = Common.Role.Customer });
            Users.Add(new User() { Id = 3, Name = "D1", Password = "111", Role = Common.Role.Admin });
            Users.Add(new User() { Id = 4, Name = "B2", Password = "111", Role = Common.Role.Seller });
            Users.Add(new User() { Id = 5, Name = "B3", Password = "111", Role = Common.Role.Seller });

            AllPhotos.Add(new Photo() { Id = 0, Comment = "Mordred", Path = "https://pbs.twimg.com/media/ER1ZHXaUwAA1P0p?format=jpg&name=small" });
            AllPhotos.Add(new Photo() { Id = 1, Comment = "Moai", Path = "https://pbs.twimg.com/media/ER1Zv7MUUAEeahd?format=jpg&name=small" });
            AllPhotos.Add(new Photo() { Id = 2, Comment = "riamu", Path = "https://pbs.twimg.com/media/ERSTSpGVAAMWpnO?format=jpg&name=360x360" });
            AllPhotos.Add(new Photo() { Id = 3, Comment = "hatsuneMiku", Path = "https://pbs.twimg.com/media/ER1ZecFUUAAZ1WC?format=jpg&name=small" });
            AllPhotos.Add(new Photo() { Id = 4, Comment = "spiderman", Path = "https://pbs.twimg.com/media/EReHmuqUUAA5o8-?format=jpg&name=small" });
            AllPhotos.Add(new Photo() { Id = 5, Comment = "germanTank", Path = "https://pbs.twimg.com/media/ERSWsvhUEAYRcBB?format=jpg&name=small" });
            AllPhotos.Add(new Photo() { Id = 6, Comment = "auto volvo 1", Path = "https://img.amiami.jp/images/product/main/201/TOY-SCL3-14923.jpg" });
            AllPhotos.Add(new Photo() { Id = 7, Comment = "auto volvo 2", Path = "https://img.amiami.jp/images/product/review/201/TOY-SCL3-14923_05.jpg" });
            AllPhotos.Add(new Photo() { Id = 8, Comment = "angel", Path = "https://img.amiami.jp/images/product/main/191/FIGURE-047693.jpg" });


            Products.Add(new Product() { Id = 0, Company = "Bandai", Status = Common.Status.MediumDefects, Title = "Mordred", Photos = new List<Photo>() { AllPhotos[0] } });
            Products.Add(new Product() { Id = 1, Company = "Conami", Status = Common.Status.New, Title = "Moai", Photos = new List<Photo>() { AllPhotos[1] } });
            Products.Add(new Product() { Id = 2, Company = "Conami", Status = Common.Status.MediumDefects, Title = "riamu", Photos = new List<Photo>() { AllPhotos[2] } });
            Products.Add(new Product() { Id = 3, Company = "Philips", Status = Common.Status.SmallDefects, Title = "hatsuneMiku", Photos = new List<Photo>() { AllPhotos[3] } });
            Products.Add(new Product() { Id = 4, Company = "Good smile company", Status = Common.Status.New, Title = "spiderman", Photos = new List<Photo>() { AllPhotos[4] } });
            Products.Add(new Product() { Id = 5, Company = "Figma", Status = Common.Status.SmallDefects, Title = "germanTank", Photos = new List<Photo>() { AllPhotos[5] } });
            Products.Add(new Product() { Id = 6, Company = "Philips", Status = Common.Status.New, Title = "auto volvo", Photos = new List<Photo>() { AllPhotos[6], AllPhotos[7] } });
            Products.Add(new Product() { Id = 7, Company = "Philips", Status = Common.Status.SmallDefects, Title = "angel", Photos = new List<Photo>() { AllPhotos[8] } });


            Lots.Add(new Lot() { Id = 0, Price = 50, DateStart = DateTime.Parse("02.02.2020"), DateEnd = DateTime.Parse("05.05.2020"), Product = Products[0], Seller = Users[1] });
            Lots.Add(new Lot() { Id = 1, Price = 1000, DateStart = DateTime.Parse("03.02.2020"), DateEnd = DateTime.Parse("05.02.2020"), Product = Products[1], Seller = Users[1] });
            Lots.Add(new Lot() { Id = 2, Price = 800, DateStart = DateTime.Parse("01.02.2020"), DateEnd = DateTime.Parse("06.06.2020"), Product = Products[2], Seller = Users[5] });
            Lots.Add(new Lot() { Id = 3, Price = 5, DateStart = DateTime.Parse("10.02.2020"), DateEnd = DateTime.Parse("01.03.2020"), Product = Products[3], Seller = Users[4] });
            Lots.Add(new Lot() { Id = 4, Price = 70, DateStart = DateTime.Parse("28.02.2020"), DateEnd = DateTime.Parse("29.02.2020"), Product = Products[4], Seller = Users[1] });
            Lots.Add(new Lot() { Id = 5, Price = 5000, DateStart = DateTime.Parse("29.02.2020"), DateEnd = DateTime.Parse("01.03.2020"), Product = Products[5], Seller = Users[1] });
            Lots.Add(new Lot() { Id = 6, Price = 820, DateStart = DateTime.Parse("01.06.2020"), DateEnd = DateTime.Parse("06.06.2020"), Product = Products[6], Seller = Users[5] });
            Lots.Add(new Lot() { Id = 7, Price = 66, DateStart = DateTime.Parse("10.05.2020"), DateEnd = DateTime.Parse("01.06.2020"), Product = Products[7], Seller = Users[4] });
            #endregion
        }

        #region add
        public int AddBet(Bet NewData)
        {
            throw new NotImplementedException();
        }

        public int AddLot(Lot NewData)
        {
            throw new NotImplementedException();
        }

        public int AddProduct(Product NewData)
        {
            throw new NotImplementedException();
        }

        public int AddUser(User NewData)
        {
            var DB = new SqlUser();
            DB.AddData(NewData);
            return DB.GetAll().LastOrDefault().Id;
        }
        #endregion


        #region change
        public void ChangeBet(Bet NewData)
        {
            throw new NotImplementedException();
        }

        public void ChangeLot(Lot NewData)
        {
            throw new NotImplementedException();
        }

        public void ChangeProduct(Product NewData)
        {
            throw new NotImplementedException();
        }

        public void ChangeUser(User NewData)
        {
            var DB = new SqlUser();
            DB.Edit(NewData);
        }
        #endregion

        #region delete
        public void DeleteBet(int Id)
        {
            var bet = GetBetById(Id);
            if (bet != null)
            {
                Bets.Remove(bet);
            }
        }

        public void DeleteLot(int Id)
        {
            var lot = GetLotById(Id);
            if (lot != null)
            {
                Lots.Remove(lot);
            }
        }

        public void DeleteProduct(int Id)
        {
            var product = GetProductById(Id);
            if (product != null)
            {
                Products.Remove(product);
            }
        }

        public void DeleteUser(int Id)
        {
            var user = GetUserById(Id);
            if (user != null)
            {
                Users.Remove(user);
            }
        }
        #endregion

        #region get
        public Bet GetBetById(int Id)
        {
            return Bets.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Bet> GetBets()
        {
            return Bets;
        }

        public Lot GetLotById(int Id)
        {
            return Lots.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Lot> GetLotByTag(string Tag)
        {
            return Lots;
        }

        public IEnumerable<Lot> GetLots()
        {
            return Lots;
        }

        public Product GetProductById(int Id)
        {
            var DB = new SqlProduct();
            return DB.GetAll().Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            var DB = new SqlProduct();
            return DB.GetAll();
        }

        public User GetUserById(int Id)
        {
            var DB = new SqlUser();
            return DB.GetAll().Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            var DB = new SqlUser();
            return DB.GetAll();
        }
        #endregion
    }
}
