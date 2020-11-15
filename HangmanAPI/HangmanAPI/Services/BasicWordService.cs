using HangmanAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Services
{
    public class BasicWordService:IWordProvider
    {
        private string[] EasyWords = {"hand","foot","card","ant","jar"};
        private string[] MediumWords = { "artist", "wooden", "others", "Before", "object" };
        private string[] HardWords = { "ventriloquist", "definition", "capability", "representative", "inhabitants" };

        public Task<string> GetWordEasyAsync()
        {
            Random rand = new Random();
            int index = rand.Next(EasyWords.Length);
            return Task.FromResult(EasyWords[index]);
        }
        public Task<string> GetWordMediumAsync()
        {
            Random rand = new Random();
            int index = rand.Next(MediumWords.Length);
            return Task.FromResult(MediumWords[index]);
        }
        public Task<string> GetWordHardAsync()
        {
            Random rand = new Random();
            int index = rand.Next(HardWords.Length);
            return Task.FromResult(HardWords[index]);
        }
    }
}
