using ResultCheckerBwaApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultCheckerBwaApp.Server.Controllers
{
    [Authorize(Roles = "Gamers")]
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private static readonly string[] Options = new[]
        {
            "Rock", "Paper", "Scissors"
        };        

        private readonly ILogger<WeatherForecastController> _logger;

        public GamesController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Game
            {
                Date = DateTime.Now.AddMinutes(index).AddSeconds(index * rng.NextDouble()),
                Player1 = Options[rng.Next(0, 3)],
                Player2 = Options[rng.Next(0, 3)],                
            })
            .ToArray();
        }
    }
}
