using System;
using tumakov_6.Enums;

namespace tumakov_6.Classes
{
    public class BankAccount_2
    {
        private long _accountNumber;
        private decimal _balance;
        private AccountType _accountType;

        private static long _nextNumber = 4000000000000;

        public BankAccount_2(decimal balance, AccountType accountType)
        {
            _accountNumber = NextNumber();
            Balance = balance;
            AccountType = accountType;
        }

        /// <summary>
        /// Генерирует следующий уникальный номер банковского счёта с помощью статического счётчика
        /// </summary>
        /// <returns>Уникальный номер банковского счёта</returns>
        public static long NextNumber()
        {
            return _nextNumber++;
        }

        public long AccountNumber
        {
            get { return _accountNumber; }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Баланс не может быть отрицательным");
                }

                _balance = value;
            }
        }

        public AccountType AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }

        /// <summary>
        /// Выводит всю информацию о банковском счёте
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Номер счёта - {AccountNumber}\nБаланс - {Balance} руб.\nТип счёта - {AccountType}");
        }
    }
}