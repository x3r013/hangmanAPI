using HangmanAPI.DbContexts;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private AppIndentityDbContext _dbContext;

        public ScoreController(ILogger<TestController> logger, AppIndentityDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<Score> Get()
        {
            var topScores = _dbContext.Scores.OrderByDescending(score => score.Difficulty).ThenBy(score => score.TimeToComplete).Take(10).ToList();
            return topScores;
        }

        [HttpPost]
        public void Post(ScoreSaveModel newScore)
        {
            _dbContext.Scores.Add(new Score
            {
                ScoreId = 0,
                Word = newScore.Word,
                Difficulty = newScore.Difficulty,
                TimeToComplete = newScore.TimeToComplete,
                Username = newScore.Username
            });
            _dbContext.SaveChanges();
        }
    }
}
