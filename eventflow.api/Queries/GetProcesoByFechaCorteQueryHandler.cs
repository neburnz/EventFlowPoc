using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventFlow.EntityFramework;
using EventFlow.Queries;

namespace poc.eventflow
{
    public class GetProcesoByFechaCorteQueryHandler : IQueryHandler<GetProcesoByFechaCorteQuery, ProcesoReadModel>
    {
        private readonly IDbContextProvider<ReadModelContext> _contextProvider;
        public GetProcesoByFechaCorteQueryHandler(IDbContextProvider<ReadModelContext> contextProvider)
        {
            _contextProvider = contextProvider;
        }
        public async Task<ProcesoReadModel> ExecuteQueryAsync(GetProcesoByFechaCorteQuery query, CancellationToken cancellationToken)
        {
            using(var context = _contextProvider.CreateContext())
            {
                var readModel = await context.Procesos
                    .SingleOrDefaultAsync(x => x.FechaCorte == query.FechaCorte, cancellationToken);
                return readModel;
            }
        }
    }
}