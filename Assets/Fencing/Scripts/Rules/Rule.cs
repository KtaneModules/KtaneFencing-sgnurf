using Assets.Fencing.Scripts.Enums;
using System.Collections.Generic;

namespace Assets.Fencing.Scripts.Rules
{
    internal class Rule
    {
        public ActionKeys[] Solution;

        public IEnumerable<IRulePart> ruleParts;

        public string Name;

        public bool LastStage;
    }
}