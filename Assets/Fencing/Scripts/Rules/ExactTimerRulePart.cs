using Assets.Fencing.Scripts.Models;
using Assets.Scripts;
using System;

namespace Assets.Fencing.Scripts.Rules
{
    internal class ExactTimerRulePart : IRulePart
    {
        private readonly TimeSpan timeToMatch;

        public string Description
        {
            get { return String.Format("Time matches exactly {0}.", timeToMatch.MinutesAndSecondsFormat()); }
        }

        public ExactTimerRulePart(TimeSpan timeToMatch)
        {
            this.timeToMatch = timeToMatch;
        }

        public bool ScenarioMatchesRulePart(Scenario scenario)
        {
            return scenario.MatchTimer == timeToMatch;
        }
    }
}