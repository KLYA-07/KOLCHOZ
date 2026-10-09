using Model;
using BusinessLogic;

namespace ConsolePresentation
{
    /// <summary>
    /// Консольное представление программы для управления фермерами.
    /// Содержит точку входа и меню взаимодействия с пользователем.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Экземпляр бизнес-логики, через который выполняются все операции над фермерами.
        /// </summary>
        private static Logic logic = new Logic();

        /// <summary>
        /// Точка входа в программу. Инициализирует тестовых фермеров и запускает главное меню.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool a = true;
            logic.AddFarmer(new Farmer());
            logic.AddFarmer(new Farmer());
            while (a)
            {

                Console.WriteLine();
                ShowFarmers();
                Console.WriteLine("\nМеню:\n1 - Добавить фермера\n2 - Удалить фермера\n3 - Просмотреть фермера\n4 - Изменить фермера\n5 - Устроить куплепродажу земли\n6 - Сортировать по капиталу\n0 - Выход");

                    switch (Proverka(0, 2, true))
                {
                    case 1:
                        logic.AddFarmer(Call());
                        break;
                    case 2:
                        if (logic.AllFarmers.Count == 0) { Console.WriteLine("Список пуст"); break; }
                        Console.WriteLine("Кого по счету вы уберете?");
                        logic.RemoveFarmer(Proverka(1, logic.AllFarmers.Count, false) - 1);
                        break;
                    case 3:
                        if (logic.AllFarmers.Count == 0) { Console.WriteLine("Список пуст"); break; }
                        Console.WriteLine("Кого по счету вы просмотрите полностью?");
                        Farmer farmer = logic.ReadFarmer(Proverka(1, logic.AllFarmers.Count, false) - 1);
                        Console.WriteLine($"Имя: {farmer.farmerName}\nФамилия: {farmer.farmerSurname}\nНомер телефона: {farmer.phoneNumber}\nКапитал: {farmer.finacialCapital}\n" +
                            $"Размер поля: {farmer.fieldArea}\nАддрес {farmer.farmAddress}:\nТип хозяйства: {farmer.farmType}\nДата регистрации: {farmer.registrationDate.ToLongDateString()}");
                        Console.ReadKey();
                        break;
                    case 4:
                        if (logic.AllFarmers.Count == 0) { Console.WriteLine("Список пуст"); break; }
                        Console.WriteLine("Кого поменяете?");
                        Farmer farmerch = logic.ReadFarmer(Proverka(1, logic.AllFarmers.Count, false) - 1);
                        bool rut = true;
                        while (rut)
                        {
                            Console.Clear();
                            Console.WriteLine("Что вы хотите поменять?\n1. Имя\n2. Фамилию\n3. Номер телефона\n4. Капитал\n5. Размер поля\n6. Аддрес\n7. Тип хозяйства\n8. Дату регистрации\n0. Хватит изменений");
                            int chs2 = Proverka(0, 8, false);
                            switch (chs2)
                            {
                                case 0:
                                    rut = false;
                                    break;
                                case 1:
                                    Console.WriteLine($"Введите имя. Старое - {farmerch.farmerName}");
                                    farmerch.farmerName = SProverka();
                                    break;
                                case 2:
                                    Console.WriteLine($"Введите Фамилию. Старая - {farmerch.farmerSurname}");
                                    farmerch.farmerSurname = SProverka();
                                    break;
                                case 3:
                                    Console.WriteLine($"Введите номер телефона. Старый - {farmerch.phoneNumber}");
                                    farmerch.phoneNumber = Phoneverka();
                                    break;
                                case 4:
                                    Console.WriteLine($"Введите размер капитала. Старый - {farmerch.finacialCapital}");
                                    farmerch.finacialCapital = Proverka(0, 2, true);
                                    break;

                                case 5:
                                    Console.WriteLine($"Введите размер поля. Старый - {farmerch.fieldArea}");
                                    farmerch.fieldArea = Proverka(0, 2, true);
                                    break;
                                case 6:
                                    Console.WriteLine($"Введите адрес. Старый - {farmerch.farmAddress}");
                                    farmerch.farmAddress = SProverka();
                                    break;
                                case 7:
                                    Console.WriteLine($"Введите тип хозяйства. Старый - {farmerch.farmType}");
                                    farmerch.farmType = SProverka();
                                    break;
                                case 8:
                                    Console.WriteLine($"Старая дата - {farmerch.registrationDate}");
                                    farmerch.registrationDate = DateProverka();
                                    break;
                            }
                        }

                        break;
                    case 5:
                        if (logic.AllFarmers.Count < 2)
                        {
                            Console.WriteLine("Недостаточно фермеров");
                            break;
                        }
                        Console.WriteLine("Введите номер покупателя");
                        int payerFarmerIndex = Proverka(1, logic.AllFarmers.Count, false);
                        Console.WriteLine("Введите номер продавца");
                        int sellerFarmerIndex = Proverka(1, logic.AllFarmers.Count, false);

                        if (payerFarmerIndex == sellerFarmerIndex)
                        {

                            while (payerFarmerIndex == sellerFarmerIndex)
                            {
                                Console.WriteLine("Вы выбрали одного и того же фермера. Попробуйте снова.");
                                sellerFarmerIndex = Proverka(1, logic.AllFarmers.Count, false);
                            }
                        }
                        
                        Console.WriteLine($"\nНа счете покупателя: {logic.ReadFarmer(payerFarmerIndex-1).finacialCapital}\nЗемли у продавца: {logic.ReadFarmer(sellerFarmerIndex-1).fieldArea}" +
                            $"\nСколько покупают?\nЦена за Га: {Logic.fieldUnitCost}");
                        bool da = true;
                        while (da)
                        {
                            if (!logic.GroupByFarmType(payerFarmerIndex - 1, sellerFarmerIndex - 1, FProverka()))
                            {
                                Console.WriteLine("Произошла ошибка. Попробуете снова? 1 - да, 2 - нет");
                                if (Proverka(1, 2, false) == 2) {
                                    da = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Сделка прошло успешно");
                                da = false;
                            }
                        }
                        break;
                    case 6:
                        Console.Clear();
                        logic.HarvestSort();

                        break;
                    case 0:
                        a = false;
                        break;
                    default: Console.WriteLine("Такого варианта нет"); break;
                }
                
                Console.Clear();
            }
        }

        /// <summary>
        /// Запрашивает у пользователя данные для создания нового фермера.
        /// </summary>
        /// <returns>Новый объект <see cref="Farmer"/> с введёнными данными.</returns>
        public static Farmer Call()
        {
            Farmer farmer = new Farmer();
            Console.WriteLine("Введите имя");
            farmer.farmerName=SProverka();
            Console.WriteLine("Введите фамилию");
            farmer.farmerSurname = SProverka();
            Console.WriteLine("Введите номер телефона");
            farmer.phoneNumber = Phoneverka();
            Console.WriteLine("Введите размер капитала");
            farmer.finacialCapital = Proverka(0, 2, true);
            Console.WriteLine("Введите размер поля");
            farmer.fieldArea = Proverka(0, 2, true);
            Console.WriteLine("Введите адрес");
            farmer.farmAddress= SProverka();
            Console.WriteLine("Введите тип хозяйства");
            farmer.farmType = SProverka();
            farmer.registrationDate = DateProverka();
                
            
            return farmer;
        }

        /// <summary>
        /// Выводит в консоль нумерованный список всех фермеров.
        /// </summary>
        public static void ShowFarmers()
        {
            int o = 0;
            Console.WriteLine("Список фермеров:");
            foreach (var i in logic.AllFarmers)
            {
                Console.WriteLine($"{o + 1}. {i}");
                o++;
            }
        }

        /// <summary>
        /// Проверяет ввод пользователя на соответствие числовому диапазону.
        /// </summary>
        /// <param name="min">Минимально допустимое значение.</param>
        /// <param name="max">Максимально допустимое значение (используется только если <paramref name="bl"/> = false).</param>
        /// <param name="bl">
        /// Если <c>false</c> — проверяется диапазон [min, max].
        /// Если <c>true</c> — проверяется только нижняя граница (значение &gt;= min).
        /// </param>
        /// <returns>Введённое пользователем целое число, удовлетворяющее условиям.</returns>
        public static int Proverka(int min, int max, bool bl)
        {
            if (bl == false)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                        return value;
                    Console.WriteLine($"Попробуйте еще раз. Это должно быть число от {min} до {max}");
                }
            }
            else
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int value) && value >= min)
                        return value;
                    Console.WriteLine($"Попробуйте еще раз. Должно быть число от {min} до 2 147 483 647");
                }
            }
        }

        public static string SProverka()
        {
            string s = "";
            while (s == "")
            {
                s = Console.ReadLine();
                s = s.TrimStart().TrimEnd();
                if (s == "") { Console.WriteLine("Попробуй снова. Должен быть хотя бы 1 символ"); }
            }
            return s;
        }

        public static float FProverka()
        {
            string f= "";
            while (true)
            {
                f = Console.ReadLine();
                if (float.TryParse(f, out float value))
                    return value;
                Console.WriteLine($"Попробуйте еще раз. Для дроби используйте запятую.");
            }
        }

        public static string Phoneverka()
        {
            string phone = "";
            while (true)
            {
                phone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phone))
                {
                    Console.WriteLine("Попробуйте снова. Номер не может быть пустым.");
                    continue;
                }
                if (phone[0] != '+' && !char.IsDigit(phone[0]))
                {
                    Console.WriteLine("Попробуйте снова. Номер должен представлять из себя число или число с '+' в начале.");
                    continue;
                }
                bool allDigits = true;
                for (int i = 1; i < phone.Length; i++)
                {
                    if (!char.IsDigit(phone[i]))
                    {
                        allDigits = false;
                        break;
                    }
                }
                if (phone[0] == '+' && phone.Length < 2)
                {
                    Console.WriteLine("После + должны стоять цифры");
                    continue;
                }
                if (!allDigits)
                {
                    Console.WriteLine("Попробуйте снова. После '+' должны быть только цифры.");
                    continue;
                }
                break;
            }
            return phone;
        }

        public static DateTime DateProverka()
        {
            while (true)
            {
                Console.WriteLine("Введите день регистрации");
                int day = Proverka(1, 31, false);
                Console.WriteLine("Введите месяц регистрации");
                int month = Proverka(1, 12, false);
                Console.WriteLine("Введите год регистрации");
                int year = Proverka(1900, 2026, false);

                try
                {
                    return new DateTime(year, month, day);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Такой даты не существует. Попробуйте снова.\n");
                }

            }
        }

        /// <summary>
        /// Выводит в консоль подробную информацию о фермере по его номеру (e).
        /// Если номер вне диапазона 1..logic.AllFarmers.Count — выводит сообщение об отсутствии.
        /// </summary>

        
    }
}