namespace HeadHunterCloneAPI.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public string SalaryCurrency { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }

        public string LanguageKnowledges { get; set; }
        public string WorkTerms { get; set; }
        public string KeySkills { get; set; }

    }
}
