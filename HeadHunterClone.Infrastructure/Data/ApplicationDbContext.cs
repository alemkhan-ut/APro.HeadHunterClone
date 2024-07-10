using HeadHunterClone.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; // ORM - Object Releation manage

namespace HeadHunterClone.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Создание Таблицы Vacancy
        public DbSet<Vacancy> Vacancies => Set<Vacancy>(); 

        public DbSet<Company> Companies => Set<Company>();

        public DbSet<Resume> Resumes => Set<Resume>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            //Гарантия создание ДБА
                Database.EnsureCreated();
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
                ExperienceLevel = ExperienceLevel.FourSix,
                Description = "This is Description 1",
                Requirements = " Require 1,  Require 2, Require 3",
                
                WorkTerms = " Term 1, Term 2",
               
                Skills = 
                    "Skill 1"
                

            });
        }
    }
}
