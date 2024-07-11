using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Journey.Infrastructure;

public class JourneyDbContext:DbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Activity> Activities { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\VitóriaFrançaSousa\\Downloads\\JourneyDatabase.db");
    }
}
