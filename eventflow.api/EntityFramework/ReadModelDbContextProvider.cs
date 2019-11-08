using System;
using EventFlow.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace poc.eventflow
{
    public class ReadModelDbContextProvider : IDbContextProvider<ReadModelContext>
    {
        private readonly DbContextOptions<ReadModelContext> _options;
        public ReadModelDbContextProvider(IConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<ReadModelContext>()
                .UseSqlServer(configuration["{connection string}"])
                .Options;
        }
        public ReadModelContext CreateContext()
        {
            var context = new ReadModelContext(_options);
            context.Database.Migrate();
            return context;
        }
    }
}