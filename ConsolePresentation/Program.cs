using Model;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace ConsolePresentation
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            bool a = true;
            Logic logic = new Logic();
            logic.AddFarmer(new Farmer("Юзя", 2500, 300, new Dictionary<string, int>() { { "Кукуруза", 12 }, { "Свекла", 10 }, { "Картошка", 30 },
    { "Томаты", 12 }, { "Морковка", 20 }, { "Коровы", 26 }, { "Свиньи", 52 } }, new Dictionary<string, int>() { { "Кукуруза", 25 },
        { "Свекла", 10 }, { "Картошка", 5 },{ "Томаты", 8 }, { "Морковка", 3 }, { "Коровы", 400 }, { "Свиньи", 150 } },
        new Dictionary<string, int>() { { "Кукуруза", 10 }, { "Свекла", 9 }, { "Картошка", 27 }, { "Томаты", 11 }, { "Морковка", 19 } },
        new Dictionary<string, int>() { { "Коровы", 26 }, { "Свиньи", 52 } }));

            logic.AddFarmer(new Farmer("Рома", 1700, 200, new Dictionary<string, int>() { { "Кукуруза", 8 }, { "Свекла", 5 }, { "Картошка", 40 },
    { "Томаты", 4 }, { "Морковка", 2 }, { "Коровы", 30 }, { "Свиньи", 32 } }, new Dictionary<string, int>() { { "Кукуруза", 20 },
        { "Свекла", 9 }, { "Картошка", 7 },{ "Томаты", 9 }, { "Морковка", 6 }, { "Коровы", 400 }, { "Свиньи", 150 } },
                    new Dictionary<string, int>() { { "Кукуруза", 8 }, { "Свекла", 5 }, { "Картошка", 38 }, { "Томаты", 4 }, { "Морковка", 1 } },
                    new Dictionary<string, int>() { { "Коровы", 26 }, { "Свиньи", 20 } }));
            while (a)
            {
                Console.WriteLine();
                ShowFarmers(logic);
                Console.WriteLine("\nМеню:\n1 - Добавить фермера\n2 - Удалить фермера\n3 - Просмотреть фермера\n4 - Изменить фермера\n5- \n6 - Сортировать урожай\n0 - Выход");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        logic.AddFarmer(Call());
                        break;
                    case 2:
                        Console.WriteLine("Кого по счету вы уберете?");
                        int d = Convert.ToInt32(Console.ReadLine());
                        if (d >0 && d <= logic.AllFarmers.Count)
                        {
                            logic.RemoveFarmer(d - 1);
                        }
                        else
                        {
                            Console.WriteLine("Такого номера у нас нет");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Кого по счету вы просмотрите полностью?");
                        int e = Convert.ToInt32(Console.ReadLine());
                        if (e > 0 && e <= logic.AllFarmers.Count)
                        {

                            Farmer farmer = logic.ReadFarmer(e - 1);

                            string farmerInfo = $"Имя фермера: {farmer.farmerName}\nФинансовый капитал: {farmer.finacialCapital} руб.\nРазмер поля: {farmer.fieldSize} Г\nРазмер урожая: ";

                            foreach (var item in farmer.lastHarvest)
                            {
                                farmerInfo += $"{item.Key}: {item.Value} (Цена: {farmer.harvestCosts[item.Key]} за шт.); ";
                            }
                            farmerInfo = farmerInfo.TrimEnd(' ', ';');

                            farmerInfo += "\nПоголовье скота: ";

                            foreach (var item in farmer.cattleHeadboard)
                            {
                                farmerInfo += $"{item.Key}: {item.Value}; ";
                            }
                            farmerInfo = farmerInfo.TrimEnd(' ', ';');

                            farmerInfo += "\nВыращиваемые культуры: ";

                            foreach (var item in farmer.cultivatingCrops)
                            {
                                farmerInfo += $"{item.Key}: {item.Value} ц; ";
                            }
                            farmerInfo = farmerInfo.TrimEnd(' ', ';');
                            Console.WriteLine(farmerInfo);

                        }
                        else
                        {
                            Console.WriteLine("Такого номера у нас нет");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Кого поменяете?");
                        int t = Convert.ToInt32(Console.ReadLine());
                        if (t > 0 && t <= logic.AllFarmers.Count)
                        {
                            logic.ChangeFarmer(t-1, Call());
                        }
                        else
                        {
                            Console.WriteLine("Такого номера у нас нет");
                        }
                        break;
                    //case 5:
                    //    Console.WriteLine("Введите номер покупателя");
                    //    int payerFarmerIndex = Convert.ToInt32(Console.ReadLine());
                    //    Console.WriteLine("Введите номер продавца");
                    //    int sellerFarmerIndex = Convert.ToInt32(Console.ReadLine());
                    //    foreach (var i in logic.AllFarmers[sellerFarmerIndex].harvestCosts)
                    //    {
                    //        Console.WriteLine($"{i.Key} - {i.Value} руб.");
                    //    }
                    //    string itemName = Console.ReadLine();

                    //    logic.ExchangeProducts(payerFarmerIndex, sellerFarmerIndex, );
                    //    break;
                    case 6:
                        logic.HarvestSort();
                        ShowFarmers(logic);
                        break;
                    case 0:
                        a = false;
                        break;
                    default: Console.WriteLine("Такого варианта нет"); break;

                }
                
            }
        }
        public static Farmer Call()
        {
            
            Console.WriteLine("Введите имя");
            string Name = Console.ReadLine();
            Console.WriteLine("Сколько у него капитала?");
            int finacialCapital = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько у него земли в Га");
            int fieldSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Какой у него уражай");
            Dictionary<string,int> lastHarvest = new Dictionary<string, int>();
            string b = "";
            while (b != "нет")
            {
                Console.WriteLine("Какая культура или животное? (Если закончили напишите - нет)");
                b = Console.ReadLine();
                if (b == "нет") break;
                Console.WriteLine("Сколько?");
                int c = Convert.ToInt32(Console.ReadLine());
                lastHarvest[b] = c;
            }
            Console.WriteLine("Какие у него расценки?");
            Dictionary<string, int> harvestCosts = new Dictionary<string, int>();
            b = "";
            while (b != "нет")
            {
                Console.WriteLine("Какая культура или животное? (Если закончили напишите - нет)");
                b = Console.ReadLine();
                if (b == "нет") break;
                Console.WriteLine("Сколько?");
                int c = Convert.ToInt32(Console.ReadLine());
                harvestCosts[b] = c;
            }
            Console.WriteLine("Сколько у него скотины?");
            Dictionary<string, int> cattleHeadboard = new Dictionary<string, int>();

            b = "";
            while (b != "нет")
            {
                Console.WriteLine("Какое животное? (Если закончили напишите - нет)");
                b = Console.ReadLine();
                if (b == "нет") break;
                Console.WriteLine("Сколько?");
                int c = Convert.ToInt32(Console.ReadLine());
                cattleHeadboard[b] = c;
            }
            Console.WriteLine("Сколько у него растений?");
            Dictionary<string, int>  cultivatingCrops = new Dictionary<string, int>();

            b = "";
            while (b != "нет")
            {
                Console.WriteLine("Какая культура? (Если закончили напишите - нет)");
                b = Console.ReadLine();
                if (b == "нет") break;
                Console.WriteLine("Сколько?");
                int c = Convert.ToInt32(Console.ReadLine());
                cultivatingCrops[b] = c;
            }
            return new Farmer(Name, finacialCapital, fieldSize, lastHarvest, harvestCosts, cattleHeadboard, cultivatingCrops);
        }
        public static void ShowFarmers(Logic logic)
        {
            foreach (var i in logic.AllFarmers)
            {
                Console.WriteLine($"{i.farmerName}");
            }
        }

    }

}
