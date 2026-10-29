using System;
using tumakov_6.Enums;

namespace tumakov_6.Classes
{
    public class BankAccount_3
    {
        private long _accountNumber;
        private decimal _balance;
        private AccountType _accountType;

        private static long _nextNumber = 4000000000000;

        public BankAccount_3(decimal balance, AccountType accountType)
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
        /// Пополняет баланс банковского счёта на указанную сумму
        /// </summary>
        /// <param name="amount">Сумма пополнения</param>
        /// <exception cref="ArgumentException">Вызывается, если сумма пополнения меньше или равна нулю</exception>
        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма пополнения должна быть больше нуля");
            }

            Balance += amount;

            Console.WriteLine($"Ваш счёт пополнен на {amount} руб. Текущий баланс счёта - {Balance} руб.");
        }

        /// <summary>
        /// Снимает указанную сумму с банковского счёта
        /// </summary>
        /// <param name="amount">Сумма снятия</param>
        /// <exception cref="ArgumentException">Вызывается, если сумма снятия меньше или равна нулю</exception>
        /// <exception cref="InvalidOperationException">Вызывается, если на счёте недостаточно средств для списания</exception>
        public void WithdrawMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть больше нуля");
            }

            if (Balance < amount)
            {
                throw new InvalidOperationException($"Невозможно снять со счёта {amount} руб. На счёте недостаточно средств, текущий баланс - {Balance} руб.");
            }

            Balance -= amount;

            Console.WriteLine($"С вашего счёта снято {amount} руб. Текущий баланс счёта - {Balance} руб.");
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