using Bibliotekarz.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<ApplicationUser>(options)
{
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Customer> Borrowers { get; set; }
    public virtual DbSet<ApplicationUser> Users { get; set; }
}
