using Model;
using BusinessLogic;
using DataAccessLayer;
using Ninject;

namespace ConsolePresentation
{
    /// <summary>
    /// Консольное представление программы для управления фермерами.
    /// Содержит точку входа и меню взаимодействия с пользователем.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// DI-контейнер Ninject, через который получается экземпляр бизнес-логики.
        /// </summary>
        private static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());

        /// <summary>
        /// Экземпляр бизнес-логики, через который выполняются все операции над фермерами.
        /// </summary>
        private static Logic logic = ninjectKernel.Get<Logic>();

        /// <summary>
        /// Точка входа в программу. Инициализирует тестовых фермеров и запускает главное меню.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool a = true;
            string farmersGroup = "";
            List<int> farmersCut = [];
            string b = "";

            // Главный цикл программы — меню
            while (a)
            {
                int fcC = logic.AllFarmers.Count;
                Console.WriteLine(b);
                b = "";
                ShowFarmers(farmersCut);
                Console.WriteLine("\nМеню:\n1 - Добавить фермера\n2 - Удалить фермера\n3 - Просмотреть фермера\n4 - Изменить фермера\n5 - Устроить куплепродажу земли\n6 - Группировать по типу фермерства\n0 - Выход");

                // Обработка выбора пользователя
                switch (ProverkaMin(0))
                {
                    // Добавление нового фермера
                    case 1:
                        Add(logic, farmersCut, farmersGroup);
                        break;

                    // Удаление фермера
                    case 2:
                        Remove(fcC, farmersCut, farmersGroup);
                        break;

                    // Просмотр фермера
                    case 3:
                        Read(fcC, farmersCut, farmersGroup);
                        break;

                    // Изменение данных фермера
                    case 4:
                        Change(fcC, farmersCut, farmersGroup);
                        break;

                    // Купля-продажа земли между фермерами
                    case 5:
                        FieldExchange(fcC, farmersCut, farmersGroup);
                        break;

                    // Группировка фермеров по типу хозяйства
                    case 6:
                        (farmersGroup, farmersCut, b) = FarmTypeGroup(farmersGroup, farmersCut, b);
                        break;

                    // Выход из программы
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
            farmer.farmerName = SProverka();
            Console.WriteLine("Введите фамилию");
            farmer.farmerSurname = SProverka();
            Console.WriteLine("Введите номер телефона");
            farmer.phoneNumber = Phoneverka();
            Console.WriteLine("Введите размер капитала");
            farmer.finacialCapital = ProverkaMin(0);
            Console.WriteLine("Введите размер поля");
            farmer.fieldArea = ProverkaMin(0);
            Console.WriteLine("Введите адрес");
            farmer.farmAddress = SProverka();
            Console.WriteLine("Выберите тип хозяйства:\n1) Скотоводство\n2) Растениеводство\n3) Пчеловодство\n4) Смешанное");
            switch (ProverkaMinMax(1, 4))
            {
                case 1:
                    farmer.farmType = "Скотоводство";
                    break;
                case 2:
                    farmer.farmType = "Растениеводство";
                    break;
                case 3:
                    farmer.farmType = "Пчеловодство";
                    break;
                case 4:
                    farmer.farmType = "Смешанный";
                    break;
            }

            farmer.registrationDate = DateProverka();

            return farmer;
        }

        /// <summary>
        /// Выводит в консоль нумерованный список всех фермеров.
        /// Если <paramref name="farmersCut"/> непуст — только отфильтрованных.
        /// </summary>
        public static void ShowFarmers(List<int> farmersCut)
        {
            int o = 0;
            Console.WriteLine("Список фермеров:");

            if (farmersCut.Count > 0)
            {
                foreach (var i in logic.AllFarmers)
                {
                    if (farmersCut.Contains(o))
                    {
                        Console.WriteLine($"{o + 1}. {i}");
                    }
                    o++;
                }
            }
            else
            {
                foreach (var i in logic.AllFarmers)
                {
                    Console.WriteLine($"{o + 1}. {i}");
                    o++;
                }
            }
        }

        /// <summary>
        /// Добавляет нового фермера и пересчитывает фильтр по типу хозяйства.
        /// </summary>
        public static void Add(Logic logic, List<int> farmersCut, string farmersGroup)
        {
            logic.AddFarmer(Call());
            farmersCut = logic.FarmTypeGroup(farmersGroup);
        }

        /// <summary>
        /// Удаляет фермера по выбранному номеру (с учётом активного фильтра).
        /// </summary>
        public static void Remove(int fcC, List<int> farmersCut, string farmersGroup)
        {
            if (fcC == 0) { Console.WriteLine("Список пуст"); return; }
            Console.WriteLine("Кого по счету вы уберете?");
            if (farmersCut.Count > 0)
            {
                logic.RemoveFarmer(GroupProverka(farmersCut) - 1);
            }
            else
            {
                logic.RemoveFarmer(ProverkaMinMax(1, fcC) - 1);
            }
            farmersCut = logic.FarmTypeGroup(farmersGroup);
        }

        /// <summary>
        /// Полностью выводит данные выбранного фермера.
        /// </summary>
        public static void Read(int fcC, List<int> farmersCut, string farmersGroup)
        {
            if (fcC == 0) { Console.WriteLine("Список пуст"); return; }
            Console.WriteLine("Кого по счету вы просмотрите полностью?");
            Farmer farmer = new Farmer();
            if (farmersCut.Count > 0)
            {
                farmer = logic.ReadFarmer(GroupProverka(farmersCut) - 1);
            }
            else
            {
                farmer = logic.ReadFarmer(ProverkaMinMax(1, fcC) - 1);
            }
            Console.WriteLine($"Имя: {farmer.farmerName}\nФамилия: {farmer.farmerSurname}\nНомер телефона: {farmer.phoneNumber}\nКапитал: {farmer.finacialCapital}\n" +
                    $"Размер поля: {farmer.fieldArea}\nАдрес: {farmer.farmAddress}\nТип хозяйства: {farmer.farmType}\nДата регистрации: {farmer.registrationDate.ToLongDateString()}");
            Console.ReadKey();
        }

        /// <summary>
        /// Подменю редактирования полей выбранного фермера.
        /// Сохранение выполняется по пункту 0, отмена — по пункту 9.
        /// </summary>
        public static void Change(int fcC, List<int> farmersCut, string farmersGroup)
        {
            if (fcC == 0) { Console.WriteLine("Список пуст"); return; }
            Console.WriteLine("Кого поменяете?");
            Farmer farmerch = new Farmer();
            if (farmersCut.Count > 0)
            { farmerch = logic.ReadFarmer(GroupProverka(farmersCut) - 1); }
            else { farmerch = logic.ReadFarmer(ProverkaMinMax(1, fcC) - 1); }

            bool rut = true;

            // Подменю редактирования полей фермера
            while (rut)
            {
                Console.Clear();
                Console.WriteLine("Что вы хотите поменять?\n1. Имя\n2. Фамилию\n3. Номер телефона\n4. Капитал\n5. Размер поля\n6. Адрес\n7. Тип хозяйства\n8. Дату регистрации\n9. Отмена\n0. Сохранить изменения");
                int chs2 = ProverkaMinMax(0, 9);
                switch (chs2)
                {
                    case 0:
                        rut = false;
                        logic.ChangeFarmer(farmerch);
                        farmersCut = logic.FarmTypeGroup(farmersGroup);
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
                        farmerch.finacialCapital = ProverkaMin(0);
                        break;
                    case 5:
                        Console.WriteLine($"Введите размер поля. Старый - {farmerch.fieldArea}");
                        farmerch.fieldArea = ProverkaMin(0);
                        break;
                    case 6:
                        Console.WriteLine($"Введите адрес. Старый - {farmerch.farmAddress}");
                        farmerch.farmAddress = SProverka();
                        break;
                    case 7:
                        Console.WriteLine("Выберите тип хозяйства. Старый - {farmerch.farmType}\n1) Скотоводство\n2) Растениеводство\n3) Пчеловодство\n4) Смешанное");
                        switch (ProverkaMinMax(1, 4))
                        {
                            case 1:
                                farmerch.farmType = "Скотоводство";
                                break;
                            case 2:
                                farmerch.farmType = "Растениеводство";
                                break;
                            case 3:
                                farmerch.farmType = "Пчеловодство";
                                break;
                            case 4:
                                farmerch.farmType = "Смешанное";
                                break;
                        }
                        break;
                    case 8:
                        Console.WriteLine($"Старая дата - {farmerch.registrationDate}");
                        farmerch.registrationDate = DateProverka();
                        break;
                    case 9:
                        rut = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Проводит сделку купли-продажи земли между двумя фермерами.
        /// Обрабатывает коды возврата <c>-1</c> (у продавца мало земли) и <c>0</c> (у покупателя мало средств).
        /// </summary>
        public static void FieldExchange(int fcC, List<int> farmersCut, string farmersGroup)
        {
            if (fcC < 2)
            {
                Console.WriteLine("Недостаточно фермеров");
                return;
            }
            int payerFarmerIndex = 0;
            int sellerFarmerIndex = 0;
            if (farmersCut.Count > 0)
            {
                Console.WriteLine("Введите номер покупателя");
                payerFarmerIndex = GroupProverka(farmersCut);
                Console.WriteLine("Введите номер продавца");
                sellerFarmerIndex = GroupProverka(farmersCut);
            }
            else
            {
                Console.WriteLine("Введите номер покупателя");
                payerFarmerIndex = ProverkaMinMax(1, fcC);
                Console.WriteLine("Введите номер продавца");
                sellerFarmerIndex = ProverkaMinMax(1, fcC);
            }
            if (payerFarmerIndex == sellerFarmerIndex)
            {
                while (payerFarmerIndex == sellerFarmerIndex)
                {
                    Console.WriteLine("Вы выбрали одного и того же фермера. Попробуйте снова.");
                    sellerFarmerIndex = ProverkaMinMax(1, fcC);
                }
            }

            Console.WriteLine($"\nНа счете покупателя: {logic.ReadFarmer(payerFarmerIndex - 1).finacialCapital}\nЗемли у продавца: {logic.ReadFarmer(sellerFarmerIndex - 1).fieldArea}" +
                $"\nСколько покупают?\nЦена за Га: {BusinessService.fieldUnitCost}");
            bool da = true;
            while (da)
            {
                int gbft = logic.ExchangeField(payerFarmerIndex - 1, sellerFarmerIndex - 1, FProverka());
                if (gbft == -1)
                {
                    Console.WriteLine("Произошла ошибка. У продавца меньше земли чем хочет покупатель.\nПопробуете снова? 1 - да, 2 - нет");
                    if (ProverkaMinMax(1, 2) == 2) { da = false; }
                }
                else
                {
                    if (gbft == 0)
                    {
                        Console.WriteLine("Произошла ошибка. У покупателя недостатолчно средств.\nПопробуете снова? 1 - да, 2 - нет");
                        if (ProverkaMinMax(1, 2) == 2) { da = false; }
                    }
                    else
                    {
                        Console.WriteLine("Сделка прошло успешно");
                        da = false;
                    }
                }
            }
        }

        /// <summary>
        /// Фильтрует список фермеров по типу хозяйства.
        /// При пустой выборке формирует сообщение (в текущей реализации — локально, без передачи наружу).
        /// </summary>
        public static (string farmersGroup, List<int> farmersCut, string b) FarmTypeGroup(string farmersGroup, List<int> farmersCut, string b)
        {
            Console.Clear();
            Console.WriteLine("Выберите тип хозяйства:\n1) Все\n2) Скотоводство\n3) Растениеводство\n4) Пчеловодство\n5) Смешанное");
            switch (ProverkaMinMax(1, 5))
            {
                case 1:
                    farmersCut = logic.FarmTypeGroup("");
                    farmersGroup = "";
                    break;
                case 2:
                    farmersCut = logic.FarmTypeGroup("Скотоводство");
                    farmersGroup = "Скотоводство";
                    break;
                case 3:
                    farmersCut = logic.FarmTypeGroup("Растениеводство");
                    farmersGroup = "Растениеводство";
                    break;
                case 4:
                    farmersCut = logic.FarmTypeGroup("Пчеловодство");
                    farmersGroup = "Пчеловодство";
                    break;
                case 5:
                    farmersCut = logic.FarmTypeGroup("Смешанный");
                    farmersGroup = "Смешанный";
                    break;
            }
            if (farmersCut.Count == 0)
            {
                b = "Простите, но фермеров с таким типом фермерства не найдено.";
            }
            return ( farmersGroup,  farmersCut,  b);
        }

        /// <summary>
        /// Проверяет ввод пользователя на соответствие числовому диапазону [min, max].
        /// </summary>
        /// <param name="min">Минимально допустимое значение.</param>
        /// <param name="max">Максимально допустимое значение.</param>
        /// <returns>Введённое пользователем целое число, удовлетворяющее условиям.</returns>
        public static int ProverkaMinMax(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Попробуйте еще раз. Это должно быть число от {min} до {max}");
            }

        }

        /// <summary>
        /// Проверяет ввод целого числа с нижней границей <paramref name="min"/>.
        /// </summary>
        public static int ProverkaMin(int min)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min)
                    return value;
                Console.WriteLine($"Попробуйте еще раз. Должно быть число от {min} до 2 147 483 647");
            }
        }

        /// <summary>
        /// Проверяет ввод строки: удаляет пробелы по краям и требует непустое значение.
        /// </summary>
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

        /// <summary>
        /// Проверяет ввод числа с плавающей точкой (для дробей — запятая).
        /// </summary>
        public static float FProverka()
        {
            string f = "";
            while (true)
            {
                f = Console.ReadLine();
                if (float.TryParse(f, out float value))
                    return value;
                Console.WriteLine($"Попробуйте еще раз. Для дроби используйте запятую.");
            }
        }

        /// <summary>
        /// Проверяет корректность ввода номера телефона.
        /// Допускается ведущий '+', после которого должны идти только цифры.
        /// </summary>
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

        /// <summary>
        /// Запрашивает дату регистрации с проверкой корректности (день, месяц, год).
        /// </summary>
        public static DateTime DateProverka()
        {
            while (true)
            {
                Console.WriteLine("Введите день регистрации");
                int day = ProverkaMinMax(1, 31);
                Console.WriteLine("Введите месяц регистрации");
                int month = ProverkaMinMax(1, 12);
                Console.WriteLine("Введите год регистрации");
                int year = ProverkaMinMax(1900, 2026);

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
        /// Проверяет, что введённое число входит в список допустимых (нумерация +1).
        /// </summary>
        public static int GroupProverka(List<int> list)
        {
            List<int> list1 = list.Select(i => i + 1).ToList();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && list1.Contains(value))
                    return value;
                Console.WriteLine($"Попробуйте еще раз. Это должно быть число из этого списка: {string.Join(", ", list1)}");
            }
        }
    }
}