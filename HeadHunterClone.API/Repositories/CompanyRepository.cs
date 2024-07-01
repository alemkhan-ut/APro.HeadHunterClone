using HeadHunterClone.Domain.Models;
using HeadHunterClone.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HeadHunterClone.API.Repositories
{
    public class CompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Company> Get()
        {
            return _dbContext.Companies.ToList();
        }
    }
}
