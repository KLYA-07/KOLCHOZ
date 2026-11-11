using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IFarmerFormatter
    {
        /// <summary>
        /// Форматирует данные фермеров в строки
        /// </summary>
        /// <param name="farmers"></param>
        /// <returns></returns>
        public List<string> GetFarmersStrings(List<Farmer> farmers);

        /// <summary>
        /// Извлекает ID фермеров 
        /// </summary>
        /// <param name="farmers"></param>
        /// <returns></returns>
        public List<int> GetFarmersIDs(List<Farmer> farmers);
    }
}
