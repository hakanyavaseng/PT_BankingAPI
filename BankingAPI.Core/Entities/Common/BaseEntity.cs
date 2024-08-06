namespace BankingAPI.Core.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedAt { get; set; } 
        public virtual DateTime UpdatedAt { get; set; }
        public virtual bool IsActive { get; set; } = true;
    }
}
