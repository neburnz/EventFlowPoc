using System;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace poc.eventflow
{
    public class FinalizarProcesoCommand : Command<ProcesoAggregate, ProcesoId, IExecutionResult>
    {
        public FinalizarProcesoCommand(ProcesoId id) : base(id)
        {
        }
    }
}