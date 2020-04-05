using Assets.Fencing.Scripts.Enums;
using System;

namespace Assets.Fencing.Scripts.Rules.Builder
{
    internal static class RuleBuilderOpponentActionExtensions
    {
        public static RuleBuilder WithOpponentMoveRulePart(this RuleBuilder ruleBuilder, OpponentAction opponentAction)
        {
            return ruleBuilder.WithRulePart(new OpponentActionRulePart(opponentAction));
        }
    }
}