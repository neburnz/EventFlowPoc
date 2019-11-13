using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Queries;
using EventFlow.Specifications;

namespace poc.eventflow
{
    public class ExistsFechaCorteSpecification : Specification<DateTime>
    {
        public static ExistsFechaCorteSpecification Create(IQueryProcessor queryProcessor)
        {
            return new ExistsFechaCorteSpecification(queryProcessor);
        }
        private readonly IQueryProcessor _queryProcessor;
        private ExistsFechaCorteSpecification(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }
        protected override IEnumerable<string> IsNotSatisfiedBecause(DateTime obj)
        {
            var proceso = _queryProcessor.Process(new GetProcesoByFechaCorteQuery(obj), CancellationToken.None);
            if (proceso == null)
            {
                yield return $"No se ha encontrado información del Proceso para el {obj}";
            }
        }
    }
}