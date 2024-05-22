using HeadHunterClone.Domain.Models;
using Newtonsoft.Json;

namespace HeadHunterClone.Console.Vacancies
{
    internal class VacancyView
    {
        private readonly string _host = "localhost:7156/";
        private readonly string _getVacanciesApi = "api/vacancies";
        private readonly string _createVacancyApi = "api/vacancies/create";
        private readonly string _deleteVacancyApi = "api/vacancies/delete";
        private readonly string _updateVacancyApi = "api/vacancies/update";

        public async Task<List<Vacancy>> GetVacancies()
        {
            using (HttpClient client = new HttpClient())
            {
                var message = await client.GetAsync(_getVacanciesApi);

                if (message.IsSuccessStatusCode) // 2XX
                {
                    var responseBody = await message.Content.ReadAsStringAsync(); // получение json

                    var result = JsonConvert.DeserializeObject<List<Vacancy>>(responseBody); // десериализация в коллекцию вакансий
                }
                else
                {

                }
            }
        }
    }
}
