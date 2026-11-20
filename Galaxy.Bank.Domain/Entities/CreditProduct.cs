using Galaxy.Bank.Domain.ValueObjects;

namespace Galaxy.Bank.Domain.Entities
{
    public sealed class CreditProduct : BaseEntity
    {
        public string Name { get; }
        public string Description { get; }
        public int MiniumTerm { get; }
        public int MaximumTerm { get; }        
        public Money MaximumAmount { get; }
        public Money MinimumAmount { get; }
        public InterestRate AnnualInterestRate { get; }

        private readonly List<Loan> _loans = new();
        public IReadOnlyCollection<Loan> Loans => _loans.AsReadOnly();

        private CreditProduct()
        {
            
        }

        private CreditProduct(string name, string description, int minimumTerm, int maximumTerm, Money maximumAmount, Money minimumAmount, InterestRate annualInterestRate)
        {
            Name = name;
            Description = description;
            MiniumTerm = minimumTerm;
            MaximumTerm = maximumTerm;
            MinimumAmount = minimumAmount;
            MaximumAmount = maximumAmount;
            AnnualInterestRate = annualInterestRate;
        }

        public static CreditProduct Create(string name, string description, int minimumTerm, int maximumTerm, Money maximumAmount, Money minimumAmount, InterestRate annualInterestRate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required", nameof(description));
            if (minimumTerm <= 0)
                throw new ArgumentException("Minimum term must be greater than zero", nameof(minimumTerm));
            if (maximumTerm <= 0)
                throw new ArgumentException("Maximum term must be greater than zero", nameof(maximumTerm));

            return new CreditProduct(name, description, minimumTerm, maximumTerm, maximumAmount, minimumAmount, annualInterestRate);
        }
    }
}
