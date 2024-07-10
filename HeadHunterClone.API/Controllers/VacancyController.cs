using HeadHunterClone.API.Repositories;
using HeadHunterClone.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace HeadHunterClone.API.Controllers


{
    [ApiController]
    [Route("api/vacancies")]
    public class VacancyController : Controller
    {
        private readonly VacancyRepository _vacancyRepository;
        public VacancyController(VacancyRepository vacancyRepository) 
        { 
            _vacancyRepository = vacancyRepository;
        }

        [HttpGet]
        public IResult Get()
        {
            var vacancies = _vacancyRepository.Get();
            if (vacancies is not null)
            {
                if (vacancies.Count() > 0)
                {
                    return Results.Ok(vacancies);
                }
                else
                {
                    return Results.NotFound("Вакансий сейчас нет");
                }

            }
            else
            {
                return Results.NotFound("Вакансии не найдены");
            }
        }
        [HttpGet("{id}")]
        public IResult GetById(int id)
        {
            var vacancy = _vacancyRepository.Get(id);
            if (vacancy is not null)
            {
                return Results.Ok(vacancy);
            }
            else
            {
                return Results.NotFound("Мы не нашли вакансию по Id ;=((");  
            }
        }


        [HttpPost("Create")]
        [Authorize(Roles = "Employer")]
        public IResult Create([FromForm] VacancyDto vacancy)
        {
                if (vacancy is not null)
                {
                    _vacancyRepository.Create(vacancy);

                    return Results.Ok("Вакансия добавлена");
                }
                else 
                 {
                     return Results.BadRequest("Пришла пустая модель");
                 };
            
        }
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Employer")]
        public IResult Delete(int id)
        {

            try
            {
                _vacancyRepository.Delete(id);
                return Results.Ok("Успешно удален");
            }
            catch (Exception exception)
            {

                return Results.NotFound(exception.Message);
            }

        }
        [HttpPut("update/{id}")]
        [Authorize(Roles = "Employer")]
        public IResult Update(int id, [FromBody] Vacancy vacancy)
        {
            try
            {
                _vacancyRepository.Update(id, vacancy);
                return Results.Ok("Успешно обновлен");
            }
            catch (Exception exception)
            {

                return Results.NotFound(exception.Message);  
            }
        }
    }
}
