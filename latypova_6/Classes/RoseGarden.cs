using System;

namespace latypova_6.Classes
{
    public class RoseGarden : Plant
    {
        private string _roseVariety; //сорт цветка из розария
        private string _color;
        private bool _hasThorns;
        private int _petalCount;

        public RoseGarden(string name, string species, int age, double waterLevel, string roseVariety, string color, bool hasThorns, int petalCount) 
            : base(name, species, age, waterLevel) //base даёт доступ к Plants
        {
            RoseVariety = roseVariety;
            Color = color;
            HasThorns = hasThorns;
            PetalCount = petalCount;
        }

        public RoseGarden(string name, string species, int age, double waterLevel, string roseVariety, string color)
            : base (name, species, age, waterLevel)
        {
            RoseVariety = roseVariety;
            Color = color;
            HasThorns = false;
            PetalCount = 2;
        }

        public string RoseVariety
        {
            get {  return _roseVariety; }
            set { _roseVariety = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public bool HasThorns
        {
            get { return _hasThorns; }
            set { _hasThorns = value; }
        }

        public int PetalCount
        {
            get { return _petalCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("У цветка из розария должен быть хотя бы один лепесток");
                }

                _petalCount = value;
            }
        }

        public void RemoveThorns()
        {
            if (HasThorns)
            {
                HasThorns = false;
                Console.WriteLine($"Сотрудники ботанического сада аккуратно удалили шипы с розы {Name}");
            }
            else 
            { 
                Console.WriteLine($"У розы {Name} отсутствуют шипы, ничего удалять не нужно"); 
            }
        }

        public void AddFertilizer(int fertilizer)
        {
            if (fertilizer <= 0)
            {
                throw new ArgumentException("Количество удобрения должно быть больше нуля");
            }

            PetalCount += (fertilizer / 10) * 4; //каждые 10 мл способствуют росту 4 лепестков

            WaterLevel += fertilizer * 0.5;

            Console.WriteLine($"Роза {Name} удобрена раствором в размере {fertilizer} миллилитров. Количество лепестков увеличилось и стало равным {PetalCount}");
        }

        public void ChangeColor(string newColor)
        {
            Color = newColor;

            WaterLevel -= 10;

            Console.WriteLine($"В результате селекции цвет лепестков у розы {Name} окрасился в {Color}. Текущая влажность - {WaterLevel}%");
        }

        public override void Grow()
        {
            PetalCount += 4;
            WaterLevel -= 10;

            Console.WriteLine($"{Name} растёт, бутон становится пышнее, теперь у цветка {PetalCount} лепестков");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Розарий:\nСорт - {RoseVariety}\nЦвет - {Color}\nЕсть ли шипы - {(HasThorns ? "есть" : "нет")}" +
                $"\nКоличество лепестков - {PetalCount} шт.\nЖиво ли растение - {(IsAlive ? "да" : "нет")}");
        }
    }
}