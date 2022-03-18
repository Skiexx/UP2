using Microsoft.EntityFrameworkCore;
using WOInterface.MVVM.Model;

namespace WOInterface.Core;

public class Context : DbContext
{
    public Context()
    {
        Database.EnsureCreated();
    }

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<StatusOrder> StatusOrders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<StatusPosition> StatusPositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;"
                                    + "Database=Cafe;Trusted_Connection=True;MultipleActiveResultSets=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().Property(p => p.StatusId).HasDefaultValue(1);
    }
}