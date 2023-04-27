using Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace server.Database;
public class DentalDBContext : DbContext
{
    public DentalDBContext(DbContextOptions<DentalDBContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
}
