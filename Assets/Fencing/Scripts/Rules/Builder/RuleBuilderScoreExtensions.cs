namespace Assets.Fencing.Scripts.Rules.Builder
{
    internal static class RuleBuilderScoreExtensions
    {
        public static RuleBuilder WithExactOwnScoreRulePart(this RuleBuilder ruleBuilder, int score)
        {
            return ruleBuilder.WithRulePart(new ExactOwnScoreRulePart(score));
        }

        public static RuleBuilder WithExactOpponentScoreRulePart(this RuleBuilder ruleBuilder, int score)
        {
            return ruleBuilder.WithRulePart(new ExactOpponentScoreRulePart(score));
        }

        public static RuleBuilder WithWinningRulePart(this RuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithRulePart(new WinningRulePart());
        }

        public static RuleBuilder WithLosingRulePart(this RuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithRulePart(new LosingRulePart());
        }

        public static RuleBuilder WithTieRulePart(this RuleBuilder ruleBuilder)
        {
            return ruleBuilder.WithRulePart(new TieRulePart());
        }
    }
}