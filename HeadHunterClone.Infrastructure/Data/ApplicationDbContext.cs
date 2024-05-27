using HeadHunterClone.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterClone.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Создание таблицы Вакансий
        public DbSet<Vacancy> Vacancies => Set<Vacancy>();

        public ApplicationDbContext()
        {
            // Гарантия создания БД
            Database.EnsureCreated();
        }
    }
}
