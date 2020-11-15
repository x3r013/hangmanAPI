using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Interfaces
{
    public interface IWordProvider
    {
        Task<string> GetWordEasyAsync();
        Task<string> GetWordMediumAsync();
        Task<string> GetWordHardAsync();
    }
}
