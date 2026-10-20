using BusinessLogic;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Model;
using Ninject;

namespace WinFormsPresentation
{
    internal static class Program
    {
        private static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        private static Logic logic = ninjectKernel.Get<Logic>();

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

            ApplicationConfiguration.Initialize();
            Application.Run(new FarmForm(logic));
        }
    }
}