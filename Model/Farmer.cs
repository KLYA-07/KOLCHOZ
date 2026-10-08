namespace Model
{
    public class Farmer
    {
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
            finacialCapital = 0;
            fieldArea = 0;
            farmAddress = string.Empty;
            farmType = "Смешанный";
            registrationDate = DateTime.Now;
        }
    }
}
