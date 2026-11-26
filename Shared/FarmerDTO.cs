using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FarmerDTO
    {
        public int ID { get; }
        public string farmerName { get; }
        public string farmerSurname { get; }
        public string phoneNumber { get; }
        public decimal finacialCapital { get; }
        public float fieldArea { get; }
        public string farmAddress { get; }
        public string farmType { get; }
        public DateTime registrationDate { get; }

        /// <summary>
        /// Конструктор для удаления
        /// </summary>
        /// <param name="id">ID для удаления</param>
        public FarmerDTO(int id)
        {
            ID = id;
        }

        /// <summary>
        /// Конструктор для создания фермера
        /// </summary>
        /// <param name="farmerName">Имя</param>
        /// <param name="farmerSurname">Фамилия</param>
        /// <param name="phoneNumber">Телефон</param>
        /// <param name="finacialCapital">Финансовый капитал</param>
        /// <param name="fieldArea">Размер поля</param>
        /// <param name="farmAddress">Адрес</param>
        /// <param name="farmType">Тип хоз-ва</param>
        /// <param name="registrationDate">Дата регистрации</param>
        public FarmerDTO(string farmerName, string farmerSurname, string phoneNumber, decimal finacialCapital, float fieldArea, string farmAddress, string farmType, DateTime registrationDate)
        {
            this.farmerName = farmerName;
            this.farmerSurname = farmerSurname;
            this.phoneNumber = phoneNumber;
            this.finacialCapital = finacialCapital;
            this.fieldArea = fieldArea;
            this.farmAddress = farmAddress;
            this.farmType = farmType;
            this.registrationDate = registrationDate;
        }
    }
}
