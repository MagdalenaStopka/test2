﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
       [TestMethod]

       

       public void Debit_WithValidAmount_UpdateBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr Bean ", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");

            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfException()
        {
            double beginningBalance = 11.99;
            double DebitAmount = 100.00;
            BankAccount account = new BankAccount(" mr Bean", beginningBalance);

            account.Debit(DebitAmount);

        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRangeException()
        {
            double beginningBalance = 11.00;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount(" Mr Bean ", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceeddsBalanceMessage);
                return;
            }

            Assert.Fail("The excepected was not thrown");
                
        }
    }
}
