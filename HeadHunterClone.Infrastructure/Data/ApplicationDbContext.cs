using HeadHunterClone.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterClone.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Создание таблицы Вакансий
        public DbSet<Vacancy> Vacancies => Set<Vacancy>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        {
            // Гарантия создания БД
            Database.EnsureCreated();
        }

        // Нужно добавить base(options)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vacancy>().HasData(
            new Vacancy()
            {
                Id = 1,
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
            });
        }
    }
}
