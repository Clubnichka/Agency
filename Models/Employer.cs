namespace agency.Models
{
    public class Employer:Client
    {
        public String companyName {  get; set; }
        public String Description { get; set; }
        public const bool accessLevel1=true;
    }
}
