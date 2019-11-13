using System;
using System.Collections.Generic;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using EventFlow.Core;

namespace poc.eventflow
{
    public class IniciarProcesoCommand : DistinctCommand<ProcesoAggregate, ProcesoId, IExecutionResult>
    {
        public IniciarProcesoCommand(ProcesoId id, DateTime fechaCorte) : base(id)
        {
            FechaCorte = fechaCorte;
        }
        public DateTime FechaCorte { get; }
        protected override IEnumerable<byte[]> GetSourceIdComponents()
        {
            yield return BitConverter.GetBytes(FechaCorte.Ticks);
        }
    }
}