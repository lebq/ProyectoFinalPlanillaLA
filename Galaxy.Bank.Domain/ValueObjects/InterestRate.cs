namespace Galaxy.Bank.Domain.ValueObjects
{
    public sealed record InterestRate
    {
        public decimal Value { get; }

        public decimal AsPercentage => Value * 100;

        private InterestRate()
        {
            
        }

        private InterestRate(decimal value)
        {
            if (value < 1)
                throw new ArgumentException("Interest rate must be greater than or equal to 1", nameof(value));

            Value = value;
        }

        public static InterestRate Create(decimal value)
        {
            return new InterestRate(value);
        }

        public Money CalculateInterest(Money amount, int termInMonths)
        {
            if (termInMonths <= 0)
                throw new ArgumentException("Term in months must be greater than zero", nameof(termInMonths));

            var interestAmount = amount.Amount * Value * termInMonths / 12;
            return new Money(amount.Currency, interestAmount);
        }
    }
}
