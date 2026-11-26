using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IBusinessService
    {
        /// <summary>
        /// Метод, осуществляющий продажу земли между фермерами
        /// </summary>
        /// <param name="payerFarmerIndex">Индекс фермера-покупателя в списке</param>
        /// <param name="sellerFarmerIndex">Индекс фермера-продавца в списке</param>
        /// <param name="fieldArea">Площадь покупаемой земли</param>
        /// <returns></returns>
        public int DoFieldExchange(Farmer payer, Farmer seller, float fieldArea);

        /// <summary>
        /// Метод, осуществляющий сортировку списка фермеров по финансовому капиталу
        /// </summary>
        public List<Farmer> GetFarmTypeGroup(List<Farmer> farmers, string farmType);
    }
}
