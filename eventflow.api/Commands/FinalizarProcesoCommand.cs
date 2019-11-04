using System;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace poc.eventflow
{
    public class FinalizarProcesoCommand : Command<ProcesoAggregate, ProcesoIdentity, IExecutionResult>
    {
        public FinalizarProcesoCommand(ProcesoIdentity identity) : base(identity)
        {
        }
    }
}