using HeadHunterClone.Domain.Models;

namespace HeadHunterClone.API.Interfaces
{
    public interface IRepository
    {
        public void Create(CreateVacancyDto vacancy);
        public void Update(int id, Vacancy vacancy);
        public void Delete(int id);
        public List<Vacancy> Get();
        public Vacancy? Get(int id);
    }
}
