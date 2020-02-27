using System;

namespace Entity
{
    public class Bet
    {
        public int Id { get; set; }
        public User Customer { get; set; }
        public Lot Lot { get; set; }

        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
