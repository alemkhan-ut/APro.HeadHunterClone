namespace HeadHunterCloneAPI.Models.Repositories
{
    public class VacancyRepository : IRepository
    {
        private readonly List<Vacancy> _vacancies = new List<Vacancy>();

        public Vacancy Add(Vacancy vacancy)
        {
            _vacancies.Add(vacancy);
            return vacancy;
        }

        public void Delete(int id)
        {
            // Логика FirstOrDefault
            //foreach (var v in _vacancies)
            //{
            //    if (v.Id == id)
            //    {
            //        return v;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}

            var vacancy = _vacancies.FirstOrDefault(v => v.Id == id);

            if (vacancy is not null)
            {
                _vacancies.Remove(vacancy);
            }
            else
            {
                throw new NullReferenceException("Вакансия по ID не была найдена");
            }
        }

        public List<Vacancy> Get()
        {
            return _vacancies;
        }

        public Vacancy? Get(int id)
        {
            return _vacancies.FirstOrDefault(vacancy => vacancy.Id == id);
        }

        public Vacancy Update(int id, Vacancy newVacancy)
        {
            var vacancy = _vacancies.FirstOrDefault(v => v.Id == id);

            if (vacancy is not null)
            {
                vacancy.Title = newVacancy.Title;
                vacancy.SalaryFrom = newVacancy.SalaryFrom;
                vacancy.SalaryTo = newVacancy.SalaryTo;
                vacancy.SalaryCurrency = newVacancy.SalaryCurrency;
                vacancy.CompanyLocation = newVacancy.CompanyLocation;
                vacancy.CompanyName = newVacancy.CompanyName;   
                vacancy.LanguageKnowledges = newVacancy.LanguageKnowledges;
                vacancy.Requirements = newVacancy.Requirements;
                vacancy.Responsibilities = newVacancy.Responsibilities;
                vacancy.WorkTerms = newVacancy.WorkTerms;
                vacancy.KeySkills = newVacancy.KeySkills;

                return vacancy;
            }
            else
            {
                throw new NullReferenceException("Вакансия по id не была найдена");
            }
        }
    }
}
