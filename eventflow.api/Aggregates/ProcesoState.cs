using System;
using EventFlow.Aggregates;

namespace poc.eventflow
{
    public class ProcesoState : AggregateState<ProcesoAggregate, ProcesoId, ProcesoState>,
        IApply<ProcesamientoIniciadoEvent>,
        IApply<ProcesamientoFinalizadoEvent>
    {
        private DateTime _fechaCorte;
        private Operacion _operacion;
        public ProcesoState() { }
        public DateTime FechaCorte => _fechaCorte;
        public Operacion Operacion => _operacion;
        public void Apply(ProcesamientoIniciadoEvent aggregateEvent)
        {
            _fechaCorte = aggregateEvent.FechaCorte;
            _operacion = aggregateEvent.Operacion;
        }
        public void Apply(ProcesamientoFinalizadoEvent aggregateEvent)
        {
            _operacion = aggregateEvent.Operacion;
        }
    }
}