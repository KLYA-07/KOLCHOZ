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
            logic = new Logic(new EntityRepository());

            ApplicationConfiguration.Initialize();
            Application.Run(new FarmForm(logic));
        }
    }
}