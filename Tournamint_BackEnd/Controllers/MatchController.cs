using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Models.DTO;

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

        /// <summary>
        /// Receives all game matches and filters them based on tournament id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("matches/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        public List<Match> GetMatchesByTournamentID(int id)
        {
            List<Match> matches = new List<Match> { };
            // [IMPORTANT] the part where it gets ALL matches so that it can filter them

            List<Match> filteredMatches = (List<Match>)(from m in matches
                                                        where m.TournamentId == id
                                                        select m);
            return filteredMatches;
        }

        /// <summary>
        /// Receives a list of game matches from database
        /// </summary>
        /// <returns></returns>
        [HttpGet("matches/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetMatchResult>))]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Receives a game match from database
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetMatchResult))]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Posts a game match to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post([FromBody]PostMatchRequest req)
        {
            return Created("", null);
        }

        /// <summary>
        /// Modifies a game match in database
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put(PutMatchRequest req)
        {
            return NoContent();
        }

        /// <summary>
        /// Delete a game match from database
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
