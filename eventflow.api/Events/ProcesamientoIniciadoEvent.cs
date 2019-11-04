using System;
using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace poc.eventflow
{
    [EventVersion("ProcesamientoIniciado", 1)]
    public class ProcesamientoIniciadoEvent : AggregateEvent<ProcesoAggregate, ProcesoIdentity>
    {
        public ProcesamientoIniciadoEvent(DateTime fechaCorte)
        {
            FechaCorte = fechaCorte;
            Operacion = Operacion.Iniciado;
        }
        public DateTime FechaCorte { get; }
        public Operacion Operacion { get; }
    }
}