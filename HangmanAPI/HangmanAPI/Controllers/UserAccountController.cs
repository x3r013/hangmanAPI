using HangmanAPI.DbContexts;
using HangmanAPI.Models;
using Microsoft.AspNetCore.Identity;
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
    public class UserAccountController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private AppIndentityDbContext _dbContext;
        private UserManager<User> _userManager;
        public UserAccountController(ILogger<TestController> logger, AppIndentityDbContext appIndentityDbContext, UserManager<User> userManager)
        {
            _logger = logger;
            _dbContext = appIndentityDbContext;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRegisterModel newUser)
        {
            if (newUser != null) {
                var existingUser = await _userManager.FindByNameAsync(newUser.UserName);
                if(existingUser == null)
                {
                    await _userManager.CreateAsync(new User
                    {
                        FirstName = newUser.FirstName,
                        LastName = newUser.LastName,
                        UserName = newUser.UserName,
                        Email = newUser.Email,
                        Level = 1,
                        JoinDate = DateTime.Now
                    }, newUser.Password);
                    return new OkObjectResult("Account created.");
                }                
            }
            return new BadRequestObjectResult("Account could not be created.");
        }
    }
}
