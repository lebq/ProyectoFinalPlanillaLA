namespace Galaxy.Bank.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get;  }
        public bool IsActive { get; protected set; }
        public DateTime CreatedAt { get; }
        public string CreatedBy { get; }
        public DateTime UpdatedAt { get; protected set; }
        public string UpdatedBy { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = Environment.UserName;
        }

        protected void Delete()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = Environment.UserName;
        }
    }
}
