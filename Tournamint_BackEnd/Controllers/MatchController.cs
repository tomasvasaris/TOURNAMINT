using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Models.Dto;
using Tournamint_BackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Tournamint_BackEnd.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Tournamint_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
        /// Get all matches from database
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetMatchResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get(int id)
        {
            if (!_repository.Exist(id))
            {
                _logger.LogInformation("Match with id {id} not found",id);
                return NotFound();
            }
            
            var entity = _repository.Get(id);
            var model = _adapter.Bind(entity);

            return Ok(model);
        }

        /// <summary>
        /// Get all or filtered matches by tournamentId from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetMatchResult>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get([FromQuery]FilterMatchRequest req)
        {
            _logger.LogInformation("Getting Match list with parameters {req}", JsonConvert.SerializeObject(req));

            IEnumerable<Match> entities = _repository.All().ToList();

            if (req.TournamentId != null)
                entities = entities.Where(x => x.TournamentId == req.TournamentId);

            var model = entities?.Select(x => _adapter.Bind(x));
            
            return Ok(model);
        }

        /// <summary>
        /// Post match to database
        /// </summary>
        /// <returns></returns>
        /// <response code="400">Validation no bueno</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post(PostMatchRequest req)
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
        /// Modify match in database
        /// </summary>
        /// <returns></returns>
        /// <response code="400">Validation no bueno</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put(PutMatchRequest req)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            if (!_repository.Exist(req.Id))
            {
                _logger.LogInformation("Match with id {id} not found", req.Id);
                return NotFound();
            }

            var entity = _adapter.Bind(req);
           _repository.Update(entity);

            return NoContent();
        }

        /// <summary>
        /// Delete match from database
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (!_repository.Exist(id))
            {
                _logger.LogInformation("Match with id {id} not found", id);
                return NotFound();
            }
            var entity = _repository.Get(id);
            _repository.Remove(entity);

            return NoContent();
        }
    }
}