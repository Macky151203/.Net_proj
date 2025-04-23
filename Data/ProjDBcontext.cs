using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;
using Microsoft.Extensions.Configuration;
namespace WebApplication1.Data;

public class ProjDBcontext : DbContext{

    public ProjDBcontext(DbContextOptions options) : base(options)
    {
        Console.WriteLine("ProjDBcontext constructor called.");
    } 
    public DbSet<Walks> Walks { get; set; } 
    public DbSet<Regions> Regions { get; set; } 
    public DbSet<Difficulty> Difficulty { get; set; }

    //seeding data
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        //seed data for difficulties
        var difficulties= new List<Difficulty>(){
            new Difficulty
            {
                Id=Guid.Parse("1a2b3c4d-5e6f-4a8b-9c0d-1e2f3a4b5c6d"),
                Name="Easy"
            },
            new Difficulty
            {
                Id=Guid.Parse("2b3c4d5e-6f7a-4b8c-9d0e-2f3a4b5c6d7e"),
                Name="Medium"
            },
            new Difficulty
            {
                Id=Guid.Parse("3c4d5e6f-7a8b-4c9d-0e1f-3a4b5c6d7e8f"),
                Name="Hard"
            }
        };

        modelBuilder.Entity<Difficulty>().HasData(difficulties);

        var regions=new List<Regions>(){
            new Regions(
                Guid.Parse("1a2b3c4d-5e6f-4a8b-9c0d-1e2f3a4b5c6d"),
                "REG001",
                "Region 1",
                "https://example.com/region1.jpg"

            ),
            new Regions(
                Guid.Parse("2b3c4d5e-6f7a-4b8c-9d0e-2f3a4b5c6d7e"),
                "REG002",
                "Region 2",
                "https://example.com/region2.jpg"
            ),
            new Regions(
                Guid.Parse("3c4d5e6f-7a8b-4c9d-0e1f-3a4b5c6d7e8f"),
                "REG003",
                "Region 3",
                "https://example.com/region3.jpg"
            )
        };
        modelBuilder.Entity<Regions>().HasData(regions);
    }
}

