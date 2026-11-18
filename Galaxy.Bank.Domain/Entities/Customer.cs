using Galaxy.Bank.Domain.ValueObjects;

namespace Galaxy.Bank.Domain.Entities
{
    public sealed class Customer
    {
        public string Name { get; }
        public string LastName { get; }
        public IdentityDocument Document { get; }
        public string Email { get; }
        public string Address { get; }
        public DateTime BornDate { get; }

        private Customer(string name, string lastName, IdentityDocument document, string email, string address, DateTime bornDate)
        {
            Name = name;
            LastName = lastName;
            Document = document;
            Email = email;
            Address = address;
            BornDate = bornDate;
        }

        public static Customer Create(string name, string lastName, IdentityDocument document, string email, string address, DateTime bornDate)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            if(string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required", nameof(lastName));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required", nameof(email));

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required", nameof(address));

            //Validar si es mayor de edad
            var age = DateTime.Today.Year - bornDate.Year;
            if(age<18)
                throw new ArgumentException("Customer must be at least 18 years old", nameof(bornDate));

            return new Customer(name, lastName, document, email, address, bornDate);
        }
    }
}
