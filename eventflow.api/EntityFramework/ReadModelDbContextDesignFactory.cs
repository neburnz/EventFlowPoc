using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace poc.eventflow
{
    public class ReadModelDbContextDesignFactory : IDesignTimeDbContextFactory<ReadModelContext>
    {
        public ReadModelContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReadModelContext>()
                .UseSqlServer("{connection string}");
            return new ReadModelContext(optionsBuilder.Options);
        }
    }
}