using System;
using tumakov_6.Enums;

namespace tumakov_6.Classes
{
    public class BankAccount_1
    {
        private long _accountNumber;
        private decimal _balance;
        private AccountType _accountType;

        public BankAccount_1(long accountNumber, decimal balance, AccountType accountType)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = accountType;
        }

        public long AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Номер счёта строго положительное значение");
                }

                _accountNumber = value;
            }
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