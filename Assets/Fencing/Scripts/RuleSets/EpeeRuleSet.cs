using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Rules;
using Assets.Fencing.Scripts.Rules.Builder;

namespace Assets.Fencing.Scripts.RuleSets
{
    internal static class EpeeRuleSet
    {
        public static Rule[] Rules = new Rule[]
        {
            new RuleBuilder("Epee counter attack to hand when losing")
                .WithOpponentMoveRulePart(OpponentAction.Forward)
                .WithLosingRulePart()
                .WithSolution(ActionKeys.HitHand)
                .Build(),

            new RuleBuilder("Epee counter attack to hand on a tie")
               .WithOpponentMoveRulePart(OpponentAction.Forward)
                .WithTieRulePart()
                .WithSolution(ActionKeys.HitHand)
                .Build(),

            new RuleBuilder("Epee looking for double when winning and cornered")
                .WithOpponentMoveRulePart(OpponentAction.Forward)
                .WithWinningRulePart()
                .WithPisteSectionRulePart(PisteSection.Own2Metres)
                .WithSolution(ActionKeys.HitTorso)
                .Build(),

            new RuleBuilder("Epee evading when winning playing the clock when winning")
                .WithOpponentMoveRulePart(OpponentAction.Forward)
                .WithWinningRulePart()
                .WithSolution(ActionKeys.Follow)
                .IsNotLastStage()
                .Build(),

            new RuleBuilder("Epee attacking cornered opponent")
                .WithOpponentMoveRulePart(OpponentAction.Backward)
                .WithPisteSectionRulePart(PisteSection.Opponents2Metres)
                .WithSolution(ActionKeys.HitHead)
                .Build(),

            new RuleBuilder("Epee following retreating opponent")
                .WithOpponentMoveRulePart(OpponentAction.Backward)
                .WithSolution(ActionKeys.Follow)
                .IsNotLastStage()
                .Build(),

            new RuleBuilder("Epee remise on cornered opponent")
                .WithOpponentMoveRulePart(OpponentAction.Parry)
                .WithPisteSectionRulePart(PisteSection.Opponents2Metres)
                .WithSolution(ActionKeys.HitTorso)
                .Build(),

            new RuleBuilder("Epee waiting opponent riposte")
                .WithOpponentMoveRulePart(OpponentAction.Parry)
                .WithSolution(ActionKeys.Wait)
                .IsNotLastStage()
                .Build(),

            new RuleBuilder("Epee winning and playing the clock against inactive opponent")
                .WithOpponentMoveRulePart(OpponentAction.Static)
                .WithWinningRulePart()
                .WithSolution(ActionKeys.Wait)
                .IsNotLastStage()
                .Build(),

            new RuleBuilder("Epee wrist hit")
                .WithSolution(ActionKeys.HitHand)
                .Build(),
        };
    }
}