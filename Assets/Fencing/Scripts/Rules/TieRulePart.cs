using Assets.Fencing.Scripts.Models;
using System;

namespace Assets.Fencing.Scripts.Rules
{
    internal class TieRulePart : IRulePart
    {
        public string Description
        {
            get { return "Winning match"; }
        }

        public bool ScenarioMatchesRulePart(Scenario scenario)
        {
            return scenario.OwnScore == scenario.OpponentScore;
        }
    }
}