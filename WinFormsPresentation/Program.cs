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
        private static IModel logic = ninjectKernel.Get<IModel>();

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