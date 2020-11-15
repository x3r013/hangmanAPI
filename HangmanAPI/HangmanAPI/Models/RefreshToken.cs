using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HangmanAPI.Models
{
    public class RefreshToken
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }
        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
