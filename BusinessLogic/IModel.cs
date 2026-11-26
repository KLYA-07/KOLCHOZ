using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IModel<T> where T : class
    {
        public event EventHandler DataChanged;
        /// <summary>
        /// Метод, добавляющий фермера в список фермеров
        /// </summary>
        /// <param name="farmer"></param>
        public void AddFarmer(Farmer farmer);

        /// <summary>
        /// Метод, удаляющий фермера из списка по заданному индексу
        /// </summary>
        /// <param name="farmerID">ID фермера</param>
        public void RemoveFarmer(int farmerID);

        /// <summary>
        /// Метод, предоставляющий доступ для чтения фермера
        /// </summary>
        /// <param name="farmerID">ID выбранного фермера</param>
        /// <returns></returns>
        public Farmer ReadFarmer(int farmerID);

        /// <summary>
        /// Метод, меняющий фермера в списке путем замены
        /// </summary>
        /// <param name="farmer">Экземпляр фермера, на которого нужно заменить</param>
        public void ChangeFarmer(Farmer farmer);

        /// <summary>
        /// Метод, осуществляющий продажу земли между фермерами
        /// </summary>
        /// <param name="payerFarmerID">ID фермера-покупателя</param>
        /// <param name="sellerFarmerID">ID фермера-продавца</param>
        /// <param name="fieldArea">Площадь покупаемой земли</param>
        /// <returns></returns>
        /// 
        public int ExchangeField(int payerFarmerID, int sellerFarmerID, float fieldArea);

        /// <summary>
        /// Метод, возвращающий список всех фермеров
        /// </summary>
        /// <returns>Список фермеров</returns>
        public List<Farmer> AllFarmers();

        /// <summary>
        /// Метод, осуществляющий сортировку списка фермеров по финансовому капиталу
        /// </summary>
        public List<Farmer> FarmTypeGroup(string farmType);
    }
}
