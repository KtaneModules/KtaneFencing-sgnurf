using Assets.Fencing.Scripts.Enums;

namespace Assets.Fencing.Scripts.Rules.Builder
{
    internal static class RuleBuilderPisteSectionExtensions
    {
        public static RuleBuilder WithPisteSectionRulePart(this RuleBuilder ruleBuilder, PisteSection pisteSection)
        {
            return ruleBuilder.WithRulePart(new PisteSectionRulePart(pisteSection));
        }
    }
}