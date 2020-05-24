using Learning.DistributedTracing.Star.Api.Clients.War;
using Learning.DistributedTracing.Star.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Threading.Tasks;

namespace Learning.DistributedTracing.Star.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarController : ControllerBase
    {
        private readonly ILogger<StarController> _logger;
        private readonly IWarsAPI _warsAPI;

        public StarController(ILogger<StarController> logger, IWarsAPI warsAPI)
        {
            _logger = logger;
            _warsAPI = warsAPI;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]bool emitError = false)
        {
            try
            {
                _logger.LogInformation("Get Star Starting!");

                var result = await _warsAPI.GetWars(emitError);
                return new OkObjectResult(new StarModel(result.WarId, $"Star {result.Message}", DateTime.Now));
            }
            catch (ApiException ex)
            {
                _logger.LogCritical(ex, $"Api Exceptin {ex.Message} | Uri: {ex.RequestMessage.RequestUri} | Content: {ex.Content}");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                throw ex;
            }
            finally
            {
                _logger.LogInformation("Get Star Wards ended!");
            }
        }
    }
}
