using ATP.API.Repos;
using ATP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ATP.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayersController:Controller
    {
        // DI
        private readonly IPlayersRepository repository;
        public PlayersController(IPlayersRepository repo) { this.repository = repo; }

        [HttpGet]
        public async Task<ActionResult> GetPlayers()
        {
            try
            {
                return Ok(await repository.GetPlayers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            try
            {
                var response = await repository.GetPlayer(id);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Player>> UpdatePlayer(int id, Player player)
        {
            try
            {
                if (id != player.PlayerId)
                    return BadRequest();
                var playerToUpdate = await repository.GetPlayer(id);
                if (playerToUpdate == null)
                    return NotFound($"Player with id {id} is not found.");
                return Ok(await repository.UpdatePlayer(player));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }

        [HttpGet("/playersonone")]
        public async Task<ActionResult> GetPlayersOnOne()
        {
            try
            {
                return Ok(await repository.GetPlayersOnOne());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database error");
            }
        }
    }
}
