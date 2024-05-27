namespace HeadHunterClone.Domain.Models
{
    public class Vacancy
    {
        // Primary Key [PK]
        public int Id { get; set; }
        public string Title { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public string SalaryCurrency { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public string Description { get; set; }
        public List<string> Requirements { get; set; }
        public List<string> WorkTerms { get; set; }
        public List<string> Skills { get; set; }
    }

    public enum ExperienceLevel
    {
        None,
        OneThree,
        FourSix,
        OverSix
    }
}
