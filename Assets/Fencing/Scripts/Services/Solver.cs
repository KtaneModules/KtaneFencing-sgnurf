using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Models;
using Assets.Fencing.Scripts.Rules;
using Assets.Fencing.Scripts.RuleSets;
using System.Linq;

namespace Assets.Fencing.Scripts.Services
{
    internal class Solver
    {
        public Rule Solve(Scenario scenario)
        {
            Rule matchedCommonRule = GetMatchedRule(CommonRuleSet.Rules, scenario);

            if (matchedCommonRule != null)
            {
                return matchedCommonRule;
            }

            Rule[] weaponRuleSet = GetWeaponRuleSet(scenario);

            return GetMatchedRule(weaponRuleSet, scenario);
        }

        private static Rule[] GetWeaponRuleSet(Scenario scenario)
        {
            switch (scenario.Weapon)
            {
                case Weapon.Epee:
                default:
                    return EpeeRuleSet.Rules;

                case Weapon.Foil:
                    return FoilRuleSet.Rules;

                case Weapon.Sabre:
                    return SabreRuleSet.Rules;
            }
        }

        private static Rule GetMatchedRule(Rule[] rules, Scenario scenario)
        {
            return rules.FirstOrDefault((Rule r) =>
                r.ruleParts.All(rulePart =>
                    rulePart.ScenarioMatchesRulePart(scenario)));
        }
    }
}