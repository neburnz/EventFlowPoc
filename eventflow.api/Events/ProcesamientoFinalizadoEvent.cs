using System;
using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace poc.eventflow
{
    [EventVersion("ProcesamientoFinalizado", 1)]
    public class ProcesamientoFinalizadoEvent : AggregateEvent<ProcesoAggregate, ProcesoIdentity>
    {
        public ProcesamientoFinalizadoEvent()
        {
            Operacion = Operacion.Finalizado;
        }
        public Operacion Operacion { get; }
    }
}