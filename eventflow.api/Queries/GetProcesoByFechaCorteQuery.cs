using System;
using EventFlow.Queries;

namespace poc.eventflow
{
    public class GetProcesoByFechaCorteQuery : IQuery<ProcesoReadModel>
    {
        public GetProcesoByFechaCorteQuery(DateTime fechaCorte)
        {
            FechaCorte = fechaCorte;
        }
        public DateTime FechaCorte { get; }
    }
}