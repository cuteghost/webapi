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
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Education> Educations{ get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<TreatmentItems> TreatmentItems { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    


}
