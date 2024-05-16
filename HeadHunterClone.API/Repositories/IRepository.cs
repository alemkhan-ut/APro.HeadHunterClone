namespace HeadHunterCloneAPI.Models.Repositories
{
    public interface IRepository
    {
        public Vacancy Add(Vacancy vacancy);
        // Возвращает список объектов
        public List<Vacancy> Get();
        // Возвращает один объкет по его id
        public Vacancy Get(int id);
        // Обновляет объект новыми данными по id
        public Vacancy Update(int id, Vacancy vacancy);
        // Удаляет объект по id
        public void Delete(int id);
    }
}
