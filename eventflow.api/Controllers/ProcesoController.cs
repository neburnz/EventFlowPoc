using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using Microsoft.AspNetCore.Mvc;

namespace poc.eventflow.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        public ProcesoController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        // POST api/proceso/iniciar
        [HttpPost("iniciar")]
        public async Task<StatusCodeResult> Iniciar([FromBody] ProcesoData data)
        {
            var identity = ProcesoIdentity.New;
            
            var executionResult = await _commandBus.PublishAsync(
                new IniciarProcesoCommand(identity, data.FechaCorte),
                CancellationToken.None)
                .ConfigureAwait(false);

            return new OkResult();
        }
        // POST api/proceso/finalizar
        [HttpPost("finalizar")]
        public async Task<StatusCodeResult> Finalizar([FromBody] ProcesoData data)
        {
            var identity = ProcesoIdentity.New;
            
            var executionResult = await _commandBus.PublishAsync(
                new FinalizarProcesoCommand(identity),
                CancellationToken.None)
                .ConfigureAwait(false);

            return new OkResult();
        }
    }
}