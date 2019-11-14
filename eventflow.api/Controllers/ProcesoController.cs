using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Queries;
using EventFlow.Extensions;
using Microsoft.AspNetCore.Mvc;
using EventFlow.Exceptions;
using Microsoft.AspNetCore.Http;

namespace poc.eventflow.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;
        public ProcesoController(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }
        // POST api/proceso/iniciar
        [HttpPost("iniciar")]
        public async Task<StatusCodeResult> Iniciar([FromBody] ProcesoData data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var specification = ExistsFechaCorteSpecification.Create(_queryProcessor).Not();
                    specification.ThrowDomainErrorIfNotSatisfied(data.FechaCorte);
                }
                catch (DomainError)
                {
                    // TODO: Al haber duplicados se debe loguear un WARN aunque el status code sea un HTTP 200
                    return new OkResult();
                }
                var identity = ProcesoId.New;
                var executionResult = await _commandBus.PublishAsync(
                    new IniciarProcesoCommand(identity, data.FechaCorte),
                    CancellationToken.None)
                    .ConfigureAwait(false);
            }
            return new OkResult();
        }
        // POST api/proceso/finalizar
        [HttpPost("finalizar")]
        public async Task<StatusCodeResult> Finalizar([FromBody] ProcesoData data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var proceso = await _queryProcessor.ProcessAsync(new GetProcesoByFechaCorteQuery(data.FechaCorte), CancellationToken.None);
                    var identity = new ProcesoId(proceso.Id);
                    var executionResult = await _commandBus.PublishAsync(
                        new FinalizarProcesoCommand(identity),
                        CancellationToken.None)
                        .ConfigureAwait(false);
                }
                catch (DuplicateOperationException)
                {
                    // TODO: Al haber duplicados se debe loguear un WARN aunque el status code sea un HTTP 200
                    return new OkResult();
                }
                catch (Exception)
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }

            }
            return new OkResult();
        }
    }
}