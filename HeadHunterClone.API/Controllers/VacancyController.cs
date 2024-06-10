using HeadHunterClone.API.Repositories;
using HeadHunterClone.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunterClone.API.Controllers
{
    // CRUD - Create Read Update Delete

    // path - путь (site.com/api/vacancies/5)
    // 1 query - 1 запрос (site.com/api/vacancies?id=5)
    // N query - N запрос (site.com/api/vacancies?id=5&name="alemkhan"&age=26.5)
    // request body - тело запроса (site.com/api/vacancies) [{ id = 5, name = "alemkhan" }]
    // request form - форма запроса (site.com/api/vacancies) [{ id = 5, name = "alemkhan" }]

    [ApiController]
    [Route("api/vacancies")]
    public class VacancyController : Controller
    {
        private readonly VacancyRepository _vacancyRepository;

        public VacancyController(VacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        // localhost/api/vacancies/
        [HttpGet]
        public IResult Get()
        {
            var vacancies = _vacancyRepository.Get();

            if (vacancies is not null)
            {
                if (vacancies.Count > 0)
                {
                    return Results.Ok(vacancies);
                }
                else
                {
                    return Results.NotFound("Вакансии сейчас нет");
                }
            }
            else
            {
                return Results.NotFound("Вакансии не найдены");
            }
        }

        // localhost/api/vacancies/0
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
                return Results.NotFound("Мы не нашли вакансию по id =(( ");
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Employer")]
        public IResult Create([FromForm] CreateVacancyDto vacancy)
        {
            if (vacancy is not null)
            {
                _vacancyRepository.Create(vacancy);
                return Results.Ok("Вакансия добавлена");

            }
            else
            {
                return Results.BadRequest("Пришла пустая модель");
            }
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
