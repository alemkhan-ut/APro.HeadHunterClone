using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunterClone.Domain.Models
{
    public class ResumeDto
    {
        
        public string JobTitle { get; set; }
        public string Specilization { get; set; }
        public string Salary { get; set; }
        public string WorkLoad { get; set; }
        public string WorkSchedule { get; set; }


    }
}
