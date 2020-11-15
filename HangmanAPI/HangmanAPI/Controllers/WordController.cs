using HangmanAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        private IWordProvider _wordProvider;
        
        public WordController(IWordProvider wordProvider)
        {
            _wordProvider = wordProvider;
        }

        [HttpGet]
        [Authorize]
        [Route("GetEasy")]
        public async Task<IActionResult> GetEasy()
        {
            var word = await _wordProvider.GetWordEasyAsync();

            if (word != null) {
                return new OkObjectResult(word);
            }
            return new NotFoundObjectResult("No word could be found.");
        }

        [HttpGet]
        [Authorize]
        [Route("GetMedium")]
        public async Task<IActionResult> GetMedium()
        {
            var word = await _wordProvider.GetWordMediumAsync();

            if (word != null)
            {
                return new OkObjectResult(word);
            }
            return new NotFoundObjectResult("No word could be found.");
        }

        [HttpGet]
        [Authorize]
        [Route("GetHard")]
        public async Task<IActionResult> GetHard()
        {
            var word = await _wordProvider.GetWordHardAsync();

            if (word != null)
            {
                return new OkObjectResult(word);
            }
            return new NotFoundObjectResult("No word could be found.");
        }
    }
}
