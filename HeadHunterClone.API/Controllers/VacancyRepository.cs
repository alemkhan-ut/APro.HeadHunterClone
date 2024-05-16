using HeadHunterCloneAPI.Models;
using HeadHunterCloneAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunterCloneAPI.Controllers
{
    // localhost/vacancies

    [ApiController]
    [Route("Vacancies")]
    public class VacancyController : Controller
    {
        private readonly VacancyRepository _vacancyRepository = new VacancyRepository();
        public VacancyController(VacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }

        // Endpoints

        // localhost/vacancies
        [HttpGet]
        public IResult Get()
        {
            var vacancies = _vacancyRepository.Get();
            if (vacancies.Count > 0)
            {
                return Results.Ok(vacancies);
            }
            else
            {
                return Results.NotFound("Сейчас вакансий нет =( ");
            }
        }
        // localhost/vacancies/{id}
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
                return Results.NotFound("Вакансии по id не найдена");
            }
        }
        // localhost/vacancies/Create
        [HttpPost("Create")]
        public IResult Create([FromForm] Vacancy vacancy)
        {
            if (vacancy is not null)
            {
                _vacancyRepository.Add(vacancy);
                return Results.Ok(vacancy);
            }
            else
            {
                return Results.BadRequest("Вы отправили пустые данные");
            }
        }
    }
}
