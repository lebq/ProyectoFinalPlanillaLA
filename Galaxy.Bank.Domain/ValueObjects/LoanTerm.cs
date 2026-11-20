namespace Galaxy.Bank.Domain.ValueObjects
{
    public sealed record LoanTerm
    {
        public int Months { get; }

        private LoanTerm()
        {
            
        }

        private LoanTerm(int months)
        {
            if (months < 6)
                throw new ArgumentException("Loan term must be greater than 5 months", nameof(months));

            if(months > 360)
                throw new ArgumentException("Loan term must be less than 361 months", nameof(months));

            Months = months;
        }

        public static LoanTerm Create(int months)
        {
            return new LoanTerm(months);
        }

        public int AsYears()
        {
            return Months / 12;
        }
    }
}
