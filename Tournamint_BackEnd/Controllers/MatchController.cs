using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Models.DTO;
using Tournamint_BackEnd.Repositories;
using Tournamint_BackEnd.Services;

namespace Tournamint_BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ILogger<MatchController> _logger;
        private readonly IMatchRepository _repository;
        private readonly IMatchAdapter _adapter;

        public MatchController(ILogger<MatchController> logger, 
            IMatchRepository repository,
            IMatchAdapter adapter)
        {
            _logger = logger;
            _repository = repository;
            _adapter = adapter;
        }


        /// <summary>
        /// Receives all game matches and filters them based on tournament id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("matches/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetMatchResult>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult GetMatchesByTournamentID(int id)
        {
            var entities = _repository.All();
            var model = entities.Select(x => _adapter.Bind(x).TournamentId == id);

            return Ok(model);
        }

        /// <summary>
        /// Receives a list of game matches from database
        /// </summary>
        /// <returns></returns>
        [HttpGet("matches/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetMatchResult>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get()
        {
            var entities = _repository.All();
            var model = entities.Select(x => _adapter.Bind(x));

            return Ok(model);
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
            if (!_repository.Exists(id))
                return NotFound();

            var entity = _repository.Get(id);
            var model = _adapter.Bind(entity);

            return Ok(model);
        }

        /// <summary>
        /// Posts a game match to database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post([FromBody]PostMatchRequest req)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var entity = _adapter.Bind(req);
            var id = _repository.Create(entity);

            return Created("PostMatch", new { Id = id });
        }

        /// <summary>
        /// Modifies a game match in database
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put(PutMatchRequest req)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            if (!_repository.Exists(req.MatchId))
            {
                _logger.LogInformation("Car with id {id} not found", req.MatchId);
                return NotFound();
            }

            var entity = _adapter.Bind(req);
            _repository.Update(entity);

            return NoContent();
        }

        /// <summary>
        /// Delete a game match from database
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Delete(int id)
        {
            if (!_repository.Exists(id))
            {
                _logger.LogInformation("Car with id {id} not found", id);
                return NotFound();
            }
            var entity = _repository.Get(id);
            _repository.Remove(entity);

            return NoContent();
        }
    }
}
