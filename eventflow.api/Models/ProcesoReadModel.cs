using System;
using System.ComponentModel.DataAnnotations;
using EventFlow.Aggregates;
using EventFlow.ReadStores;

namespace poc.eventflow
{
    public class ProcesoReadModel : IReadModel,
        IAmReadModelFor<ProcesoAggregate, ProcesoId, ProcesamientoIniciadoEvent>,
        IAmReadModelFor<ProcesoAggregate, ProcesoId, ProcesamientoFinalizadoEvent>
    {
        [Key]
        public string Id { get; protected set; }
        [ConcurrencyCheck]
        public long Version { get; set; }
        public DateTime FechaCorte { get; set; }
        public Operacion Operacion { get; set; }
        public void Apply(IReadModelContext context,
            IDomainEvent<ProcesoAggregate, ProcesoId, ProcesamientoIniciadoEvent> domainEvent)
        {
            FechaCorte = domainEvent.AggregateEvent.FechaCorte;
            Operacion = domainEvent.AggregateEvent.Operacion;
        }
        public void Apply(IReadModelContext context,
            IDomainEvent<ProcesoAggregate, ProcesoId, ProcesamientoFinalizadoEvent> domainEvent)
        {
            Operacion = domainEvent.AggregateEvent.Operacion;
        }
    }
}