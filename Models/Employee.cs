namespace agency.Models
{
    public class Employee: Client
    {
        public int expirience {  get; set; }
        public int age { get; set; }
        public String education { get; set; }
        public String reuestedPost {  get; set; }
        public int requestedSalary {  get; set; }

        public String aboutMe { get; set; }
        public const bool accessLevel1 = true;
    }
}
