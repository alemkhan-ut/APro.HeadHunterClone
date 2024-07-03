using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunterClone.Domain.Models
{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
