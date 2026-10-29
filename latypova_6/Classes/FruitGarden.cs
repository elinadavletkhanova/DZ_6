using System;

namespace latypova_6.Classes
{
    public class FruitGarden : Plant
    {
        private string _fruitType;
        private double _height;
        private int _fruitCount;
        private string _harvestSeason;
        private double _singleFruitWeight;

        public FruitGarden(string name, string species, int age, double waterLevel, string fruitType, double height, int fruitCount, string harvestSeason, double singleFruitWeight)
            : base(name, species, age, waterLevel)
        {
            FruitType = fruitType;
            Height = height;
            FruitCount = fruitCount;
            HarvestSeason = harvestSeason;
            SingleFruitWeight = singleFruitWeight;
        }

        public FruitGarden(string name, string species, int age, double waterLevel, string fruitType, int fruitCount, double singleFruitWeight)
            : base(name, species, age, waterLevel)
        {
            FruitType = fruitType;
            Height = 1.0 + Age * 0.45;
            FruitCount = fruitCount;
            HarvestSeason = "Зима";
            SingleFruitWeight = singleFruitWeight;
        }

        public string FruitType
        {
            get { return _fruitType; }
            set { _fruitType = value; }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Высота фруктового дерева должна быть больше нуля");
                }

                _height = value;
            }
        }

        public int FruitCount
        {
            get { return _fruitCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Количество плодов на дереве не может быть отрицательным");
                }

                _fruitCount = value;
            }
        }

        public string HarvestSeason
        {
            get { return _harvestSeason; }
            set { _harvestSeason = value; }
        }

        public double SingleFruitWeight
        {
            get { return _singleFruitWeight; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Вес плода должен быть больше нуля");
                }

                _singleFruitWeight = value;
            }
        }

        public override void Grow()
        {
            FruitCount += 15;
            WaterLevel -= 10;

            Console.WriteLine($"Фруктовое дерево {Name} растёт, в ходе чего на ветвях завязались новые плоды, теперь их {FruitCount} штук");
        }

        public void Harvest()
        {
            if (FruitCount > 0)
            {
                Console.WriteLine($"Сотрудники успешно собрали весь урожай с дерева {Name}. Было собрано {FruitCount} шт.");
                FruitCount = 0;
            }
            else
            {
                Console.WriteLine($"Сейчас на дереве под названием {Name} нет плодов, невозможно собрать урожай");
            }
        }

        public void TotalWeight()
        {
            double totalWeight = FruitCount * SingleFruitWeight;

            Console.WriteLine($"На дереве {Name} сейчас находится примерно {totalWeight:F2} кг плодов");
        }

        public void PruneATree()
        {
            Height = Math.Max(0.1, Height - 0.5); //не 0, т.к. выпадет исключение, дерево нельзя полностью срубить
            FruitCount += 120;

            Console.WriteLine($"Сотрудники обрезали дерево {Name}, нынешняя высота - {Height} м, в следующем сезоне ожидается {FruitCount} шт. плода");
        }

        public override void Print()
        {
            base.Print();

            Console.WriteLine($"Фруктовый сад: Тип плода - {FruitType}\nВысота дерева - {Height} м.\n" +
                $"Примерное количество плодов на дереве - {FruitCount} шт.\nСезон сбора плодов - {HarvestSeason}" +
                $"\nВес одного плода данного растения - {SingleFruitWeight} кг\nЖиво ли растение - {(IsAlive ? "да" : "нет")}");
        }
    }
}