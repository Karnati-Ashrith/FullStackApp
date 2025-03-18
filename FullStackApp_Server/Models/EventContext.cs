using Microsoft.EntityFrameworkCore;

namespace FullStackApp_Server.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<EventModel> Events { get; set; }

        
    }
}
