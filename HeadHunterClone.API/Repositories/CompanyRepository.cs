using HeadHunterClone.Domain.Models;
using HeadHunterClone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public void Create(CompanyDto companyDto)
        {

            var company = new Company()
            {              
                
                Name = companyDto.Name,
                Description = companyDto.Description,
                DateOfRegistration = companyDto.DateOfRegistration
                  
            };
            
           _dbContext.Companies.Add(company);
           _dbContext.SaveChanges();
        }

        public void Update(int id, Company newCompany)
        {
            var company = _dbContext.Companies.FirstOrDefault(y => y.Id == id);

            if (company != null)
            {

                
                company.Name = newCompany.Name;
                company.Description = newCompany.Description;
                company.DateOfRegistration = newCompany.DateOfRegistration;


                _dbContext.SaveChanges();



            }
            else
            {
                throw new Exception("Мы не нашли компанию по id" + id);
            }
        }

        public void Delete(int id)
        {
            var company = _dbContext.Companies.FirstOrDefault(x => x.Id == id);
            if (company != null)
            {
                _dbContext.Companies.Remove(company);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Не найдена компания по id " + id);
            }
        }

     

        public Company? Get(int id)
        {
            // Standart запрос 
            //foreach (var vacancy in _vacansies) 
            //{ //    if (vacancy.Id == id) //
            //{ 
            //        return vacancy; 
            //    } 
            //} 
            //return null;

            //Linq запрос
            return _dbContext.Companies.FirstOrDefault(v => v.Id == id);
        }

    }


}