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

        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            var game = videoGames.FirstOrDefault(g=>g.Id==id);
            if(game is null)
            {
                return NotFound();
            }
            return Ok(game);
        }

    }
}
