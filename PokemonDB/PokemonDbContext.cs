using Microsoft.EntityFrameworkCore;
using PokemonDB.DbModels;
using System.Reflection.Metadata;

namespace PokemonDB;

public class PokemonDbContext : DbContext
{
    public DbSet<PokemonDBModel> Pokemons { get; set; }
    public DbSet<CategoryDBModel> Categories { get; set; }
    public DbSet<PokemonCategoryDBModel> PokemonCategories { get; set; }
    public DbSet<FightDbModel> Fights { get; set; }
    public DbSet<FightItemDbModel> FightItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Pokemon;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<FightDbModel>()
            .HasOne(e => e.Attacker)
            .WithMany(e => e.AttackerFights)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .Entity<FightDbModel>()
            .HasOne(e => e.Defender)
            .WithMany(e => e.DefenderFights)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
