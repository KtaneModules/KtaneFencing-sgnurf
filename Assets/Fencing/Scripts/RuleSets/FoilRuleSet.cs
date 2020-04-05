using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Rules;
using Assets.Fencing.Scripts.Rules.Builder;

namespace Assets.Fencing.Scripts.RuleSets
{
    internal static class FoilRuleSet
    {
        public static Rule[] Rules = new Rule[]
        {
            new RuleBuilder("Foil parry riposte")
                .WithOpponentMoveRulePart(OpponentAction.Forward)
                .WithSolution(ActionKeys.Parry, ActionKeys.HitTorso)
                .Build(),

            new RuleBuilder("Foil Winning and playing the clock when opponent retreats")
                .WithOpponentMoveRulePart(OpponentAction.Backward)
                .WithWinningRulePart()
                .WithSolution(ActionKeys.Wait)
                .IsNotLastStage()
                .Build(),

            new RuleBuilder("Foil fleche on retreating enemy")
                .WithOpponentMoveRulePart(OpponentAction.Backward)
                .WithSolution(ActionKeys.Follow, ActionKeys.HitTorso)
                .Build(),

            new RuleBuilder("Foil waiting for riposte")
                .WithOpponentMoveRulePart(OpponentAction.Parry)
                .WithSolution(ActionKeys.Wait)
                .IsNotLastStage()
                .Build(),

            new RuleBuilder("Foil commposed attack on static enemy")
                .WithOpponentMoveRulePart(OpponentAction.Static)
                .WithSolution(ActionKeys.HitTorso, ActionKeys.HitTorso)
                .Build(),
        };
    }
}