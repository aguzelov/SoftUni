namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        private PaymentMethod()
        {
        }

        public PaymentMethod(User user, BankAccount bankAccount)
        {
            this.User = user;
            this.BankAccount = bankAccount;
            this.Type = PaymentMethodType.BankAccount;
        }

        public PaymentMethod(User user, CreditCard creditCard)
        {
            this.User = user;
            this.CreditCard = creditCard;
            this.Type = PaymentMethodType.CreditCard;
        }

        public int Id { get; set; }

        public PaymentMethodType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}