using BASITWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BASITWEBAPI;

public class AppDbContext : DbContext {
    public DbSet<Room> Rooms {get; set;}
    public DbSet<User> Users{get; set;}
    public DbSet<Message> Messages {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.sqlite;");
    }
}