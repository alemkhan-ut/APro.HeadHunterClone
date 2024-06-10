using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunterClone.Domain.Models
{
    public class CreateVacancyDto
    {
        public string Title { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public string SalaryCurrency { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string WorkTerms { get; set; }
        public string Skills { get; set; }
    }
}
