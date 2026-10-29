using System;
using tumakov_6.Classes;
using tumakov_6.Enums;

namespace tumakov_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise7_1();
            Exercise7_2();
            Exercise7_3();
            Homework7_1();
        }

        #region Упражнение 7.1

        public static void Exercise7_1()
        {
            Console.WriteLine("Упражнение 7.1 - Написать программу банковского счёта при помощи класса и вывести основную информацию");

            Console.WriteLine("Введите номер банковского счёта: ");
            var isNumber = long.TryParse(Console.ReadLine(), out var number);

            Console.WriteLine("Введите баланс счёта (через запятую): ");
            var isBalance = decimal.TryParse(Console.ReadLine(), out var balance);

            Console.WriteLine("Введите тип банковского счета (current/deposit): ");
            var isType = Enum.TryParse(Console.ReadLine(), true, out AccountType type); //true для того, чтобы игнорировать регистр

            if (!isNumber || !isBalance || !isType)
            {
                Console.WriteLine("Ошибка: введены неккоректные данные или неверный формат");
                return;
            }

            try
            {
                BankAccount_1 account = new BankAccount_1(number, balance, type);
                account.Print();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка создания банковского счёта: {ex.Message}");
            }

            Console.ReadKey();
        }

        #endregion

        #region Упражнение 7.2

        public static void Exercise7_2()
        {
            Console.WriteLine("Упражнение 7.2 - Изменить предыдущее упражнение так, чтобы номер счёта генерировался сам уникальным способом");

            Console.WriteLine("Введите баланс счёта (через запятую): ");
            var isBalance = decimal.TryParse(Console.ReadLine(), out var balance);

            Console.WriteLine("Введите тип банковского счета (current/deposit): ");
            var isType = Enum.TryParse(Console.ReadLine(), true, out AccountType type);

            if (!isBalance || !isType)
            {
                Console.WriteLine("Ошибка: введены неккоректные данные или неверный формат");
                return;
            }

            try
            {
                BankAccount_2 firstAccount = new BankAccount_2(balance, type); //Выводим информацию о двух аккаунтах,
                                                                               //чтобы наглядно увидеть изменения в типах
                firstAccount.Print();

                BankAccount_2 secondAccount = new BankAccount_2(balance + 777m, type);
                secondAccount.Print();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка создания банковского счёта: {ex.Message}");
            }

            Console.ReadKey();
        }

        #endregion

        #region Упражнение 7.3

        public static void Exercise7_3()
        {
            Console.WriteLine("Упражнение 7.3 - Добавить к предыдущим упражнениям возможность пополнить счёт и снять с него деньги");

            Console.WriteLine("Введите баланс счёта (через запятую): ");
            var isBalance = decimal.TryParse(Console.ReadLine(), out var balance);

            Console.WriteLine("Введите тип банковского счета (current/deposit): ");
            var isType = Enum.TryParse(Console.ReadLine(), true, out AccountType type);

            if (!isBalance || !isType)
            {
                Console.WriteLine("Ошибка: введены неккоректные данные или неверный формат");
                return;
            }

            try
            {
                BankAccount_3 account = new BankAccount_3(balance, type);
                account.Print();

                Console.WriteLine("Выберите одну из цифр в зависимости от операции:\n1 - Пополнить счёт\n2 - Снять деньги со счёта");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите сумму для пополнения (через запятую): ");

                        if (!decimal.TryParse(Console.ReadLine(), out var depAmount))
                        {
                            Console.WriteLine("Ошибка: введен неверный формат числа");
                        }

                        account.DepositMoney(depAmount);
                        break;

                    case "2":
                        Console.WriteLine("Введите сумму для снятия (через запятую): ");

                        if (!decimal.TryParse(Console.ReadLine(), out var withAmount))
                        {
                            Console.WriteLine("Ошибка: введен неверный формат числа");
                        }

                        account.WithdrawMoney(withAmount);
                        break;

                    default:
                        Console.WriteLine("Ошибка: неверный ввод, баланс счёта не поменялся");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания банковского счёта: {ex.Message}");
            }

            Console.ReadKey();
        }

        #endregion

        #region Домашнее задание 7.1

        public static void Homework7_1()
        {
            Console.WriteLine("Домашнее задание 7.1 - Реализовать класс для описания зданий");

            Console.WriteLine("Введите высоту здания в метрах (через запятую): ");
            var isHeight = double.TryParse(Console.ReadLine(), out var height);

            Console.WriteLine("Введите количество этажей в здании: ");
            var isFloors = byte.TryParse(Console.ReadLine(), out var floors);

            Console.WriteLine("Введите количество квартир в здании: ");
            var isApartments = int.TryParse(Console.ReadLine(), out var apartments);

            Console.WriteLine("Введите количество подъездов в здании: ");
            var isEntrances = byte.TryParse(Console.ReadLine(), out var entrances);

            if (!isHeight || !isFloors || !isApartments || !isEntrances)
            {
                Console.WriteLine("Ошибка: введены неккоректные данные или неверный формат");
                return;
            }

            try
            {
                Building building = new Building(height, floors, apartments, entrances);
                building.Print();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка создания банковского счёта: {ex.Message}");
            }

            Console.ReadKey();
        }

        #endregion
    }
}