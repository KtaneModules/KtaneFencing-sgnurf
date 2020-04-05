using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Models;
using System;

namespace Assets.Fencing.Scripts.Rules
{
    internal class PisteSectionRulePart : IRulePart
    {
        private readonly PisteSection pisteSection;

        public string Description
        {
            get { return String.Format("Opponent action is {0}", pisteSection); }
        }

        public PisteSectionRulePart(PisteSection pisteSection)
        {
            this.pisteSection = pisteSection;
        }

        public bool ScenarioMatchesRulePart(Scenario scenario)
        {
            return scenario.PisteSection == pisteSection;
        }
    }
}