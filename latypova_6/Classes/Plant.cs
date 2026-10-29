using System;

namespace latypova_6.Classes
{
    public abstract class Plant
    {
        private string _name;
        private string _species; //биологический вид, название
        private int _age;
        private double _waterLevel;

        public Plant(string name, string species, int age, double waterLevel)
        {
            Name = name;
            Species = species;
            Age = age;
            WaterLevel = waterLevel;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Species
        {
            get { return _species; }
            set { _species = value; }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Возраст растения не может быть меньше 0");
                }

                _age = value;
            }
        }

        public double WaterLevel
        {
            get { return _waterLevel; }
            set
            {
                if (value < 0)
                    _waterLevel = 0;
                else if (value > 100)
                    _waterLevel = 100;
                else
                    _waterLevel = value;
            }
        }

        public bool IsAlive
        {
            get { return WaterLevel > 15; }
        }

        public void Water(double amount)
        {
            WaterLevel += amount;
            Console.WriteLine($"{Name} {Species} полили на {amount} единиц. Влажность стала: {WaterLevel}%");
        }

        public void NextDay()
        {
            WaterLevel -= 15;
            Console.WriteLine($"На следующий день влажность у растения под названием {Name} {Species} станет равной {WaterLevel}%");
        }

        public string Status()
        {
            switch (WaterLevel)
            {
                case var level when level < 15:
                    return "Погибло";

                case var level when level < 50:
                    return "Плохое состояние, растение нужно полить";

                case var level when level < 80:
                    return "Хорошее состояние, полив пока что не нужен";

                default:
                    return "Отличное состояние";
            }
        }

        public abstract void Grow();

        public virtual void Print()
        {
            Console.WriteLine($"Название растения - {Name}\nВид - {Species}\nВозраст - {Age} г.\nУровень влажности - {WaterLevel}%");
        }
    }
}