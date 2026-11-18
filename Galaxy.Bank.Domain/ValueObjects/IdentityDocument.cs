namespace Galaxy.Bank.Domain.ValueObjects
{
    public sealed record IdentityDocument
    {
        public string Type { get; }
        public string Number { get; }

        private IdentityDocument(string type, string number)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type is required", nameof(type));
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Number is required", nameof(number));

            Type = type;
            Number = number;
        }

        public static IdentityDocument Create(string type, string number)
        {
            return new IdentityDocument(type, number);
        }
    }
}
