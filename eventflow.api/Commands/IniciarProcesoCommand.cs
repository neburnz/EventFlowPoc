using System;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace poc.eventflow
{
    public class IniciarProcesoCommand : Command<ProcesoAggregate, ProcesoId, IExecutionResult>
    {
        public IniciarProcesoCommand(ProcesoId id, DateTime fechaCorte) : base(id)
        {
            FechaCorte = fechaCorte;
        }

        public DateTime FechaCorte { get; }
    }
}