namespace HeadHunterClone.Console.Vacancy
{
    internal class VacancyView
    {
        private readonly string _host = "localhost:7156/";
        private readonly string _getVacanciesApi = "api/vacancies";
        private readonly string _createVacancyApi = "api/vacancies/create";
        private readonly string _deleteVacancyApi = "api/vacancies/delete";
        private readonly string _updateVacancyApi = "api/vacancies/update";


        public async Task StartView()
        {
            using (HttpClient client = new HttpClient())
            {

            }
        }
    }
}
