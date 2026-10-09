namespace Model
{
    public class Farmer : IDomainObject
    {
        public int ID { get; set; }
        public string farmerName { get; set; }
        public string farmerSurname { get; set; }
        public string phoneNumber { get; set; }
        public decimal finacialCapital { get; set; }
        public float fieldArea { get; set; }
        public string farmAddress { get; set; }
        public string farmType { get; set; }
        public DateTime registrationDate { get; set; }

        public Farmer()
        {
            farmerName = "Иван";
            farmerSurname = "Иванов";
            phoneNumber = "+1234567890";
            finacialCapital = 10000;
            fieldArea = 20;
            farmAddress = "Улица Пушкина, дом Колотушкина";
            farmType = "Смешанный";
            registrationDate = DateTime.Now;
        }
    }
}
