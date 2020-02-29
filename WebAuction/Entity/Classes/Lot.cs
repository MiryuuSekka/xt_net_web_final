using System;

namespace Entity.Classes
{
    public class Lot
    {
        public int Id { get; set; }
        public User Seller { get; set; }
        public Product Product { get; set; }

        public decimal Price { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
