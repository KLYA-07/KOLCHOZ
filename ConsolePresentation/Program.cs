using Model;
using System;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace ConsolePresentation
{
    public class Program
    {
        private static Logic logic = new Logic();

        public static void Main(string[] args)
        {
            bool a = true;
            
            logic.AddFarmer(new Farmer("Юзя", 2500, 300, new Dictionary<string, int>() { { "Кукуруза", 12 }, { "Свекла", 10 }, { "Картошка", 30 },
    { "Томаты", 12 }, { "Морковка", 20 }, { "Коровы", 26 }, { "Свиньи", 52 } }, [25,10, 5, 8, 3, 400, 150 ], ["Кукуруза", "Свекла", "Картошка", "Томаты", "Морковка"],["Коровы", "Свиньи"]));

            logic.AddFarmer(new Farmer("Рома", 1700, 200, new Dictionary<string, int>() { { "Кукуруза", 8 }, { "Свекла", 5 }, { "Картошка", 40 },
    { "Томаты", 4 }, { "Морковка", 2 }, { "Коровы", 30 }, { "Свиньи", 32 } }, [20, 9, 7, 9, 6, 400, 150], ["Кукуруза", "Свекла", "Картошка", "Томаты", "Морковка"],["Коровы","Свиньи"]));
            while (a)
            {
                Console.WriteLine();
                ShowFarmers();
                Console.WriteLine("\nМеню:\n1 - Добавить фермера\n2 - Удалить фермера\n3 - Просмотреть фермера\n4 - Изменить фермера\n5 - Устроить куплепродажу\n6 - Сортировать урожай\n0 - Выход");

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

                            for (int i = 0; i<farmer.lastHarvest.Count;i++)
                            {
                                    var item = farmer.lastHarvest.ElementAt(i);
                                var fhc = farmer.harvestCosts;
                                farmerInfo += $"{item.Key}: {item.Value} (Цена: {fhc[i]} за шт.); ";
                            }
                            farmerInfo = farmerInfo.TrimEnd(' ', ';');

                            farmerInfo += "\nПоголовье скота: ";

                            foreach (var item in farmer.cattleHeadboard)
                            {
                                farmerInfo += $"{item}; ";
                            }
                            farmerInfo = farmerInfo.TrimEnd(' ', ';');

                            farmerInfo += "\nВыращиваемые культуры: ";

                            foreach (var item in farmer.cultivatingCrops)
                            {
                                farmerInfo += $"{item}; ";
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
                        int t = Proverka(1, logic.AllFarmers.Count, false);
                            Console.WriteLine("Хотите его поменять полностью?\n1. Да\n2. Нет");
                            int chs1 = Proverka(1, 2, false);
                            switch (chs1)
                            {
                                case 1:
                                    logic.ChangeFarmer(t - 1, Call());
                                    break;
                                case 2:
                                    Farmer nf = logic.AllFarmers[t - 1];
                                    bool rut = true;
                                    while (rut)
                                    {
                                        Console.WriteLine("Что вы хотите поменять?\n1. Имя\n2. Финансы\n3. Размер поля\n4. Продукты на продажу (заодно и цены)\n5. Стоимости продуктов\n6. Нынешнюю скотину\n7. Нынешние культуры\n0. Хватит изменений");
                                        int chs2 = Proverka(0, 7, false);
                                        switch (chs2)
                                        {
                                            case 0:
                                                rut = false;
                                                break;
                                            case 1:
                                                Console.WriteLine("Как теперь его будут звать?");
                                                string name = "";
                                                while(name == ""){
                                                    name = Console.ReadLine();
                                                    if (name == "") { Console.WriteLine("Попробуйте снова"); }
                                                }
                                                nf.farmerName = name;
                                                break;
                                            case 2:
                                                Console.WriteLine("Сколько у него будет денег?");
                                                nf.finacialCapital=Proverka(0, 2, true);
                                                break;
                                            case 3:
                                                Console.WriteLine("Какое у него будет поле?");
                                                nf.fieldSize = Proverka(1, 2, true);
                                                break;
                                            case 4:
                                                Console.WriteLine();
                                                nf.lastHarvest = new Dictionary<string, int>();
                                                nf.harvestCosts = [];
                                                string abc = "";
                                                while(abc != "нет")
                                                {
                                                    Console.WriteLine("Выберите продукт или нет, чтобы закончить");
                                                    abc = Console.ReadLine();
                                                if (abc== "нет"){ break; }
                                                    if (abc == "") { Console.WriteLine("Попробуйте снова"); }
                                                    else { nf.lastHarvest[abc] = 0; }
                                                }
                                                for (int i = 0; i < nf.lastHarvest.Count; i++)
                                                {
                                                    string key = nf.lastHarvest.ElementAt(i).Key;
                                                    Console.WriteLine($"Сколько {key} будет у него?");
                                                    int l = Proverka(1, 2, true);
                                                    nf.lastHarvest[key]=l;
                                                }
                                                for (int i = 0;i < nf.lastHarvest.Count; i++)
                                                {
                                                    Console.WriteLine($"Сколько будет стоить {nf.lastHarvest.ElementAt(i).Key}?");
                                                    int l = Proverka(1, 2, true);
                                                    nf.harvestCosts.Add(l);
                                                }
                                                break;
                                            case 5:
                                                for (int i = 0; i < nf.harvestCosts.Count; i++)
                                                {
                                                    Console.WriteLine($"Сколько стоить будет {nf.lastHarvest.ElementAt(i)}. Сейчас он стоит - {nf.harvestCosts[i]}");
                                                    nf.harvestCosts[i] = Proverka(1,2,true);
                                                }
                                                break;
                                            case 6:
                                                List<string> animals = new List<string>();
                                                string b = "";
                                                while (b != "нет")
                                                {
                                                    Console.WriteLine("Выберите животное или нет, чтобы закончить");
                                                    b = Console.ReadLine();
                                                if (b == "нет") { break; }
                                                if (b == "") { Console.WriteLine("Попробуйте снова"); }
                                                    else { animals.Add(b); }
                                                }
                                                nf.cattleHeadboard = animals;
                                                break;
                                            case 7:
                                                List<string> veg = new List<string>();
                                                string c = "";
                                                while (c != "нет")
                                                {
                                                    Console.WriteLine("Выберите культуру или нет, чтобы закончить");
                                                    c = Console.ReadLine();
                                                if (c == "нет") { break; }
                                                if (c == "") { Console.WriteLine("Попробуйте снова"); }
                                                    else { veg.Add(c); }
                                                }
                                                nf.cultivatingCrops = veg;
                                                break;
                                        }
                                    }
                                    logic.ChangeFarmer(t-1, nf);
                                    break;
                            }
                            
                        

                        break;
                    case 5:
                        Console.WriteLine("Введите номер покупателя");
                        int payerFarmerIndex = Proverka(1, logic.AllFarmers.Count, false);
                        Console.WriteLine("Введите номер продавца");
                        int sellerFarmerIndex = Proverka(1, logic.AllFarmers.Count, false);
                        Farmer seller = logic.AllFarmers[sellerFarmerIndex-1];
                        for (int i =0; i< seller.lastHarvest.Count; i++)
                        {
                            var s = seller.lastHarvest.ElementAt(i);
                            Console.WriteLine($"{i+1}. {s.Key}, {s.Value} шт. - {seller.harvestCosts[i]} руб.");
                        }
                        Console.WriteLine($"\nНа счете покупателя: {logic.AllFarmers[payerFarmerIndex].finacialCapital}");
                        Console.WriteLine("\nЧто покупают? (введите номер)");
                        int itemindex = Proverka(1, seller.harvestCosts.Count, false);
                        Console.WriteLine("Сколько покупают?");
                        int itemval = Proverka(1, seller.lastHarvest.ElementAt(itemindex - 1).Value, false);
                        logic.ExchangeProducts(payerFarmerIndex-1, sellerFarmerIndex-1, itemindex-1, itemval);
                        break;
                    case 6:
                        logic.HarvestSort();
                        ShowFarmers();
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
            string Name = "";
            while (Name == "")
            {
                Name = Console.ReadLine();
                Name = Name.TrimStart().TrimEnd();
                if (Name == "") { Console.WriteLine("Попробуй снова"); }
            }
            Console.WriteLine("Сколько у него капитала?");
            int finacialCapital = 0;
            finacialCapital = Proverka(0, 2, true);
            Console.WriteLine("Сколько у него земли в Га");
            int fieldSize = 0;
            fieldSize = Proverka(1, 2, true);
            Console.WriteLine("Какой у него урожай");
            Dictionary<string,int> lastHarvest = new Dictionary<string, int>();
            string b = "";
            while (b != "нет")
            {
                Console.WriteLine("Какая культура или животное? (Если закончили напишите - нет)");
                b = Console.ReadLine();
                if (b == "нет") break;
                Console.WriteLine("Сколько?");
                int c = 0;
                c = Proverka(1, 2, true);
                lastHarvest[b] = c;
            }
            Console.WriteLine("Какие у него расценки?");
            List<int> harvestCosts = new List<int>();
            foreach (var lh  in lastHarvest)
            {
                
                int cost = -1;
                while (cost <= 0)
                {
                    Console.WriteLine($"Сколько у него стоит {lh.Key}");
                    cost = Convert.ToInt32(Console.ReadLine()) ;
                    if (cost > 0) { 
                        harvestCosts.Add(cost);
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте снова");
                    }
                }
            }
            Console.WriteLine("Сколько у него скотины?");
            List<string> cattleHeadboard = new List<string>();

            b = "";
            while (b != "нет")
            {
                Console.WriteLine("Какое животное? (Если закончили напишите - нет)");
                b = Console.ReadLine();
                if (b == "нет") break;
                cattleHeadboard.Add(b);
            }
            Console.WriteLine("Сколько у него растений?");
            List<string> cultivatingCrops = new List<string>();

            b = "";
            while (b != "нет")
            {
                Console.WriteLine("Какая культура? (Если закончили напишите - нет)");
                b = Console.ReadLine();
                if (b == "нет") break;
                cultivatingCrops.Add(b);
            }
            return new Farmer(Name, finacialCapital, fieldSize, lastHarvest, harvestCosts, cattleHeadboard, cultivatingCrops);
        }
        public static void ShowFarmers()
        {
            int o = 0;Console.WriteLine("Список фермеров:");
            foreach (var i in logic.AllFarmers)
            {
                
                Console.WriteLine($"{o+1}. {i.farmerName}");
                o++;
            }
        }

        public static int Proverka(int min, int max, bool bl)
        {
            if (bl == false)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                        return value;
                    Console.WriteLine("Попробуйте еще раз");
                }
            }
            else
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int value) && value >= min)
                        return value;
                    Console.WriteLine("Попробуйте еще раз");
                }
            }
        }


    }

}
