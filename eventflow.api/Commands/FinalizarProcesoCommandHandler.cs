using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace poc.eventflow
{
    public class FinalizarProcesoCommandHandler : CommandHandler<ProcesoAggregate, ProcesoId, IExecutionResult, FinalizarProcesoCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(
            ProcesoAggregate aggregate,
            FinalizarProcesoCommand command,
            CancellationToken cancellationToken)
        {
            var executionResult = aggregate.Finalizar();
            return Task.FromResult(executionResult);
        }
    }
}