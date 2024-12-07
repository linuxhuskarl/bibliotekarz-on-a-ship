namespace Bibliotekarz.Data.Model;

public class Book : BaseAuditedEntity
{
    public required string Title { get; set; }
    public string? Author { get; set; }
    public int PageCount { get; set; }
    public bool IsBorrowed { get; set; }
    public Customer? Borrower { get; set; }
}