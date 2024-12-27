
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.DBContext
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {
        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<UserModal> Users { get; set; }
        public DbSet<ShowModel> Shows { get; set; }
        public DbSet<TheaterModel> Theater { get; set; }
        public DbSet<TicketModal> Tickets { get; set; }
        public DbSet<TranscationModal> Transaction { get; set; }

    }
}
