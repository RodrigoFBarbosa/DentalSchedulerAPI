using DentalSchedulerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalSchedulerAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Dentist> Dentists { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

}
