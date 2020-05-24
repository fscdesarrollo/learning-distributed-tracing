using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenTracing;
using OpenTracing.Tag;
using System;
using System.Threading.Tasks;

namespace Learning.DistributedTracing.Wars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarsController : ControllerBase
    {
        
        private readonly ILogger<WarsController> _logger;
        private readonly ITracer _tracer;

        public WarsController(ILogger<WarsController> logger, ITracer tracer)
        {
            _logger = logger;
            _tracer = tracer;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]bool emitError)
        {
            var span = _tracer.ActiveSpan;

            try
            {
                _logger.LogInformation("Get War Starting!");

                if (emitError)
                {
                    throw new ApplicationException("Houston, we have an error!!");
                }

                return await Task.Run(() => new OkObjectResult(new WarModel(Guid.NewGuid(), "Wars", DateTime.Now)));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                Tags.Error.Set(span, true);
                span.SetTag("unhandled_error", true);
                span.SetTag("unhandled_error.message", ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Get War ended!");
            }
        }
            
    }
}
