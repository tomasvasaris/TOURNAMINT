using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ILogger<MatchController> _logger;

        public MatchController(ILogger<MatchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogCritical("Critical info from logger");
            _logger.LogError("Error  info from logger");
            _logger.LogWarning("Warning");

            _logger.LogInformation("Info from logger");
            _logger.LogDebug("Debug info from logger");
            _logger.LogTrace("Trace");

            return Ok();
        }





        List<Match> matches = new List<Match> { };

        [HttpGet("matches/{id}")]
        public Match GetMatchesByTournamentID(int id)
        {
            return matches.FirstOrDefault(m => m.TournamentId == id);
        }
    }
}
