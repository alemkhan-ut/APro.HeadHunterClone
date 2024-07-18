using Microsoft.AspNetCore.Http;

namespace HeadHunterClone.Domain.Models
{
    // DTO - Data Transfer Object
    public class ResumeDto
    {
        public string JobTitle { get; set; }
        public string Specilization { get; set; }
        public string Salary { get; set; }
        public string WorkLoad { get; set; }
        public string WorkSchedule { get; set; }
        public IFormFile ResumeFile { get; set; }
    }
}
