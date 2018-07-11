using BusTickets.Models;
using System;

namespace BusTickets.Initializer.Generators
{
    public class BankAccountGenerator
    {
        public static BankAccount[] GenerateBankAccounts(Customer[] customers)
        {
            BankAccount[] accounts = new BankAccount[3];

            Random random = new Random();

            for (int i = 0; i < accounts.Length; i++)
            {
                string accNumber = random.Next(0, 10000000).ToString();
                decimal balance = random.Next(100, 100000);

                accounts[i] = new BankAccount
                {
                    AccountNumber = accNumber,
                    Balance = balance,
                    Customer = customers[i]
                };
            }

            return accounts;
        }
    }
}