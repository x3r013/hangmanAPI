using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        public string Word { get; set; }
        public int TimeToComplete { get; set; }
        public int Difficulty { get; set; }
        public string Username { get; set; }
    }
}
