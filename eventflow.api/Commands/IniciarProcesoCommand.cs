using System;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace poc.eventflow
{
    public class IniciarProcesoCommand : Command<ProcesoAggregate, ProcesoIdentity, IExecutionResult>
    {
        public IniciarProcesoCommand(ProcesoIdentity identity, DateTime fechaCorte) : base(identity)
        {
            FechaCorte = fechaCorte;
        }

        public DateTime FechaCorte { get; }
    }
}