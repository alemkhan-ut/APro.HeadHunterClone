using HeadHunterClone.Domain.Models;
using Newtonsoft.Json;
using SystemConsole = System.Console;

namespace HeadHunterClone.Console.Vacancies
{
    internal class VacancyView
    {
        private readonly string _getVacanciesApi = "https://localhost:7156/api/vacancies";
        private readonly string _createVacancyApi = "https://localhost:7156/api/vacancies/create";
        private readonly string _deleteVacancyApi = "https://localhost:7156/api/vacancies/delete";
        private readonly string _updateVacancyApi = "https://localhost:7156/api/vacancies/update";

        public async Task ShowVacanciesAsync()
        {
            var vacancies = await GetVacanciesAsync();

            foreach (var vacancy in vacancies)
            {
                SystemConsole.WriteLine(vacancy.Id + " : " + vacancy.Title); // 1 : Title1
            }

            SystemConsole.Write("Выберите ID вакансии: ");
            var input = Convert.ToInt32(SystemConsole.ReadLine());

            var findVacancy = vacancies.FirstOrDefault(x => x.Id == input);

            ShowVacancy(findVacancy);
        }

        public async Task ShowVacancy(Vacancy vacancy)
        {
            if (vacancy is null)
            {
                SystemConsole.WriteLine("Вакансия не найдена");

                return;
            }

            SystemConsole.Clear();

            SystemConsole.WriteLine("Название: " + vacancy.Title);
            SystemConsole.WriteLine("Зарплата от " + vacancy.SalaryFrom + " до " + vacancy.SalaryTo + " " + vacancy.SalaryCurrency);
            SystemConsole.WriteLine("Опыт работы: " + vacancy.ExperienceLevel);
            SystemConsole.WriteLine("Описание: " + vacancy.Description);
        }

        public async Task<List<Vacancy>> GetVacanciesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var message = await client.GetAsync(_getVacanciesApi);

                if (message.IsSuccessStatusCode) // 2XX
                {
                    var responseBody = await message.Content.ReadAsStringAsync(); // получение json

                    var result = JsonConvert.DeserializeObject<List<Vacancy>>(responseBody); // десериализация в коллекцию вакансий

                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
