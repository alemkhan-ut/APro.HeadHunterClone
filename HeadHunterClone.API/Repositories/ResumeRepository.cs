using HeadHunterClone.Domain.Models;
using HeadHunterClone.Infrastructure.Data;

namespace HeadHunterClone.API.Repositories
{
    public class ResumeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ResumeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Resume> Get()
        {
            return _dbContext.Resumes.ToList();
        }

        public void Create(ResumeDto resumeDto)
        {

            var resume = new Resume()
            {

                JobTitle = resumeDto.JobTitle, 
                Specilization = resumeDto.Specilization,
                Salary = resumeDto.Salary,
                WorkLoad = resumeDto.WorkLoad,
                WorkSchedule = resumeDto.WorkSchedule,

            };

            _dbContext.Resumes.Add(resume);
            _dbContext.SaveChanges();
        }

        public void Update(int id, Resume newResume)
        {
            var resume = _dbContext.Resumes.FirstOrDefault(y => y.Id == id);

            if (resume != null)
            {


                resume.JobTitle = newResume.JobTitle;
                resume.Specilization = newResume.Specilization;
                resume.Salary = newResume.Salary; 
                resume.WorkLoad = newResume.WorkLoad;
                resume.WorkSchedule = newResume.WorkSchedule;



                _dbContext.SaveChanges();



            }
            else
            {
                throw new Exception("Мы не нашли резюме по id" + id);
            }
        }

        public void Delete(int id)
        {
            var resume = _dbContext.Resumes.FirstOrDefault(x => x.Id == id);
            if (resume != null)
            {
                _dbContext.Resumes.Remove(resume);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Не найден резюме по id " + id);
            }
        }



        public Resume? Get(int id)
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
            return _dbContext.Resumes.FirstOrDefault(v => v.Id == id);
        }

    }
}
