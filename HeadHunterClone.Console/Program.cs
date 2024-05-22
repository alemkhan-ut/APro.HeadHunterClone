using HeadHunterClone.Console.Vacancies;
using SystemConsole = System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        VacancyView vacancyView = new VacancyView();

        try
        {
            LoadData(vacancyView);
        }
        catch (Exception)
        {
            SystemConsole.Clear();

            SystemConsole.WriteLine("Не удалось подключиться к серверу");
            SystemConsole.WriteLine("Для повтороного подключения нажмите клавишу");
            SystemConsole.ReadKey();

            // TODO: Закончить повторное подключение
        }

        static void LoadData(VacancyView vacancyView)
        {
            while (true)
            {
                SystemConsole.WriteLine("Загрузка...");

                SystemConsole.Clear();

                vacancyView.ShowVacanciesAsync().Wait();

                SystemConsole.WriteLine("Нажмите любую клавишу для загрузки");
                SystemConsole.ReadKey();
            }
        }
    }
}