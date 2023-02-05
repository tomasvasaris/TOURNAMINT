using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Tournamint_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserMatchController : ControllerBase
    {
        private readonly IUserMatchRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserMatchController> _logger;
        public UserMatchController(IUserMatchRepository repository,
            IHttpContextAccessor httpContextAccessor,
            ILogger<UserMatchController> logger)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpGet("/api/user/{key}/Matches")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetUserMatchResponse>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get(int key)
        {
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != key)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {key} Matches", currentUserId, key);
                return Forbid();
            }
            var Matches = _repository.Get(key);
            // return Ok(Matches.Select(c => new GetUserMatchResponse(c)));
            throw new NotImplementedException();
        }
    }

    public class GetUserMatchResponse
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string IdCode { get; set; }

        public IList<GetUserMatchResponseMatch> Matches { get; set; }
    }

    public class GetUserMatchResponseMatch
    {
        public GetUserMatchResponseMatch(Match Match)
        {
            Id = Match.Id;
            TournamentId = Match.TournamentId;
            PlayerOneFirstName = Match.PlayerOneFirstName;
            PlayerOneLastName = Match.PlayerOneLastName;
            PlayerTwoFirstName = Match.PlayerTwoFirstName;
            PlayerTwoLastName = Match.PlayerTwoLastName;
            PlayerOneResult = Match.PlayerOneResult;
            PlayerTwoResult = Match.PlayerTwoResult;
        }

        public int Id { get; set; }
        public int TournamentId { get; set; }
        public string? PlayerOneFirstName { get; set; }
        public string? PlayerOneLastName { get; set; }
        public string? PlayerTwoFirstName { get; set; }
        public string? PlayerTwoLastName { get; set; }
        public string? PlayerOneResult { get; set; }
        public string? PlayerTwoResult { get; set; }
    }
}
