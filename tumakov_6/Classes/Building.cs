using System;

namespace tumakov_6.Classes
{
    public class Building
    {
        private int _buildingNumber;
        private double _height;
        private byte _floors;
        private int _apartments;
        private byte _entrances;

        private static int _lastBuildingNumber = 0;

        public Building(double height, byte floors, int apartments, byte entrances)
        {
            _buildingNumber = NextNumber();
            Height = height;
            Floors = floors;
            Apartments = apartments;
            Entrances = entrances;
        }

        /// <summary>
        /// Генерирует следующий уникальный номер здания с помощью статического счётчика
        /// </summary>
        /// <returns>Уникальный порядковый номер здания</returns>
        public static int NextNumber()
        {
            return _lastBuildingNumber++;
        }

        public int BuildingNumber
        {
            get { return _buildingNumber; }
        }

        public double Height
        {
            get { return  _height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Высота здания должна быть больше нуля");
                }

                _height = value;
            }
        }

        public byte Floors
        {
            get { return _floors; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Количество этажей должно быть больше нуля");
                }

                _floors = value;
            }
        }

        public int Apartments
        {
            get { return _apartments; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Количество квартир должно быть больше нуля");
                }

                _apartments = value;
            }
        }

        public byte Entrances
        {
            get { return _entrances; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Количество подъездов должно быть больше нуля");
                }

                _entrances = value;
            }
        }

        /// <summary>
        /// Вычисляет высоту одного этажа здания
        /// </summary>
        /// <returns>Высота одного этажа</returns>
        public double FloorHeight()
        {
            return Height / Floors;
        }

        /// <summary>
        /// Вычисляет количество квартир в одном подъезде здания
        /// </summary>
        /// <returns>Количество квартир в подъезде</returns>
        public int ApartmentsInEntrance()
        {
            return Apartments / Entrances;
        }

        /// <summary>
        /// Вычисляет общее количество квартир на одном этаже
        /// </summary>
        /// <returns>Количество квартир на этаже</returns>
        public int ApartmentsPerFloor()
        {
            return Apartments / Floors;
        }

        /// <summary>
        /// Вычисляет среднее количество квартир на одном этаже одного подъезда
        /// </summary>
        /// <returns>Среднее количество квартир на один этаж один подъезд</returns>
        public double AverageApartmentsPerFloor()
        {
            return (double)Apartments / (Floors * Entrances);
        }

        /// <summary>
        /// Выводит всю информацию о здании и о результатах вычислений на консоль
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Здание под номером {BuildingNumber}\nВысота здания - {Height} м\nКоличество этажей - {Floors}\n" +
                $"Количество квартир в здании - {Apartments}\nКоличество подъездов - {Entrances}\nВысота одного этажа - {FloorHeight():F2} м\n" +
                $"Количество квартир в одном подъезде - {ApartmentsInEntrance()}\nКоличество квартир на одном этаже - {ApartmentsPerFloor()}\n" +
                $"Среднее количество квартир на одном этаже одного подъезда - {AverageApartmentsPerFloor():F2}");
        }
    }
}