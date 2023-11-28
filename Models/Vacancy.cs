namespace agency.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int salary { get; set; }
        public int requiredAge { get; set; }
        public int requiredExpirience { get; set; }
        public int CompanyId { get; set; }
    }
}
