using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.IO;

namespace P01_BillsPaymentSystem.App.DbSeed
{
    public class DbSeeder
    {
        private const string FilePath = @"..\..\..\..\names.txt";

        private Random randomGenerator;

        private string[] names;

        public DbSeeder()
            : this(new Random(), File.ReadAllText(FilePath).Split())
        {
        }

        public DbSeeder(Random randomGenerator, string[] names)
        {
            this.randomGenerator = randomGenerator;
            this.names = names;
        }

        public void Seed(BillsPaymentSystemContext context, int count = 300)
        {
            var users = CreateUsers(count);
            var creditCards = CreateCreditCards(count);
            var bankAccounts = CreateBankAccounts(count);
            var paymentMethods = CreatePaymentMethods(count, users, bankAccounts, creditCards);

            context.PaymentMethods.AddRange(paymentMethods);
            context.SaveChanges();
        }

        private PaymentMethod[] CreatePaymentMethods(int entityCount, User[] users, BankAccount[] bankAccounts, CreditCard[] creditCards)
        {
            var paymentMethods = new PaymentMethod[entityCount];

            var isBankAccount = true;
            for (int i = 0; i < entityCount; i++)
            {
                User user = users[this.randomGenerator.Next(users.Length)];

                if (isBankAccount)
                {
                    paymentMethods[i] = new PaymentMethod(user, bankAccounts[i]);
                    isBankAccount = false;
                }
                else
                {
                    paymentMethods[i] = new PaymentMethod(user, creditCards[i]);
                    isBankAccount = true;
                }
            }

            return paymentMethods;
        }

        private BankAccount[] CreateBankAccounts(int entityCount)
        {
            var accounts = new BankAccount[entityCount];

            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 0; i < entityCount; i++)
            {
                var balance = this.randomGenerator.Next(1000, 10000000);
                var bankName = $"{letters[this.randomGenerator.Next(letters.Length)]}{letters[this.randomGenerator.Next(letters.Length)]}{letters[this.randomGenerator.Next(letters.Length)]} Bank";
                var swift = $"{this.randomGenerator.Next(10000000, 1000000000)}{this.randomGenerator.Next(10000000, 1000000000)}";

                accounts[i] = new BankAccount(balance, bankName, swift);
            }

            return accounts;
        }

        private CreditCard[] CreateCreditCards(int entityCount)
        {
            var creditCards = new CreditCard[entityCount];

            for (int i = 0; i < entityCount; i++)
            {
                var limit = this.randomGenerator.Next(500, 10000);
                var moneyOwed = this.randomGenerator.Next(limit);
                var expirationDate = DateTime.Now.AddMonths(this.randomGenerator.Next(20));

                creditCards[i] = new CreditCard(limit, moneyOwed, expirationDate);
            }

            return creditCards;
        }

        private User[] CreateUsers(int entityCount)
        {
            var users = new User[entityCount];

            for (int i = 0; i < entityCount; i++)
            {
                string firstName = this.names[this.randomGenerator.Next(this.names.Length)];
                string lastName = this.names[this.randomGenerator.Next(this.names.Length)];

                string email = $"{firstName}-{lastName}{this.randomGenerator.Next(10009555)}@{firstName.Substring(0, this.randomGenerator.Next(firstName.Length)) + lastName.Substring(0, this.randomGenerator.Next(lastName.Length))}.com";

                string password = randomGenerator.Next(100000, 100000000).ToString();

                users[i] = new User(firstName, lastName, email, password);
            }

            return users;
        }
    }
}