using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace poc.eventflow
{
    public class IniciarProcesoCommandHandler : CommandHandler<ProcesoAggregate, ProcesoIdentity, IExecutionResult, IniciarProcesoCommand>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(
            ProcesoAggregate aggregate,
            IniciarProcesoCommand command,
            CancellationToken cancellationToken)
        {
            var executionResult = aggregate.Iniciar(command.FechaCorte);
            return Task.FromResult(executionResult);
        }
    }
}