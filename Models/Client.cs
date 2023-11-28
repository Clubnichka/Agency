namespace agency.Models
{
    public class Client: User
    {
        public  const bool accessLevel1 = false;
        public int accessTime {  get; set; }
    }
}
