namespace Galaxy.Bank.Domain.ValueObjects
{
    public sealed record Money
    {
        public string Currency { get; }
        public decimal Amount { get; }

        private Money()
        {
            
        }

        public Money(string currency, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required", nameof(currency));

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero", nameof(amount));

            Currency = currency;
            Amount = amount;
        }

        public static Money Create(string currency, decimal amount)
        {
            return new Money(currency, amount);
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Cannot add Money with different currencies");

            return new Money(a.Currency, a.Amount + b.Amount);
        }
    }
}
