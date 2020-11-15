using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HangmanAPI.Models
{
    public class UserLoginResultModel
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }
}
