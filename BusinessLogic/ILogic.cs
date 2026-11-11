using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {
        /// <summary>
        /// Список строк фермеров
        /// </summary>
        public List<string> AllFarmers { get; }

        /// <summary>
        /// Список ID всех фермеров
        /// </summary>
        public List<int> AllFarmersIDs { get; }
        /// <summary>
        /// Метод, добавляющий фермера в список фермеров
        /// </summary>
        /// <param name="farmer"></param>
        public void AddFarmer(Farmer farmer);

        /// <summary>
        /// Метод, удаляющий фермера из списка по заданному индексу
        /// </summary>
        /// <param name="farmerIndex">Индекс фермера в списке</param>
        public void RemoveFarmer(int farmerIndex);

        /// <summary>
        /// Метод, предоставляющий доступ для чтения фермера
        /// </summary>
        /// <param name="farmerIndex">Индекс выбранного фермера в списке</param>
        /// <returns></returns>
        public Farmer ReadFarmer(int farmerIndex);

        /// <summary>
        /// Метод, меняющий фермера в списке путем замены
        /// </summary>
        /// <param name="farmer">Экземпляр фермера, на которого нужно заменить</param>
        public void ChangeFarmer(Farmer farmer);

        /// <summary>
        /// Метод, осуществляющий продажу земли между фермерами
        /// </summary>
        /// <param name="payerFarmerIndex">Индекс фермера-покупателя в списке</param>
        /// <param name="sellerFarmerIndex">Индекс фермера-продавца в списке</param>
        /// <param name="fieldArea">Площадь покупаемой земли</param>
        /// <returns></returns>
        public int ExchangeField(int payerFarmerIndex, int sellerFarmerIndex, float fieldArea);

        /// <summary>
        /// Метод, осуществляющий сортировку списка фермеров по финансовому капиталу
        /// </summary>
        public List<int> FarmTypeGroup(string farmType);
    }
}
