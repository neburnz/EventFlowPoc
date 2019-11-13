using System;
using System.Collections.Generic;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace poc.eventflow
{
    public class FinalizarProcesoCommand : DistinctCommand<ProcesoAggregate, ProcesoId, IExecutionResult>
    {
        public FinalizarProcesoCommand(ProcesoId id) : base(id)
        {
        }
        protected override IEnumerable<byte[]> GetSourceIdComponents()
        {
            yield return System.Text.Encoding.UTF8.GetBytes(this.AggregateId.Value);
        }
    }
}