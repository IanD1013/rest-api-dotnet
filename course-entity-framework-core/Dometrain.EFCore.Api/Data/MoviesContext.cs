using Dometrain.EFCore.Api.Data.EntityMapping;
using Dometrain.EFCore.API.Data.EntityMapping;
using Dometrain.EFCore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.Api.Data;

public class MoviesContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MoviesDB;User ID=sa;Password=SaPassword!;TrustServerCertificate=True");
        optionsBuilder.LogTo(Console.WriteLine); // not proper logging but good to see what goes on in the database
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MovieMapping());
        modelBuilder.ApplyConfiguration(new GenreMapping());
    }
}