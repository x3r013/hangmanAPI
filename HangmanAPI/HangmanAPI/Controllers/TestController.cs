using HangmanAPI.DbContexts;
using Microsoft.AspNetCore.Authorization;
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
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private AppIndentityDbContext _dbContext;
        private const string testString = "api test string response";
        public TestController(ILogger<TestController> logger, AppIndentityDbContext appIndentityDbContext)
        {
            _logger = logger;
            _dbContext = appIndentityDbContext;
        }

        [HttpGet]
        public string Get()
        {
            return testString;
        }
    }
}
