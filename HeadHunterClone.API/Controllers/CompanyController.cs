using HeadHunterClone.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunterClone.API.Controllers
{
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
    }
}
