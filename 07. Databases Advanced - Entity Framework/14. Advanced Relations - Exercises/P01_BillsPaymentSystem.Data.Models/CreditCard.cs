using System;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        private const string NegativeWithdrawExceptionMessage = "Cannot withdraw Negative amount!";
        private const string NegativeDepositExceptionMessage = "Cannot deposit Negative amount!";
        private const string DepositTooMuchExceptionMessage = "The deposit is bigger than the owed sum!";

        private CreditCard()
        {
        }

        public CreditCard(int limit, int moneyOwed, DateTime expirationDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.ExpirationDate = expirationDate;
        }

        public int CreditCardId { get; set; }

        public decimal Limit { get; private set; }

        public decimal MoneyOwed { get; private set; }

        public decimal LimitLeft => Limit - MoneyOwed;

        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; private set; }

        public void Withdraw(ref decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(NegativeWithdrawExceptionMessage);
            }

            if (this.LimitLeft < amount)
            {
                amount -= this.LimitLeft;
                this.MoneyOwed = this.Limit;
            }
            else
            {
                this.MoneyOwed += amount;
                amount = 0;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(NegativeDepositExceptionMessage);
            }

            this.MoneyOwed -= amount;
        }
    }
}