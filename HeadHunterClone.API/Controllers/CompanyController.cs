using HeadHunterClone.API.Repositories;
using HeadHunterClone.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunterClone.API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyController(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IResult Get()
        {
            var companies = _companyRepository.Get();

            if (companies is not null)
            {
                if (companies.Count > 0)
                {
                    return Results.Ok(companies);
                }
                else
                {
                    return Results.NotFound("Вакансии сейчас нет");
                }
            }
            else
            {
                return Results.NotFound("Вакансии сейчас нет");
            }
        }

        [HttpPost("create")]
        public IResult Create([FromForm] CreateCompanyDto company)
        {
            if (company is not null)
            {
                _companyRepository.Create(company);
                return Results.Ok("Вакансия добавлена");

            }
            else
            {
                return Results.BadRequest("Пришла пустая модель");
            }
        }
    }
}
