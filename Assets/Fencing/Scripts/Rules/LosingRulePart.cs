using Assets.Fencing.Scripts.Models;
using System;

namespace Assets.Fencing.Scripts.Rules
{
    internal class LosingRulePart : IRulePart
    {
        public string Description
        {
            get { return "Losing match"; }
        }

        public bool ScenarioMatchesRulePart(Scenario scenario)
        {
            return scenario.OwnScore < scenario.OpponentScore;
        }
    }
}