﻿using Portania_strikes_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    //~ public class SmallSword : Weapon
    //~ {
        //~ //Не может отрубать конечности

        //~ public SmallSword()
        //~ {
            //~ damage = 15;
            //~ typeOfWeapon = 0;
        //~ }
    //~ }


    //~ public class BigSword : Weapon
    //~ {

        //~ //Может отрубить голову

        //~ public BigSword()
        //~ {
            //~ damage = 40;
            //~ typeOfWeapon = 1;
        //~ }
    //~ }





    public static class MainCharacter //Инвентарь, задания, прочее, связанное с ГГ
    {
        static public int Plot = 0; // "Число сюжета"
        static public string Name; // Имя ГГ
        static public int Money = 100;
        static public int MT = 100; //добавить описание
        static public int MCArmorHead;//добавить описание
        static public int MCArmorBody;//добавить описание
        static public string MCHead;//добавить описание
        static public string MCBody;//добавить описание
        static public int MCWeapon;//добавить описание
        static public int Skills = 1;// 0 - плохо, 1 - нормально
        static public string DoNow;//добавить описание
        static public int HP = 100;//добавить описание
        static public int BeliveLev = 0;//добавить описание
        static public int damage = 25;//добавить описание

        static List<Weapon> weaponsInv = new List<Weapon>();

        static public void DoNothingBM()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(new string('#', 80));
            Console.WriteLine("");
            Console.WriteLine("Вы ничего не делаете.");
            Console.WriteLine("");
            Console.WriteLine(new string('#', 80));
            Console.WriteLine("");
            Console.ReadKey();
        }

    static public void AttackChar(this IEnemy enemy)
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine(new string('#', 80));
        Console.WriteLine("");
        Console.WriteLine("A - Нанести удар");
        if (Skills > 0)
        {
            Console.WriteLine("R - Встать в стойку для ответного удара");
        }
        if (Skills > 1)
        {
            Console.WriteLine("P - Приготовиться паррировать удар");
        }

        Console.WriteLine("");
        Console.WriteLine(new string('#', 80));
        Console.WriteLine("");
        string choice;
        do
        {
            Console.Write("Введите букаву: "); // постоянное меню
            choice = Console.ReadLine(); // ввод меню
        } while (choice == "A" || choice == "R" || choice == "P");
        switch (choice)
        {
            case "A":
                DoBattle(enemy);
                break;
            case "R":
                break;
            case "P":
                break;
        }
    }

     static void DoBattle(this IEnemy enemy)
     {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine(new string('#', 80));
        Console.WriteLine("");
        Console.WriteLine("Куда нанести удар:");
        Console.WriteLine("[T] - тело");
        if(Skills > 0)
        {
            Console.WriteLine("[A] - ass");
        }
        if (enemy.HasTrauma)
        {
            if (enemy.Traumas[0])
            {
                Console.WriteLine("[LA] - левая рука(травм)");
            }
            else
            {
                Console.WriteLine("[LA] - левая рука");
            }
            if (enemy.Traumas[1])
            {
                Console.WriteLine("[RA] - правая рука(травм)");
            }
            else
            {
                Console.WriteLine("[RA] - правая рука");
            }
            if (enemy.Traumas[2])
            {
                Console.WriteLine("[LL] - левая нога(травм)");
            }
            else
            {
                Console.WriteLine("[LL] - левая нога");
            }
            if (enemy.Traumas[3])
            {
                Console.WriteLine("[RL] - правая нога(травм)");
            }
            else
            {
                Console.WriteLine("[RL] - правая нога");
            }
        }
        Console.Write("Введите буквы(Регистр важен): ");
        string choice;
        choice = Console.ReadLine();
        switch (choice)
        {
            case "dew": //nconc: что это за кейс и зачем он тут нужен? можно ведь свитчить int, а не string
                if (choice == "T")
                {
                    goto case "T";
                }
                else if (choice == "A")
                {
                    goto case "A";
                }
                else if (choice == "LA")
                {
                    goto case "LA";
                }
                else if (choice == "RA")
                {
                    goto case "RA";
                }
                else if (choice == "LL")
                {
                    goto case "LL";
                }
                else if (choice == "RL")
                {
                    goto case "RL";
                }
                else
                {
                    goto default;
                }
            case "T":
                AttackLimb("Chest");
                break;
            case "A":
                if(Skills > 0)
                {
                    AttackLimb("ASS");
                }
                else
                {
                    Console.WriteLine("Ошибка");
                    goto default;
                }
                break;
            case "LA":
                AttackLimb("LeftArm");
                break;
            case "RA":
                AttackLimb("RightArm");
                break;
            case "LL":
                AttackLimb("LeftLeg");
                break;
            case "RL":
                AttackLimb("RightLeg");
                break;
            default:
                choice = Console.ReadLine();
                goto case "dew";

        }
       void  AttackLimb(string Chast_tela)
        {
            int ParrySuc = 0;
            int ParryDam = 0;
            Random rnd = new Random();
            switch (Chast_tela)
            {
                case "Chest":
                    if (enemy.DoNow == "par")
                    {
                        int ParryChange = enemy.AttackSkill + enemy.DefenceSkill;
                        ParryChange = 100 - ParryChange;
                        if (ParryChange > 0)
                        {

                            ParrySuc = 2;
                            ParryDam = (enemy.Strength + enemy.ArmorPenetr) - MCArmorBody;
                            if(ParryDam >= 0)
                            {
                              ParryDam = ParryDam * -1;
                            }
                            break;
                        }
                        ParryChange = ParryChange * -1;
                        int ParryChangeRandom = rnd.Next(ParryChange);
                        if (ParryChangeRandom > (ParryChange - enemy.AttackSkill))
                        {
                            ParrySuc = 2;
                            ParryDam = (enemy.Strength + enemy.ArmorPenetr) - MCArmorBody;
                            if (ParryDam >= 0)
                            {
                                ParryDam = ParryDam * -1;
                            }
                            break;
                        }
                        else
                        {
                            ParrySuc = 1;
                        }
                    }
                    break;
            }


            void Output()
            {

            }


        }


    }


        static public int AddMoney(int value)
        {
            Money = value + Money;

            return Money;
        }

        static public int RemoveMoney(int value)
        {
            Money = Money - value;

            if (Money < 0)
            {
                Money = 0;
            }

            return Money;
        }

        static public int RemoveMT(int value)
        {
            MT = MT - value;

            if (MT < 1)
            {
                GameAct.DeadByMind();
            }

            return MT;
        }

        static public int RemoveHP(int value)
        {
            HP = HP - value;

            if (HP < 1)
            {
                GameAct.DeadByPhysic();
            }

            return HP;
        }

        static public int AddMT(int value)
        {
            MT = value + MT;

            if (MT > 100)
            {
                MT = 100;
            }

            return MT;
        }

        static public int AddHP(int value)
        {
            HP = value + HP;

            if (HP > 100)
            {
                HP = 100;
            }

            return HP;
        }

    }

    public static class GameBase
    {
        static public void StartThisShit()
        {

            string NameGG;

            Console.Clear();
            Console.WriteLine("Крац снова требует жертв, третий раз за этот месяц...");
            Console.WriteLine("Группа Портанийских наемников была отправлена на восток.");
            Console.WriteLine("Они точно не знали задачу их похода, но никто не сомневался,");
            Console.WriteLine("что после этих событий их жизни изменятся...");
            Console.WriteLine("...В худшую или лучшую сторону.");
            Console.Write("Молодой оруженосец по имени ");
            NameGG = Convert.ToString(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Молодой оруженосец по имени " + NameGG + " только-только выпустился из оружейной академии Барона Керонча."); //Все это к херам переделать nconc: да вроде и так нормально
            MainCharacter.Name = NameGG;
            Console.ReadKey();
        }

        public static void AboutWorld()
        {
            Console.Clear();
            Console.WriteLine("Лор (жили да были люди) ");
            Console.WriteLine("Лор (которые никак не могли перенести классы в отдельные файлы) ");
            Console.WriteLine("Лор");
            Console.ReadKey();
            DisplayMenu();
        }

        public static void AboutUs()
        {
            Console.Clear();
            Console.WriteLine("Сценарист - ???(Ушел в порно-индустрию)");
            Console.WriteLine("Автор мира - Markela");
            Console.WriteLine("Глав. Гад - Нолтерасс А.К.А Нолт А.К.А Террррррновое Вино А.К.А Noltras"); //
            Console.WriteLine("Соавтор - Солнцеликий Nconc");
            Console.ReadKey();
            DisplayMenu();

        }

        public static void TestStuff()
        {
            Console.Clear();
            Weapon sword = new Weapon(0);
            Dragenhof dragenhof = new Dragenhof();
            dragenhof.DefVillAct();
            FightModule fight = new FightModule();
            fight.GetEnemy("Human", 8, 50, 20, 10, 0, 0);
            Console.ReadKey();
            DisplayMenu();


        }

        public static void CloseAllThisShit()
        {

        }


        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("       Portania Strikes Back    ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("            ");
            }
            Console.WriteLine("1. Начать");
            Console.WriteLine("2. О Мире");
            Console.WriteLine("3. Разработчики");
            Console.WriteLine("4. Тест всякой шняги");
            Console.WriteLine("5. Выход");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("            ");
            }
            string choice;
                Console.Write("Введите число [1-5]: "); // постоянное меню
                choice = Console.ReadLine(); // ввод меню
            switch (choice)
            {
                case "1":
                    StartThisShit();
                    break;
                case "2":
                    AboutWorld();
                    break;
                case "3":
                    AboutUs();
                    break;
                case "4":
                    TestStuff();
                    break;
                case "5":
                    CloseAllThisShit();
                    break;
                    default:
                    goto case "4";
                    //TODO исправить краш при вводе неправильных символов
            }
        }



    }

    //Постройки и их функции

    class Churh
    {
        //TODO  добавить описание переменным
        Random rnd = new Random();
        public int PopChurch;
        int darkKrac;
        int noDarkKrac;
        public int ProsChurch;
        int religiousZeal;
        bool canGetBless = true;
        // Описание и возможности

        public int GetReligiousZeal(int pros)
        {
            switch (pros)
            {
                case 0:
                    return religiousZeal = 30;
                case 1:
                    return religiousZeal = 20;
                case 2:
                    return religiousZeal = 10;
                case 3:
                    return religiousZeal = 0;
            }

            return religiousZeal;
        }


        public void GoToChurch(int popchurh, int proschurh)
        {
            PopChurch = popchurh;
            ProsChurch = proschurh;
            Console.Clear();
            GetReligiousZeal(proschurh);
            Console.WriteLine(new string('#', 80));
            Console.WriteLine("Вы захождите в церковь.");
            switch (proschurh)
            {
                case 0:
                    Console.WriteLine("Хотя населенный пункт является очень бедным, церковь выглядит неплохо.");
                    break;
                case 1:
                    Console.WriteLine("Церковь хорошо выглядит. Видно, бедность не так сильно затронула это место."); // Переделать
                    break;
                case 2:
                    Console.WriteLine("Церковь выглядит отлично. Похоже, это одно из самых богатых построек в городе.");
                    break;
                case 3:
                    Console.WriteLine("Церковь выглядит роскошно и богато. Похоже, это одно из самых богатых построек в городе.");
                    break;
            }
            Console.WriteLine("Подойдя к алтарю пожертвований, вы видите, что:");
            Console.WriteLine("");
            getDarkKrac(PopChurch);
            Console.WriteLine("Последователей  'Темного Краца' - " + darkKrac + "");
            getNoDarkKrac(PopChurch);
            Console.WriteLine("Последователей  'Не Темного Краца' - " + noDarkKrac + "");
            Console.WriteLine("");
            Console.WriteLine(new string('#', 80));
            Console.WriteLine("");
            Console.WriteLine("Вы можете:");
            Console.WriteLine("[1] - Попросить благословение.");
            Console.WriteLine("[2] - Покинуть церковь.");

            string choice;
            Console.Write("Введите букву(Регистр важен): ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "check":
                    if (choice == "1")
                    {
                        goto case "1";
                    }
                    if (choice == "2")
                    {
                        goto case "2";
                    }
                    else
                    {
                        goto default;
                    }
                case "1":
                    if (canGetBless)
                    {
                        getBless();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine(new string('#', 80));
                        Console.WriteLine("");
                        Console.WriteLine("В этом месте вы уже обращались к Крацу.");
                        Console.WriteLine("");
                        Console.WriteLine(new string('#', 80));
                        Console.WriteLine("");
                        Console.ReadKey();
                        GoToChurch(PopChurch, ProsChurch);
                    }
                    break;
                case "2":
                    break;
                default:
                    Console.Write("Давай по новой, Миша, все хуйня: ");
                    choice = Console.ReadLine();
                    goto case "check";
            }
        }



        int getDarkKrac(int alldudes)
        {
            darkKrac = (alldudes / 4) + religiousZeal + 15;
            return darkKrac;
        }

        int getNoDarkKrac(int alldudes)
        {
            noDarkKrac = alldudes - darkKrac;
            return noDarkKrac;
        }

        void getBless()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(new string('#', 80));
            Console.WriteLine("");
            Console.WriteLine("Вы усердно молитесь...");
            Console.WriteLine("");
            Console.WriteLine(new string('#', 80));
            Console.WriteLine("");
            canGetBless = false;
            int iGotBless = rnd.Next(0, 3);
            Console.ReadKey();
            switch (iGotBless)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.WriteLine("Вам кажется, что ничего не поменялось.");
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.ReadKey();
                    GoToChurch(PopChurch, ProsChurch);
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.WriteLine("Вы чувствуете, как энергия проходит сквозь вас.");
                    MainCharacter.BeliveLev = MainCharacter.BeliveLev + 1;
                    MainCharacter.AddHP(5);
                    MainCharacter.AddMT(5);
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.ReadKey();
                    GoToChurch(PopChurch, ProsChurch);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.WriteLine("Вы чувствуете, как у вас начинают трястись руки.");
                    MainCharacter.BeliveLev = MainCharacter.BeliveLev + 3;
                    MainCharacter.RemoveMT(10);
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.ReadKey();
                    GoToChurch(PopChurch, ProsChurch);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.WriteLine("Вы чувствуете, как у вас начинает болеть голова.");
                    MainCharacter.BeliveLev = MainCharacter.BeliveLev + 3;
                    MainCharacter.RemoveHP(10);
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.ReadKey();
                    GoToChurch(PopChurch, ProsChurch);
                    break;
            }
        }

    }


    public class Markt
    {
        int popMarket;
        int prosMarket;
        // Описание и возможности
        public void GoToMarket(int popmarket, int prosmarket)
        {
            popMarket = popmarket; 
            prosMarket = prosmarket;
            Console.Clear();
            Console.WriteLine(new string('#', 80));
            Console.WriteLine("Вы приходите на рынок.");
            if (popmarket > 10 && popmarket < 35)
            {
                Console.WriteLine("Рынок выглядит пустым.");
            }
            else if (popmarket > 35 && popmarket < 75)
            {
                Console.WriteLine("Рынок, не смотря на маленькое население, живет своей жизнью.");
            }
            else if (popmarket > 75 && popmarket < 345)
            {
                Console.WriteLine("Рынок выглядит оживленно.");
            }

            switch (prosmarket)
            {
                case 0:
                    Console.WriteLine("Но не смотря на это, торговцев почти нет, а те, кто есть, завышают цены до небес.");
                    break;
                case 1:
                    Console.WriteLine("Но не смотря на это, торговля в этом поселении умирает от высоких цен и сравнительно небольшого кол-ва товаров.");
                    break;
                case 2:
                    Console.WriteLine("Но не смотря на это, рынок не выглядит бедным; То тут, то там видны разные торговцы, а их товары имеют приемлемую цену.");
                    break;
                case 3:
                    Console.WriteLine("Но не смотря на это, рынок полон торговцами и разными товарами; Торговля процветает и такое положение дел положительно влияет на местные цены.");
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine(new string('#', 80));
            Console.WriteLine("");
        }
    }

        public class Blacksmt
        {
            //кузница для покупки оружий
            
            public void GoToBlacksmt(){
                
            
            List<Weapon> weapons = new List<Weapon>(); //инициализация списка оружий для продажи
            weapons.Add(new Weapon(new Random().Next(1, 3))); //TODO добавить генерацию нескольких оружий, 
            Console.Clear();
                Console.WriteLine(new string('#', 80));
                Console.WriteLine("Вы заходите в кузницу");
                Console.WriteLine("У кузнеца есть:");
                Console.WriteLine("");
                foreach(Weapon weap in weapons)
                {
                    int iType = weap.typeOfWeapon;
                    weap.getDescr(weap.typeOfWeapon); //добавить вывод описания оружия, см класс Weapon
                }
            }

        }
    


        public class Tavrn
        {
            Random rnd = new Random();
            public int PopTavrn;
            public int ProsTavrn;
            // Описание и возможности
            public void GoToTavern(int poptavrn, int prosptavrn)
            {
                PopTavrn = poptavrn;
                ProsTavrn = prosptavrn;
                Console.Clear();
                Console.WriteLine(new string('#', 80));
                Console.WriteLine("Вы захождите в таверну.");
                if (poptavrn > 10 && poptavrn < 35)
                {
                    Console.WriteLine("Таверна выглядит очень пустой.");
                }
                else if (poptavrn > 35 && poptavrn < 75)
                {
                    Console.WriteLine("Таверна выглядит запустелой.");
                }
                else if (poptavrn > 75 && poptavrn < 345)
                {
                    Console.WriteLine("Таверна выглядит НЕ запустелой.");
                }

                switch (prosptavrn)
                {
                    case 0:
                        Console.WriteLine("Состояние ужасное.");
                        break;
                    case 1:
                        Console.WriteLine("Состояние терпимое.");
                        break;
                    case 2:
                        Console.WriteLine("Состояние хорошее.");
                        break;
                    case 3:
                        Console.WriteLine("Состояние отличное.");
                        break;
                }
                //Конец описания
                Console.WriteLine("");
                Console.WriteLine(new string('#', 80));
                Console.WriteLine("");
                Console.WriteLine("Вы можете:");
                Console.WriteLine("[1] - Подойти к барной стойке.");
                Console.WriteLine("[2] - Сесть за стол и перекусить.");
                Console.WriteLine("[3] - Покинуть таверну.");

                string choice;
                Console.Write("Введите букву(Регистр важен): ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "dew": //nconc: что это за кейс и зачем он тут нужен? можно ведь свитчить int, а не string
                        if (choice == "1")
                        {
                            goto case "1";
                        }
                        else if (choice == "2")
                        {
                            goto case "2";
                        }
                        else if (choice == "3")
                        {
                            goto case "3";
                        }
                        else
                        {
                            goto default;
                        }
                    case "1":
                        GoToBar();
                        break;
                    case "2":
                        EatMeal(MainCharacter.HP, MainCharacter.MT, MainCharacter.Money);
                        break;
                    case "3":
                        break;
                    default:
                        Console.Write("Давай по новой, Миша, все хуйня: ");
                        choice = Console.ReadLine();
                        goto case "dew";

                }

                void EatMeal(int gghp, int ggmp, int moneys)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.WriteLine("Вы садитесь за свободный стол.");
                    Console.WriteLine("Спустя какое-то время к вам подходит официантка(???)."); // Официантки вообще были тогда?
                    if (moneys >= 15)
                    {
                        Console.WriteLine("Вы можете заказать:");
                        Console.WriteLine("[1] - Запеченные овощи(15)"); // Нет
                        if (moneys >= 50)
                        {
                            Console.WriteLine("[2] - Суп(50)"); // Нет, пожалуйста
                            if (moneys >= 100)
                            {
                                Console.WriteLine("[3] - Свиной окорок(100)"); // Черт
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine(new string('#', 80));
                        Console.WriteLine("");

                        string choiceEat;
                        Console.Write("Введите букву(Регистр важен): ");
                        choiceEat = Console.ReadLine();
                        switch (choiceEat)
                        {
                            case "check":
                                if (choiceEat == "1")
                                {
                                    goto case "1";
                                }
                                else if (choiceEat == "2")
                                {
                                    goto case "2";
                                }
                                else if (choiceEat == "3")
                                {
                                    goto case "3";
                                }
                                else
                                {
                                    goto default;
                                }
                            case "1":
                                Console.Clear();
                                if (moneys >= 15)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine(new string('#', 80));
                                    Console.WriteLine("");
                                    Console.WriteLine("Вы заказываете самое дешевое блюдо.");
                                    MainCharacter.RemoveMoney(15);
                                    Console.WriteLine("После того, как вы поели, вам стало чуть-чуть лучше.");
                                    MainCharacter.AddHP(10);
                                    MainCharacter.AddMT(5);
                                    Console.WriteLine("");
                                    Console.WriteLine(new string('#', 80));
                                    Console.WriteLine("");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("У вас нет денег на это.");
                                }

                                break;
                            case "2":
                                Console.Clear();
                                if (moneys >= 50)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine(new string('#', 80));
                                    Console.WriteLine("");
                                    Console.WriteLine("Вы заказываете овощи.");
                                    MainCharacter.RemoveMoney(50);
                                    Console.WriteLine("После того, как вы поели, вам стало лучше.");
                                    MainCharacter.AddHP(20);
                                    MainCharacter.AddMT(10);
                                    Console.WriteLine("");
                                    Console.WriteLine(new string('#', 80));
                                    Console.WriteLine("");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("У вас нет денег на это."); //ГЫЫЫЫЯЫЫ ТЫ БОМЖ
                                }
                                break;
                            case "3":
                                Console.Clear();
                                if (moneys >= 100)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine(new string('#', 80));
                                    Console.WriteLine("");
                                    Console.WriteLine("Вы заказываете большой сытный окорок.");
                                    MainCharacter.RemoveMoney(100);
                                    Console.WriteLine("После того, как вы его съели, вам стало очень хорошо.");//Править меню nconc: В плане править? 
                                    MainCharacter.AddHP(25);
                                    MainCharacter.AddMT(15);
                                    Console.WriteLine("");
                                    Console.WriteLine(new string('#', 80));
                                    Console.WriteLine("");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("У вас нет денег на это.");
                                    Console.WriteLine("");
                                    Console.WriteLine(new string('#', 80));
                                    Console.WriteLine("");
                                    Console.ReadKey();
                                }
                                break;
                            default:
                                Console.Write("Давай по новой, Миша, все хуйня: ");
                                choiceEat = Console.ReadLine();
                                goto case "check";

                        }
                    }

                    else
                    {
                        Console.WriteLine("У вас нет денег, чтобы что-нибудь заказать.");
                        Console.WriteLine("");
                        Console.WriteLine(new string('#', 80));
                        Console.WriteLine("");
                        Console.ReadKey();
                    }

                    GoToTavern(PopTavrn, ProsTavrn);
                }

                void GoToBar()
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.WriteLine("Вы подходите к барной стойке");
                    Console.WriteLine("Нужно что-нибудь еще написать...");
							Console.WriteLine("nconc: тут довольно оригинальный способ оставлять комментарии");
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.WriteLine("Вы можете:");
                    Console.WriteLine("[1] - Спросить о слухах.");
                    Console.WriteLine("[2] - Выпить.");
                    Console.WriteLine("[3] - Отойти.");

                    string choice2;
                    Console.Write("Введите букву(Регистр важен): ");
                    choice2 = Console.ReadLine();
                    switch (choice2)
                    {
                        case "dew": //nconc: и снова вопрос: зачем нужен этот кейс? 
                            if (choice2 == "1")
                            {
                                goto case "1";
                            }
                            else if (choice2 == "2")
                            {
                                goto case "2";
                            }
                            else if (choice2 == "3")
                            {
                                goto case "3";
                            }
                            else
                            {
                                goto default;
                            }
                        case "1":
                            TalkBarman();
                            break;
                        case "2":
                            DrinkBarman(MainCharacter.HP, MainCharacter.MT, MainCharacter.Money);
                            break;
                        case "3":
                            GoToTavern(PopTavrn, ProsTavrn);
                            break;
                        default:
                            Console.Write("Давай по новой, Миша, все хуйня: ");
                            choice2 = Console.ReadLine();
                            goto case "dew";

                    }


                }

                void DrinkBarman(int gghp, int ggmp, int moneys)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    if (moneys < 5)
                    {
                        Console.WriteLine("У вас нет денег, чтобы выпить.");
                        Console.WriteLine("");
                        Console.WriteLine(new string('#', 80));
                        Console.WriteLine("");
                        Console.ReadKey();
                        GoToBar();
                    }
                    Console.WriteLine("Вы заказываете себе выпить.");
                    Console.WriteLine("Ваше моральное состояние улучшилось.");
                    MainCharacter.RemoveMoney(5);
                    MainCharacter.RemoveHP(2);
                    MainCharacter.AddMT(25);
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.ReadKey();
                    GoToBar();

                }



                void TalkBarman()
                {
                    // Генератор для слухов
                    int value = rnd.Next(1, 13);
                    int value2 = rnd.Next(1, 10);
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    Console.WriteLine("Вы спрашиваете у владельца таверны, слышал ли он что-либо.");
                    switch (value2) // "Бармен перед слухами"
                    {
                        case 1:
                            Console.WriteLine("Владелец таверны нервно оглядывается и произносит:");
                            break;
                        case 2:
                            Console.WriteLine("Владелец таверны, раздумывая пару секунд, говорит:");
                            break;
                        case 3:
                            Console.WriteLine("Владелец таверны, сплюнув на пол, говорит:");
                            break;
                        case 4:
                            Console.WriteLine("Владелец таверны, наливая еще один стакан посетителю, произносит:");
                            break;
                        case 5:
                            Console.WriteLine("Владелец таверны, убрав грязные стаканы, произносит:");
                            break;
                        case 6:
                            Console.WriteLine("Владелец таверны, посмотрев на вас, говорит:");
                            break;
                        case 7:
                            Console.WriteLine("Владелец таверны что-то делает и произносит:");
                            break;
                        case 8:
                            Console.WriteLine("Владелец таверны... Говорит:");
                            break;
                        case 9:
                            Console.WriteLine("Владелец таверны... Произносит:");
                            break;
                        case 10:
                            Console.WriteLine("Владелец таверны говорит:");
                            break;

                    }
                    switch (value) // Сами слухи
                    {
                        case 1:
                            Console.WriteLine("'Сохраняй спокойствие'");
                            break;
                        case 2:
                            Console.WriteLine("'Будь готов к чему угодно'");
                            break;
                        case 3:
                            Console.WriteLine("'Помни о возможности осмотреться'");
                            break;
                        case 4:
                            Console.WriteLine("'Обрати внимание на то, где ты останавливаешься'");
                            break;
                        case 5:
                            Console.WriteLine("'Помни о дальности зрения каждого противника'");
                            break;
                        case 6:
                            Console.WriteLine("'Шуми'");
                            break;
                        case 7:
                            Console.WriteLine("'Привлечение внимания требует времени'");
                            break;
                        case 8:
                            Console.WriteLine("'Обращай внимание на окна'");
                            break;
                        case 9:
                            Console.WriteLine("'Открывай двери используя свое оружие'");
                            break;
                        case 10:
                            Console.WriteLine("'Не упусти дверь в зону миссии'");
                            break;
                        case 11:
                            Console.WriteLine("'tovarish, mne nravitsya vash govnokod'");
                            break;
                            case 12:
                            Console.WriteLine("'tovarish, codit' c# na raspbian - eto pizdec'");
                            break;

                    }
                    Console.WriteLine("");
                    Console.WriteLine(new string('#', 80));
                    Console.WriteLine("");
                    // Конец генератора
                    Console.ReadKey();
                    GoToBar();
                }


            }

        }
    
    public class Dragenhof : VillageDef
    {
        public Dragenhof()
        {
            Name = "Драгенхоф";
            Buildings = 57;
            Pops = 325;
            Prosp = 1;
            Tavern = true;
            Church = true;

        }


    }




