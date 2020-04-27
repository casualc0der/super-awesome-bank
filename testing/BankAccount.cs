using Bogus;
using System;
using System.Collections.Generic;

namespace testing
{
    public class BankAccount
    {
        public static int NumberOfAccounts { get; private set; }
        public string AccountNumber { get; private set; }
        public string AccountHolder { get; set; }
        public decimal AccountBalance { get; private set; }
        public List<Transaction> Transactions = new List<Transaction> { };
        public static List<BankAccount> Accounts = new List<BankAccount> { };



        public BankAccount(string name)
        {

            AccountNumber = (NumberOfAccounts + 1).ToString();
            AccountHolder = name;
            AccountBalance = 0;
            NumberOfAccounts++;
            Accounts.Add(this);

        }

        public void MakeDeposit(decimal amount, DateTime date)
        {

            if (amount <= 0)
            {
                return;
            }
            else
            {
                var fakeItem = new Faker("en").Commerce.Product();
                Transaction t = new Transaction(amount, fakeItem, date);
                AccountBalance += amount;
                Transactions.Add(t);
            }

        }

        public void MakeWithdrawal(decimal amount, DateTime date)
        {
            if (AccountBalance - amount < 0)
            {
                return;
            }
            else
            {
                var fakeItem = new Faker("en").Commerce.Product();
                Transaction t = new Transaction(-amount, fakeItem, date);
                AccountBalance -= amount;
                Transactions.Add(t);
            }

        }
    }

    public class AccountInfo
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
    }
}
