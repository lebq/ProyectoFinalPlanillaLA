using Galaxy.Bank.Domain.Enums;
using Galaxy.Bank.Domain.ValueObjects;

namespace Galaxy.Bank.Domain.Entities
{
    public sealed class Payment : BaseEntity
    {
        public Guid LoanId { get; }
        public Loan Loan { get; }
        public int Number { get; }
        public DateTime DueDate { get; }
        public Money Amount { get; }
        public Money Interest { get; }
        public Money Total => Amount + Interest;
        public PaymentStatus Status { get; private set; }
        public DateTime? PaymentDate { get; private set; }
        public Money PaidAmount { get; private set; }

        private Payment()
        {

        }

        private Payment(Loan loan, int number, DateTime dueDate, Money amount, Money interest)
        {
            LoanId = loan.Id;
            Loan = loan;
            Number = number;
            DueDate = dueDate;
            Amount = amount;
            Interest = interest;
            Status = PaymentStatus.Pending;
            PaidAmount = new Money(amount.Currency, 0);
        }

        public static Payment Create(Loan loan, int number, DateTime dueDate, Money amount, Money interest)
        {
            return new Payment(loan, number, dueDate, amount, interest);
        }

        public void MarkAsPaid(DateTime paymentDate, Money paidAmount)
        {
            if (Status != PaymentStatus.Pending)
                throw new InvalidOperationException("Only pending payments can be marked as paid.");

            Status = PaymentStatus.Paid;
            PaymentDate = paymentDate;
            PaidAmount = paidAmount;
        }
    }
}
