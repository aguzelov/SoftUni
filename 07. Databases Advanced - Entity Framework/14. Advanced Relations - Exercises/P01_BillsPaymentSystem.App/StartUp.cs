using P01_BillsPaymentSystem.App.DbSeed;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Views;
using System;
using System.Linq;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new BillsPaymentSystemContext();

            //db.Database.EnsureDeleted();
            //
            //db.Database.EnsureCreated();

            //var seeder = new DbSeeder();
            //seeder.Seed(db);

            //PrintUserDetails(db, userId);
            int userId = int.Parse(Console.ReadLine());
            decimal amount = decimal.Parse(Console.ReadLine());
            PayBill(db, userId, amount);
        }

        private static void PayBill(BillsPaymentSystemContext db, int userId, decimal amount)
        {
            db.Database.BeginTransaction();

            var user = db.Users
                .Select(u => new
                {
                    UserId = u.UserId,
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .OrderBy(b => b.BankAccountId)
                        .ToArray(),
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .OrderBy(c => c.CreditCardId)
                        .ToArray()
                })
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} does not exists");
                return;
            }

            if (!HaveMoney(user.BankAccounts, user.CreditCards, amount))
            {
                Console.WriteLine("Insufficient funds!");
                db.Database.RollbackTransaction();
                return;
            }

            foreach (var ba in user.BankAccounts)
            {
                ba.Withdraw(ref amount);

                if (amount == 0)
                {
                    break;
                }
            }

            foreach (var cc in user.CreditCards)
            {
                cc.Withdraw(ref amount);

                if (amount == 0)
                {
                    break;
                }
            }

            db.Database.CommitTransaction();
            db.SaveChanges();
        }

        private static bool HaveMoney(BankAccount[] bankAccounts, CreditCard[] creditCards, decimal amount)
        {
            return bankAccounts.Select(b => b.Balance).Sum() + creditCards.Select(c => c.LimitLeft).Sum() >= amount;
        }

        private static void PrintUserDetails(BillsPaymentSystemContext db, int userId)
        {
            var user = db.Users
                .Where(u => u.UserId == userId)
                .Select(u => new UserDetailsView()
                {
                    Name = $"{u.FirstName} {u.LastName}",
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToArray(),
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToArray(),
                })
                .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
            }
            else
            {
                Console.WriteLine(user);
            }
        }
    }
}