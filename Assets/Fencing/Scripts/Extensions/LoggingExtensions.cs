using Assets.Fencing.Scripts.Models;
using Assets.Fencing.Scripts.Rules;
using Assets.Scripts;

namespace Assets.Fencing.Scripts.Extensions
{
    internal static class LoggingExtensions
    {
        public static void Log(this Scenario scenario, KMBombModule bomb)
        {
            bomb.Log("Scenario setup");
            bomb.LogFormat("Weapon: {0}", scenario.Weapon);
            bomb.LogFormat("Match Timer: {0}", scenario.MatchTimer.MinutesAndSecondsFormat());
            bomb.LogFormat("Score: {0}-{1}", scenario.OwnScore, scenario.OpponentScore);
            bomb.LogFormat("Opponent Action: {0}", scenario.OpponentAction);
            bomb.LogFormat("Piste Section: {0}", scenario.PisteSection);
        }

        public static void Log(this Rule rule, KMBombModule bomb)
        {
            bomb.LogFormat("Selected rule: {0}", rule.Name);
            bomb.Log("With the conditions");
            
            foreach (IRulePart rulePart in rule.ruleParts)
            {
                bomb.Log(rulePart.Description);
            }

            bomb.LogFormat("Expected Solution : {0}", rule.Solution.Join(","));
        }
    }
}