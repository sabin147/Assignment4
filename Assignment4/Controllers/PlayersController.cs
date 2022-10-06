using Assignment1;
using Assignment4.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<FootballPlayer>> GetAll()
        {
            IEnumerable<FootballPlayer> playerList = _manager.GetAll();
            if (playerList.Count() == 0)
            {
                return NotFound();
            }
            return Ok(playerList);
        }
        [HttpGet]
        [Route("{id}")]

        public FootballPlayer? Get(int id)
        {
            return _manager.GetById(id);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer newPlayer)
        {
            try
            {
                FootballPlayer createdPlayer = _manager.Add(newPlayer);
                return Created("api/players/" + createdPlayer.Id, createdPlayer);
            }
            catch (Exception ex)
          when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]

        public FootballPlayer? Put(int id, [FromBody] FootballPlayer updates)
        {
            return _manager.Update(id, updates);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]

        public FootballPlayer? Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
