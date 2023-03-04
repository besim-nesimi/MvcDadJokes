using Microsoft.EntityFrameworkCore;
using MvcDadJokes.Models;

namespace MvcDadJokes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<JokesModel> Jokes { get; set; }
    }
}
