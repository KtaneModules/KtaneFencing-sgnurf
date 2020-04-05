using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Rules;
using Assets.Fencing.Scripts.Rules.Builder;

namespace Assets.Fencing.Scripts.RuleSets
{
    internal static class SabreRuleSet
    {
        public static Rule[] Rules = new Rule[]
        {
            new RuleBuilder("Sabre parry riposte")
                .WithOpponentMoveRulePart(OpponentAction.Forward)
                .WithSolution(ActionKeys.Parry, ActionKeys.HitHead)
                .Build(),

            new RuleBuilder("Sabre attack retreating and cornered opponent")
                .WithOpponentMoveRulePart(OpponentAction.Backward)
                .WithPisteSectionRulePart(PisteSection.Opponents2Metres) 
                .WithSolution(ActionKeys.Follow, ActionKeys.HitHead)
                .Build(),

            new RuleBuilder("Sabre attack retreating opponent")
                .WithOpponentMoveRulePart(OpponentAction.Backward)
                .WithSolution(ActionKeys.Follow, ActionKeys.HitHand)
                .Build(),

            new RuleBuilder("Sabre reflex parry riposte when parried")
                .WithOpponentMoveRulePart(OpponentAction.Parry)
                .WithSolution(ActionKeys.Parry, ActionKeys.HitHead)
                .Build(),

            new RuleBuilder("Sabre second intention parry riposte on static opponent")
                .WithOpponentMoveRulePart(OpponentAction.Static)
                .WithSolution(ActionKeys.HitHead, ActionKeys.Parry, ActionKeys.HitTorso)
                .Build(),
        };
    }
}