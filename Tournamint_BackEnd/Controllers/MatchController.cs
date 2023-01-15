using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        List<Match> matches = new List<Match> { };

        [HttpGet("matches/{id}")]
        public Match GetMatchesByTournamentID(int id)
        {
            return matches.FirstOrDefault(m => m.TournamentId == id);
        }
    }
}
