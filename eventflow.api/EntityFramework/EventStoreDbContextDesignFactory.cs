using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace poc.eventflow
{
    public class EventStoreDbContextDesignFactory : IDesignTimeDbContextFactory<EventStoreContext>
    {
        public EventStoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventStoreContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ProcesoEventStoreTest;Integrated Security=true;");
            return new EventStoreContext(optionsBuilder.Options);
        }
    }
}