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
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ProcesoDatabaseTest;Integrated Security=true;");
            return new ReadModelContext(optionsBuilder.Options);
        }
    }
}