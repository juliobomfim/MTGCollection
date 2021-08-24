using Microsoft.EntityFrameworkCore;
using MTGCollection.Models;

namespace MTGCollection.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions opts) : base(opts) { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardSubType> CardSubTypes { get; set; }
    }
}
