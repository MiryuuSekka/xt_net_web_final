namespace Entity
{
    public class Common
    {
        public enum Role
        {
            Admin = 1,
            Seller = 2,
            Customer = 3,
            Guest = 4
        }
        public enum Status
        {
            New = 1,
            NotOpened = 2,
            SmallDefects = 3,
            MediumDefects = 4,
            BigDefects = 5
        }
    }
}
