using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Models;
using System;

namespace Assets.Fencing.Scripts.Rules
{
    internal class OpponentActionRulePart : IRulePart
    {
        private readonly OpponentAction opponentAction;

        public string Description
        {
            get { return String.Format("Opponent action is {0}", opponentAction); }
        }

        public OpponentActionRulePart(OpponentAction opponentAction)
        {
            this.opponentAction = opponentAction;
        }

        public bool ScenarioMatchesRulePart(Scenario scenario)
        {
            return scenario.OpponentAction == opponentAction;
        }
    }
}