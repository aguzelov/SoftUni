using System;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        private const string NegativeWithdrawExceptionMessage = "Cannot withdraw Negative amount!";
        private const string NegativeDepositExceptionMessage = "Cannot deposit Negative amount!";

        private BankAccount()
        {
        }

        public BankAccount(int balance, string bankName, string swift)
        {
            Balance = balance;
            BankName = bankName;
            this.SWIFTCode = swift;
        }

        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        public string BankName { get; set; }

        public string SWIFTCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(ref decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(NegativeWithdrawExceptionMessage);
            }

            if (this.Balance < amount)
            {
                amount -= this.Balance;
                this.Balance = 0;
            }
            else
            {
                this.Balance -= amount;
                amount = 0;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(NegativeDepositExceptionMessage);
            }

            this.Balance += amount;
        }
    }
}