using HeadHunterClone.API.Repositories;
using HeadHunterClone.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;




namespace HeadHunterClone.API.Controllers
{
    [ApiController]
    [Route("api/resumes")]

    public class ResumeController : Controller
    {

        private readonly ResumeRepository _resumeRepository;

        public ResumeController(ResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }


        [HttpGet]

        public IResult Get()
        {
            var resumes = _resumeRepository.Get();

            if (resumes is not null)
            {
                if (resumes.Count > 0)
                {
                    return Results.Ok(resumes);
                }
                else
                {
                    return Results.NotFound("резюме сейчас нет");
                }
            }
            else
            {
                return Results.NotFound("резюме не найдена");
            }
        }
        [HttpPost("Create")]

        public IResult Create([FromForm] ResumeDto resume)
        {
            if (resume is not null)
            {
                _resumeRepository.Create(resume);

                return Results.Ok("резюме добавлена");
            }
            else
            {
                return Results.BadRequest("Пришла пустая модель");
            };


        }

        [HttpPut("update/{id}")]

        public IResult Update(int id, [FromBody] Resume resume)
        {
            try
            {
                _resumeRepository.Update(id, resume);
                return Results.Ok("Успешно обновлен");
            }
            catch (Exception exception)
            {

                return Results.NotFound(exception.Message);
            }
        }

        [HttpDelete("delete/{id}")]

        public IResult Delete(int id)
        {

            try
            {
                _resumeRepository.Delete(id);
                return Results.Ok("Успешно удален");
            }
            catch (Exception exception)
            {

                return Results.NotFound(exception.Message);
            }

        }

        [HttpGet("{id}")]
        public IResult GetById(int id)
        {
            var vacancy = _resumeRepository.Get(id);
            if (vacancy is not null)
            {
                return Results.Ok(vacancy);
            }
            else
            {
                return Results.NotFound("Мы не нашли компанию по Id ;=((");
            }
        }
    }
}