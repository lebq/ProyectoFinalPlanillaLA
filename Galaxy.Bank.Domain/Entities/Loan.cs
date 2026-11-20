using Galaxy.Bank.Domain.Enums;
using Galaxy.Bank.Domain.ValueObjects;

namespace Galaxy.Bank.Domain.Entities
{
    public sealed class Loan : BaseEntity
    {
        public Customer Customer { get; }
        public Guid CustomerId { get; }
        public CreditProduct CreditProduct { get; }
        public Guid CreditProductId { get; }
        public Money Amount { get; }
        public LoanTerm Term { get; }
        public InterestRate InterestRate { get; }
        public LoanStatus Status { get; private set; }
        public string? ReasonStatus { get; private set; }
        public Money TotalInterest => InterestRate.CalculateInterest(Amount, Term.Months);
        public Money TotalAmount => Amount + TotalInterest;

        private readonly List<Payment> _payments = new();
        public IReadOnlyCollection<Payment> Payments => _payments.AsReadOnly();

        private Loan()
        {
            
        }

        private Loan(Customer customer, CreditProduct creditProduct, Money amount, LoanTerm term, InterestRate interestRate)
        {
            CustomerId = customer.Id;
            CreditProductId = creditProduct.Id;
            Customer = customer;
            CreditProduct = creditProduct;
            Status = LoanStatus.Pending;
            Term = term;
            Amount = amount;
            InterestRate = interestRate;
        }

        public static Loan Create(Customer customer, CreditProduct creditProduct, Money amount, LoanTerm term, InterestRate interestRate)
        {
            return new Loan(customer, creditProduct, amount, term, interestRate);
        }

        public void Approve()
        {
            if (Status != LoanStatus.Pending)
                throw new InvalidOperationException("Only pending loans can be approved.");

            Status = LoanStatus.Approved;
        }

        public void Reject(string reason)
        {
            if (Status != LoanStatus.Pending)
                throw new InvalidOperationException("Only pending loans can be rejected.");

            Status = LoanStatus.Rejected;
            ReasonStatus = reason;
        }
    }
}
