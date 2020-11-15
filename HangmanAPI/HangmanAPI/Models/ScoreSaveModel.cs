using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanAPI.Models
{
    public class ScoreSaveModel
    {
        public string Word { get; set; }
        public int TimeToComplete { get; set; }
        public int Difficulty { get; set; }
        public string Username { get; set; }
    }
}
