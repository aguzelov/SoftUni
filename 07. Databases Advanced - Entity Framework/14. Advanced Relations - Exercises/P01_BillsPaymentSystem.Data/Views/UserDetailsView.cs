using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Views
{
    public class UserDetailsView
    {
        public UserDetailsView()
        {
        }

        public UserDetailsView(string name, BankAccount[] bankAccounts, CreditCard[] creditCards)
        {
            this.Name = name;
            this.BankAccounts = bankAccounts;
            this.CreditCards = creditCards;
        }

        public string Name { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }

        public ICollection<CreditCard> CreditCards { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"User: {this.Name}");
            sb.AppendLine("Bank Accounts:");
            foreach (var ba in this.BankAccounts)
            {
                sb.AppendLine($"--ID: {ba.BankAccountId}");
                sb.AppendLine($"---Balance: {ba.Balance:F2}");
                sb.AppendLine($"---Bank: {ba.BankName}");
                sb.AppendLine($"---SWIFT: {ba.SWIFTCode}");
            }
            sb.AppendLine("Credit Cards:");
            foreach (var cc in this.CreditCards)
            {
                sb.AppendLine($"--ID: {cc.CreditCardId}");
                sb.AppendLine($"---Limit: {cc.Limit:F2}");
                sb.AppendLine($"---Money Owed: {cc.MoneyOwed:F2}");
                sb.AppendLine($"---Limit Left: {cc.LimitLeft:F2}");
                sb.AppendLine($"---Expiration Date: {cc.ExpirationDate.Year}/{cc.ExpirationDate.Month:00}");
            }

            return sb.ToString().Trim();
        }
    }
}