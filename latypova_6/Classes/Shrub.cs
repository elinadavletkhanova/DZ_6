using System;

namespace latypova_6.Classes
{
    public class Shrub : Plant
    {
        private int _trunkCount;
        private double _width;
        private string _shrubCrown; 
        private bool _isFlowering;

        public Shrub(string name, string species, int age, double waterLevel, int trunkCount, double width, string shrubCrown, bool isFlowering)
            : base(name, species, age, waterLevel)
        {
            TrunkCount = trunkCount;
            Width = width;
            ShrubCrown = shrubCrown;
            IsFlowering = isFlowering;
        }

        public Shrub(string name, string species, int age, double waterLevel, double width)
            : base(name, species, age, waterLevel)
        {
            TrunkCount = 4;
            Width = width;
            ShrubCrown = "раскидистый";
            IsFlowering = true;
        }

        public int TrunkCount
        {
            get { return _trunkCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("У кустарника не может не быть ствола");
                }

                _trunkCount = value;
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ширина кустарника должна быть больше нуля");
                }

                _width = value;
            }
        }
        public string ShrubCrown
        {
            get { return _shrubCrown; }
            set { _shrubCrown = value; }
        }

        public bool IsFlowering
        {
            get { return _isFlowering; }
            set { _isFlowering = value; }
        }

        public override void Grow()
        {
            Width += 0.4;
            TrunkCount += 1;
            WaterLevel -= 10;

            Console.WriteLine($"Кустарник {Name} растёт, ширина стала {Width:F2} м, а количество стволов - {TrunkCount}");
        }

        public void Rejuvenate()
        {
            TrunkCount = 1;
            Width = Math.Max(0.2, Width / 3);

            Console.WriteLine($"Кустарник {Name} был омоложен, теперь у него {TrunkCount} ствол, а ширина - {Width:F2} м");
        }

        public void Perimeter()
        {
            double perimeter = Math.PI * Width;

            Console.WriteLine($"У кустарника {Name} периметр кроны примерно {perimeter:F2} м");
        }

        public void DescriptionByAge()
        {
            string description;

            switch (Age)
            {
                case int age when age < 3:
                    description = "молодой";
                    break;

                case int age when age < 10:
                    description = "взрослый";
                    break;

                default:
                    description = "старый";
                    break;
            }

            Console.WriteLine($"Кустарник {Name} в связи со своим возрастом относится к категории - {description}");
        }

        public override void Print()
        {
            base.Print();

            Console.WriteLine($"Кустарник: Количество стволов - {TrunkCount}\nШирина растения - {Width}\nТип|Форма кроны - {ShrubCrown}" +
                $"\nЦветущий кустарник или нет - {(IsFlowering ? "цветущий" : "не цветущий")}\nЖиво ли растение - {(IsAlive ? "да" : "нет")}");
        }
    }
}