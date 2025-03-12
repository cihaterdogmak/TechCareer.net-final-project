using BookWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repository;


public class BaseDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    //BaseDbContext
    public BaseDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var provider = Configuration.GetValue<string>("DatabaseProvider");

        if (provider == "PostgreSQL")
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PostgreSQLDatabase"));
        }
        else if (provider == "SQLServer")
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SSMSDatabase"));
        }
        else
        {
            throw new Exception("Invalid database provider specified in configuration.");
        }
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Author> Authors { get; set; }

}

/*
public class BaseDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost; Database=tc_book_db; Username=postgres; Password=1234");


    public DbSet<Book> Books { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Author> Authors { get; set; }

}

*/