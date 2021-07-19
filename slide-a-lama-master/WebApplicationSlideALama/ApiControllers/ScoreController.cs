using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SlideLama.Entity;
using SlideLama.Service;
using SlideLama.SlideALamaCore.Service.ScoreService;

namespace WebApplicationSlideALama.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class ScoreController : Controller
    {
        private readonly IScoreService scoreService = new ScoreServiceEF();

        // GET: api/Score
        [HttpGet]
        public IEnumerable<Score> Get()
        {
            return scoreService.GetTopScores();
        }

        // POST: api/Score
        [HttpPost]
        public void Post([FromBody]Score score)
        {
            scoreService.AddScore(score);
        }
    }
}