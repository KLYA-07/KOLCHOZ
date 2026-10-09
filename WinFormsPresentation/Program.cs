using Model;
using BusinessLogic;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace WinFormsPresentation
{
    internal static class Program
    {
        private static Logic logic;

        public static float FieldUnitCost
        {
            get
            {
                return Logic.fieldUnitCost;
            }
        }

        /// <summary>
        /// Метод, инициализирующий логику и запускающий основную форму
        /// </summary>
        [STAThread]
        static void Main()
        {
            logic = new Logic();

            logic.AddFarmer(new Farmer()
            {
                farmerName = "Фёдор",
                farmerSurname = "Аркадьев",
                phoneNumber = "+74893047392",
                fieldArea = 15,
                finacialCapital = 105990,
                farmAddress = "с. Огородное, 26",
                farmType = "Растениеводство",
                registrationDate = new DateTime(2023, 10, 25)
            });

            logic.AddFarmer(new Farmer()
            {
                farmerName = "Михаил",
                farmerSurname = "Семенов",
                phoneNumber = "+79152345678",
                fieldArea = 42,
                finacialCapital = 350000,
                farmAddress = "д. Простоквашино, 12",
                farmType = "Скотоводство",
                registrationDate = new DateTime(2021, 5, 14)
            });

            logic.AddFarmer(new Farmer()
            {
                farmerName = "Елена",
                farmerSurname = "Кузнецова",
                phoneNumber = "+79037654321",
                fieldArea = 8,
                finacialCapital = 75000,
                farmAddress = "пос. Зеленый Дол, 5",
                farmType = "Пчеловодство",
                registrationDate = new DateTime(2024, 8, 01)
            });

            ApplicationConfiguration.Initialize();
            Application.Run(new FarmForm(logic));
        }
    }
}