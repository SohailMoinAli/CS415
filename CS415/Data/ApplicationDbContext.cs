using Microsoft.EntityFrameworkCore;
using CS415.Models; // This is correct if your models are in a Models folder

namespace CS415.Data // Adjust the namespace to reflect the new location inside the Data folder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
