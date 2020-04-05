using Assets.Fencing.Scripts.Models;
using System;

namespace Assets.Fencing.Scripts.Rules
{
    internal class ExactOwnScoreRulePart : IRulePart
    {
        private readonly int score;

        public string Description
        {
            get { return String.Format("Own score is {0}", score); }
        }

        public ExactOwnScoreRulePart(int score)
        {
            this.score = score;
        }

        public bool ScenarioMatchesRulePart(Scenario scenario)
        {
            return scenario.OwnScore == score;
        }
    }
}