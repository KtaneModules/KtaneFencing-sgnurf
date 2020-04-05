using Assets.Fencing.Scripts.Models;
using System;

namespace Assets.Fencing.Scripts.Rules
{
    internal class ExactOpponentScoreRulePart : IRulePart
    {
        private readonly int score;

        public string Description
        {
            get { return String.Format("Opponent score is {0}", score); }
        }

        public ExactOpponentScoreRulePart(int score)
        {
            this.score = score;
        }

        public bool ScenarioMatchesRulePart(Scenario scenario)
        {
            return scenario.OpponentScore == score;
        }
    }
}