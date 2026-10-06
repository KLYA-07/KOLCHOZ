using Model;
using BusinessLogic;

namespace WinFormsPresentation
{
    internal static class Program
    {
        private static Logic logic;

        /// <summary>
        /// Метод, инициализирующий логику и запускающий основную форму
        /// </summary>
        [STAThread]
        static void Main()
        {
            logic = new Logic();

            logic.AddFarmer(new Farmer("Олег", 39600, 98.7f,
                new Dictionary<string, int>()
                {
                    { "Тыквы", 10 },
                    { "Морковь", 96 },
                    { "Баклажаны", 15 }
                }, new List<int>()
                {
                    { 235 },
                    { 45 },
                    { 115 },
                }, new List<string>()
                {
                    { "Курица" }
                }, new List<string>()
                {
                    { "Тыква" },
                    { "Баклажан" },
                    { "Помидоры" },
                    { "Перцы" },
                    { "Клубника" },
                }));
            logic.AddFarmer(new Farmer("Виктор", 55000, 37.5f,
                new Dictionary<string, int>()
                {
                    { "Кукуруза", 30 },
                    { "Свекла", 25 },
                    { "Картофель", 200 },
                    { "Курица", 7 }
                }, new List<int>()
                {
                    { 100 },
                    { 75 },
                    { 20 },
                    { 250 }
                }, new List<string>()
                {
                    { "Свинья" },
                    { "Курица" }
                }, new List<string>()
                {
                    { "Кукуруза" },
                    { "Свекла" },
                    { "Подсолнух" }
                }));

            ApplicationConfiguration.Initialize();
            Application.Run(new FarmForm(logic));
        }
    }
}