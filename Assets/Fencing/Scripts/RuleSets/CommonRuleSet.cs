using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Rules;
using Assets.Fencing.Scripts.Rules.Builder;

namespace Assets.Fencing.Scripts.RuleSets
{
    internal static class CommonRuleSet
    {
        public static Rule[] Rules = new Rule[]
        {
            new RuleBuilder("Match Start")
                .WithExactTimerRulePart(3,0)
                .WithSolution(ActionKeys.Salute)
                .IsNotLastStage()
                .Build(),

            new RuleBuilder("Match End - Time Elapsed")
                .WithExactTimerRulePart(0,0)
                .WithSolution(ActionKeys.Salute)
                .Build(),

            new RuleBuilder("Victory")
                .WithExactOwnScoreRulePart(5)
                .WithSolution(ActionKeys.Salute)
                .Build(),

            new RuleBuilder("Defeat")
                .WithExactOpponentScoreRulePart(5)
                .WithSolution(ActionKeys.Salute)
                .Build(),
        };
    }
}