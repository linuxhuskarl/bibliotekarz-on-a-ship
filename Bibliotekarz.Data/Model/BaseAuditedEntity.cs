namespace Bibliotekarz.Data.Model;

public abstract class BaseAuditedEntity : BaseEntity
{
    public DateTime CreateAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}