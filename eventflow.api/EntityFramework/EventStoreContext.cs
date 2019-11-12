using Microsoft.EntityFrameworkCore;
using EventFlow.EntityFramework.Extensions;

namespace poc.eventflow
{
    public class EventStoreContext : DbContext
    {
        public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .AddEventFlowEvents();
        }
    }
}