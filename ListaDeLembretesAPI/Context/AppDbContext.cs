using ListaDeLembretesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeLembretesAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Lembrete>? Lembretes { get; set; }

    }
}