using System;

namespace Assets.Fencing.Scripts.Rules.Builder
{
    internal static class RuleBuilderTimeExtensions
    {
        public static RuleBuilder WithExactTimerRulePart(this RuleBuilder ruleBuilder, int minutes, int seconds)
        {
            return ruleBuilder.WithRulePart(new ExactTimerRulePart(new TimeSpan(0, minutes, seconds)));
        }
    }
}