using Assets.Fencing.Scripts.Enums;
using System.Collections.Generic;

namespace Assets.Fencing.Scripts.Rules.Builder
{
    internal class RuleBuilder
    {
        private Rule rule = new Rule();
        private List<IRulePart> ruleParts = new List<IRulePart>();

        public RuleBuilder(string ruleName)
        {
            rule.Name = ruleName;
            rule.LastStage = true;
            rule.ruleParts = ruleParts;
        }

        public RuleBuilder WithRulePart(IRulePart rulePart)
        {
            ruleParts.Add(rulePart);
            return this;
        }

        public RuleBuilder WithSolution(params ActionKeys[] solutions)
        {
            rule.Solution = solutions;
            return this;
        }

        public RuleBuilder IsNotLastStage()
        {
            rule.LastStage = false;
            return this;
        }

        public RuleBuilder IsLastStage()
        {
            rule.LastStage = true;
            return this;
        }

        public Rule Build()
        {
            return rule;
        }
    }
}