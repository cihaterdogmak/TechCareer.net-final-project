using BookWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repository;

/*
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
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Book> Books { get; set; }

    }

    */
public class BaseDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost; Database=tc_book_db; Username=postgres; Password=1234");


    public DbSet<Book> Books { get; set; }
}