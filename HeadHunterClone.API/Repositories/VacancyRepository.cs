using HeadHunterClone.API.Interfaces;
using HeadHunterClone.Domain.Models;
using HeadHunterClone.Infrastructure.Data;

namespace HeadHunterClone.API.Repositories
{
    //Обязанность конторолировать данные вакансий - Создать, Редактировать, Удолять, Считывать
    public class VacancyRepository : IRepository
    {
        private readonly ApplicationDbContext dbContext;

        public VacancyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Vacancy vacancy)
        {
            dbContext.Vacancies.Add(vacancy);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var vacancy = dbContext.Vacancies.FirstOrDefault(x => x.Id == id);

            if (vacancy is not null)
            {
                dbContext.Vacancies.Remove(vacancy);
                dbContext.SaveChanges();
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
            //{
            //    if (vacancy.Id == id)
            //    {
            //        return vacancy;
            //    }
            //}

            //return null;

            // LINQ запрос
            return dbContext.Vacancies.FirstOrDefault(v => v.Id == id);
        }

        public void Update(int id, Vacancy newVacancy)
        {
            var vacancy = dbContext.Vacancies.FirstOrDefault(y => y.Id == id);

            if (vacancy is not null)
            {
                // Изменение а не создание обьекта

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
                throw new Exception("Мы не нашли вакансию по id " + id);
            }
        }
    }
}
