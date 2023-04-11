using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFweek10dotNet.Models;

public class BlogContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; } //it knows these are entities in the database. It references these as entities in the database.
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder() //builder pattern. is configuring database
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(configuration.GetConnectionString("BloggingContext"));
    }
}