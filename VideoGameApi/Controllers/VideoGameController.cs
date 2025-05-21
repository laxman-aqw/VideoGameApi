using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame> {
        new VideoGame
        {
            Id = 1,
            Title = "Pubg",
            Platform = "Desktop",
            Developer="Tencent",
            Publisher = "Tencent"
        },        new VideoGame
        {
            Id = 2,
            Title = "Pubg Mobile",
            Platform = "Mobile",
            Developer="Tencent",
            Publisher = "Tencent"
        },        new VideoGame
        {
            Id =3,
            Title = "COC",
            Platform = "Mobile",
            Developer="Supercell",
            Publisher = "Supercell"
        }
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            var game = videoGames.FirstOrDefault(g=>g.Id==id);
            if(game is null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
        {
            if(newGame is null)
            {
                return BadRequest();
            }
            newGame.Id = videoGames.Max(g => g.Id) + 1;
            videoGames.Add(newGame);
            return CreatedAtAction(nameof(GetVideoGameById),new {id = newGame.Id},newGame);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVideoGame(int id, VideoGame updateGame)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if (game is null)
            {
                return BadRequest();
            }

            game.Title = updateGame.Title;
            game.Platform = updateGame.Platform;
            game.Publisher = updateGame.Publisher;
            game.Developer = updateGame.Developer;
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteVideoGame(int id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if(game is null)
            {
                return BadRequest();
            }

            videoGames.Remove(game);
            return NoContent();

        }
    }
}
