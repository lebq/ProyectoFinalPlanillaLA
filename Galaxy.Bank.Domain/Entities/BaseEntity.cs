namespace Galaxy.Bank.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool IsActive { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public string CreatedBy { get; protected set; }
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
