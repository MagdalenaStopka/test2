using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    public class BankAccount
    {
        public const string DebitAmountExceeddsBalanceMessage = " Debit amount exeeds balance";
        public const string DebitLessAmountThanZeroMessage = "Debit mount is less than 0";
        private string m_customerName;
        private double m_balance;
        private bool m_frozen = false;

        private BankAccount()
        {

        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;

        }

        public string CusomerName
        {
            get { return m_customerName; }

        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception(" Account frozen");
            }

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceeddsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitLessAmountThanZeroMessage);
            }
            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if (m_frozen)

            {
                throw new Exception(" Accout frozen");
            }

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }
        private void FreezeAccount()
        {
            m_frozen = true;
        }

        private void UnfreezeAccount()
        {
            m_frozen = false;
        }
        public static void Main()
        {
            BankAccount ba = new BankAccount(" Mr Bean", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}",ba.Balance );

        }

    }   
}
