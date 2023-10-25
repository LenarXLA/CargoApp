using CargoRequestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoRequestAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    
    public DbSet<CargoRequest> CargoRequests { get; set; }
    public DbSet<Sender> Senders { get; set; }
    public DbSet<Recipient> Recipients { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Status> Statuses { get; set; }
}