using Assets.Fencing.Scripts.Enums;
using System;

namespace Assets.Fencing.Scripts.Models
{
    public class Scenario
    {
        public TimeSpan MatchTimer { get; set; }
        
        public Weapon Weapon { get; set; }

        public PisteSection PisteSection { get; set; }

        public int OwnScore { get; set; }

        public int OpponentScore { get; set; }

        public OpponentAction OpponentAction { get; set; }
    }
}