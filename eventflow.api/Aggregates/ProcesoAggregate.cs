using System;
using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;

namespace poc.eventflow
{
    public class ProcesoAggregate : 
        AggregateRoot<ProcesoAggregate, ProcesoIdentity>
    {
        private readonly ProcesoState _state = new ProcesoState();
        public ProcesoAggregate(ProcesoIdentity identity) : base(identity)
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