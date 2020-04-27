using Bogus;
using System;

namespace testing
{
    class Program
    {

        public enum Gender
        {
            Male,
            Female
        }


        static void Main(string[] args)
        {

            //var gender = new Bogus.DataSets.Name.Gender();
            var xUser = new Faker<User>()
                    .RuleFor(u => u.firstName, (f, u) => f.Name.FirstName())
                    .RuleFor(u => u.lastName, (f, u) => f.Name.LastName())
                    .RuleFor(u => u.email, (f, u) => f.Internet.Email(u.firstName, u.lastName));

            var rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                var user = xUser.Generate();
                var x = new BankAccount($"{user.firstName} {user.lastName}");

                for (int j = 0; j < 23; j++)
                {
                    x.MakeDeposit(rnd.Next(10), DateTime.Now);
                    x.MakeWithdrawal(rnd.Next(10), DateTime.Now);
                }

            }
            foreach (var item in BankAccount.Accounts)
            {
                item.Transactions.ForEach(x => Console.WriteLine($" {item.AccountHolder} {item.AccountBalance} == {x.Amount}||{x.Note}||{x.Date}"));
            }
            
        }
    }
}
