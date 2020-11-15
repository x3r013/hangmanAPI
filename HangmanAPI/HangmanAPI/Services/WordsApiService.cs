using HangmanAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HangmanAPI.Services
{
    public class WordsApiService : IWordProvider
    {
        public async Task<string> GetWordEasyAsync()
        {
                return await Task.FromResult(await GetFromApi(3, 5));            
        }

        public async Task<string> GetWordMediumAsync()
        {
            return await Task.FromResult(await GetFromApi(6, 9));
        }

        public async Task<string> GetWordHardAsync()
        {
            return await Task.FromResult(await GetFromApi(10, 14));
        }

        private async Task<string> GetFromApi(int min, int max)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://wordsapiv1.p.rapidapi.com/words/?random=true&lettersmin={min}&lettersMax={max}"),
                Headers =
                    {
                        { "x-rapidapi-key", "29e4d4e73bmshf47ab0dc9129ea3p17f1d5jsn67c09050a5e2" },
                        { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" }
                    }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
