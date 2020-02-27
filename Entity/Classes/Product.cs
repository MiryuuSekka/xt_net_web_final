using System.Collections.Generic;

namespace Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public List<Photo> Photos { get; set; }
        public Common.Status Status { get; set; }
    }
}
