using System;
using EventFlow.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace poc.eventflow
{
    public class EventStoreDbContextProvider : IDbContextProvider<EventStoreContext>, IDisposable
    {
        private readonly DbContextOptions<EventStoreContext> _options;
        public EventStoreDbContextProvider(IConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<EventStoreContext>()
                .UseSqlServer(configuration.GetConnectionString("EventStoreConnection"))
                .Options;
        }
        public EventStoreContext CreateContext()
        {
            var context = new EventStoreContext(_options);
            context.Database.EnsureCreated();
            return context;
        }
        public void Dispose()
        {
        }
    }
}