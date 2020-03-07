using System.Collections.Generic;

namespace Entity.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public List<Photo> Photos { get; set; }
        public Enums.Status Status { get; set; }
    }
}
