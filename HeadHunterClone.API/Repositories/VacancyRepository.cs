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
            throw new NotImplementedException();
        }

        public List<Vacancy> Get()
        {
            return _vacancies;
        }

        public Vacancy? Get(int id)
        {
            return _vacancies.FirstOrDefault(vacancy => vacancy.Id == id);
        }

        public Vacancy Update(int id, Vacancy vacancy)
        {
            throw new NotImplementedException();
        }
    }
}
