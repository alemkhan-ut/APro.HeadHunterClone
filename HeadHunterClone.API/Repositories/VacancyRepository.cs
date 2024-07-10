using HeadHunterClone.API.Interfaces;
using HeadHunterClone.Domain.Models;
using HeadHunterClone.Infrastructure.Data;

namespace HeadHunterClone.API.Repositories
{

    //Обязанность контролировать данные вакансий - Создавать, Редактировать, Удалять, Считывать
    public class VacancyRepository : IRepository
    {
        private readonly ApplicationDbContext dbContext;

        
        public VacancyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(VacancyDto vacancyDto)
        {

            var vacancy = new Vacancy()
            {
                Title = vacancyDto.Title,
                Description = vacancyDto.Description,
                SalaryCurrency = vacancyDto.SalaryCurrency,
                SalaryFrom = vacancyDto.SalaryFrom,
                SalaryTo = vacancyDto.SalaryTo,
                Skills = vacancyDto.Skills,
                ExperienceLevel = vacancyDto.ExperienceLevel,
                Requirements = vacancyDto.Requirements,
                WorkTerms = vacancyDto.WorkTerms,
        };
            dbContext.Vacancies.Add(vacancy);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
           var vacancy = dbContext.Vacancies.FirstOrDefault(x=> x.Id == id);
            if (vacancy != null)
            {
                dbContext.Vacancies.Remove(vacancy);
                dbContext.SaveChanges() ;
            }
            else
            {
                throw new Exception("Не найдена вакансия по id " + id);
            }
        }

        public List<Vacancy> Get()
        {
            return dbContext.Vacancies.ToList();
        }

        public Vacancy? Get(int id)
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
            return dbContext.Vacancies.FirstOrDefault(v => v.Id == id);
        }

        public void Update(int id, Vacancy newVacancy)
        {
            var vacancy = dbContext.Vacancies.FirstOrDefault( y => y.Id == id);

            if (vacancy != null)
            {

                vacancy.Id = newVacancy.Id;
                vacancy.Title = newVacancy.Title;
                vacancy.Description = newVacancy.Description;
                vacancy.SalaryCurrency = newVacancy.SalaryCurrency;
                vacancy.SalaryFrom = newVacancy.SalaryFrom;
                vacancy.SalaryTo = newVacancy.SalaryTo;
                vacancy.Skills = newVacancy.Skills;
                vacancy.ExperienceLevel = newVacancy.ExperienceLevel;
                vacancy.Requirements = newVacancy.Requirements;
                vacancy.WorkTerms = newVacancy.WorkTerms;


                dbContext.SaveChanges();   

                
                 
            }
            else 
            { 
                throw new Exception("Мы не нашли вакансию по id" + id); 
            }
        }

        
    }
}
