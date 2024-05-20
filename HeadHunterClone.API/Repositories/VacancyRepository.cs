using HeadHunterClone.API.Interfaces;
using HeadHunterClone.Domain.Models;

namespace HeadHunterClone.API.Repositories
{
    //Обязанность конторолировать данные вакансий - Создать, Редактировать, Удолять, Считывать
    public class VacancyRepository : IRepository
    {
        private List<Vacancy> _vacansies = new List<Vacancy>()
        {
            new Vacancy()
            {
                Title = "Title 1",
                SalaryFrom = 1000,
                SalaryTo = 3000,
                SalaryCurrency = "USD",
                Description = "This is Description 1",
                Requirements = new List<string>()
                {
                    "Require 1",
                    "Require 2",
                    "Require 3"
                },
                WorkTerms = new List<string>()
                {
                    "Term 1",
                    "Term 2",
                },
                Skills = new List<string>()
                {
                    "Skill 1"
                }
            }
        };

        public void Create(Vacancy vacancy)
        {
            _vacansies.Add(vacancy);
        }

        public void Delete(int id)
        {
            var vacancy = _vacansies.FirstOrDefault(x => x.Id == id);

            if (vacancy is not null)
            {
                _vacansies.Remove(vacancy);
            }
            else
            {
                throw new Exception("Не найдена вакансия по id " + id);
            }
        }

        public List<Vacancy> Get()
        {
            return _vacansies;
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
            return _vacansies.FirstOrDefault(v => v.Id == id);
        }

        public void Update(int id, Vacancy newVacancy)
        {
            var vacancy = _vacansies.FirstOrDefault(y => y.Id == id);

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
            }
            else
            {
                throw new Exception("Мы не нашли вакансию по id " + id);
            }
        }
    }
}
