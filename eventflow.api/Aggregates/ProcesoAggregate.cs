using System;
using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;

namespace poc.eventflow
{
    public class ProcesoAggregate : AggregateRoot<ProcesoAggregate, ProcesoId>
    {
        private readonly ProcesoState _state = new ProcesoState();
        public ProcesoAggregate(ProcesoId id) : base(id)
        {
            Register(_state);
        }
        public DateTime FechaCorte => _state.FechaCorte;
        public Operacion Operacion => _state.Operacion;
        public IExecutionResult Iniciar(DateTime fechaCorte)
        {
            Emit(new ProcesamientoIniciadoEvent(fechaCorte));
            return ExecutionResult.Success();
        }
        public IExecutionResult Finalizar()
        {
            Emit(new ProcesamientoFinalizadoEvent());
            return ExecutionResult.Success();
        }
    }
}