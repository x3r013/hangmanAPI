using HangmanAPI.DbContexts;
using HangmanAPI.Interfaces;
using HangmanAPI.Managers;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private AppIndentityDbContext _dbContext;
        private UserManager<User> _userManager;
        private IJwtAuthManager _jwtManager;
        public LoginController(ILogger<TestController> logger, AppIndentityDbContext appIndentityDbContext, UserManager<User> userManager, IJwtAuthManager jwtManager)
        {
            _logger = logger;
            _dbContext = appIndentityDbContext;
            _userManager = userManager;
            _jwtManager = jwtManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserLoginModel loginUser)
        {
            if (loginUser != null) {
                var existingUser = await _userManager.FindByNameAsync(loginUser.UserName);
                var passwordMatch = _userManager.PasswordHasher.VerifyHashedPassword(existingUser, existingUser.PasswordHash, loginUser.Password);

                if (existingUser != null && passwordMatch.Equals(PasswordVerificationResult.Success)) {
                    var claims = new[] { 
                        new Claim(ClaimTypes.Name, loginUser.UserName) 
                    };
                    var jwtResult = _jwtManager.GenerateTokens(loginUser.UserName, claims, DateTime.Now);
                    return new OkObjectResult(new UserLoginResultModel { 
                        UserName = loginUser.UserName,
                        AccessToken = jwtResult.AccessToken
                    });
                }
            }
            return new UnauthorizedObjectResult("Incorrect login credentials.");
        }
    }
}
