using Bibliotekarz.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Customer> Borrowers { get; set; }
}
