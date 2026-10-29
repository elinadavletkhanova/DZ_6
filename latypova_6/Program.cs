using System;
using latypova_6.Classes;

namespace latypova_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Task();
        }

        #region Задание 1
        public static void Task() //Важно: Я не успела прописать summary к методам классов
        {
            Console.WriteLine("Задание 1 - Продемонстрировать все принципы ООП. Абстракция, инкапсуляция, наследование, полиморфизм");

            Console.WriteLine(new string(' ', 37) + "Добро пожаловать в Ботанический Сад!"); //распологаем примерно по центру
            Console.WriteLine("Эта программа демонстрирует управление нашим садом. В нашем Ботаническом Саду есть: ");
            Console.WriteLine("1. Розарий — там ухаживают за цветами, в частности розами, и обрабатывают их декоративно.");
            Console.WriteLine("2. Фруктовый сад — здесь происходит контроль созревания плодов и сезонный сбор урожая.");
            Console.WriteLine("3. Кустарники — тут мы ухаживаем за растениями, омолаживаем их и занимаемся обрезкой крон.");
            Console.WriteLine("Нажмите любую клавишу, если готовы увидеть результат программы с готовыми значениями");
            Console.WriteLine();

            Console.ReadKey();

            try
            {
                Console.WriteLine(new string(' ', 50) + "Розарий");

                RoseGarden rose = new RoseGarden("Дам де Кёр", "Роза гибридная", 2, 50.0, "Чайно-гибридная", "Алый");

                Console.WriteLine("Начальное состояние: ");
                rose.Print();
                Console.WriteLine();

                rose.RemoveThorns();
                rose.AddFertilizer(20);
                rose.ChangeColor("Вишнево-красный");
                rose.Grow();
                Console.WriteLine();

                Console.WriteLine("Итоговое состояние спустя некоторое время: ");
                rose.Print();
                Console.WriteLine("Статус растения: " + rose.Status());
                Console.WriteLine();

                Console.WriteLine(new string(' ', 48) + "Фруктовый сад");
                FruitGarden appleTree = new FruitGarden("Анис алый", "Яблоня", 5, 70.0, "Яблоко", 2.5, 30, "Ранняя осень", 0.15);

                Console.WriteLine("Начальное состояние: ");
                appleTree.Print();
                Console.WriteLine();

                appleTree.TotalWeight();
                appleTree.Grow();
                appleTree.Harvest();
                appleTree.PruneATree();
                Console.WriteLine();

                Console.WriteLine("Итоговое состояние спустя некоторое время: ");
                appleTree.Print();
                Console.WriteLine("Статус растения: " + appleTree.Status());
                Console.WriteLine();

                Console.WriteLine(new string(' ', 50) + "Кустарники");
                Shrub barberry = new Shrub("Ауреа", "Барбарис", 3, 65.0, 0.9);

                Console.WriteLine("Начальное состояние: ");
                barberry.Print();
                Console.WriteLine();

                barberry.Perimeter();
                barberry.DescriptionByAge();
                barberry.Rejuvenate();
                barberry.Grow();
                Console.WriteLine();

                Console.WriteLine("Итоговое состояние спустя некоторое время: ");
                barberry.Print();
                Console.WriteLine("Статус растения: " + barberry.Status());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.ReadKey();
        }

        #endregion
    }
}