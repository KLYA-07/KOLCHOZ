namespace Model
{
    public class Farmer : IDomainObject
    {
        public int ID { get; set; }
        public string farmerName { get; set; }
        public string farmerSurname { get; set; }
        public string phoneNumber { get; set; }
        public int finacialCapital { get; set; }
        public float fieldSize { get; set; }
        public string farmAddress { get; set; }
        public string farmType { get; set; }
        public DateTime registrationDate { get; set; }

        public Farmer()
        {
            farmerName = "Иван";
            farmerSurname = "Иванов";
            phoneNumber = "+1234567890";
            finacialCapital = 0;
            fieldSize = 0;
            farmAddress = string.Empty;
            farmType = "Смешанный";
            registrationDate = DateTime.Now;
        }
    }
}
