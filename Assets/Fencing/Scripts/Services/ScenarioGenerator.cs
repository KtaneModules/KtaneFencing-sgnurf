using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Models;
using System;

using Random = UnityEngine.Random;

namespace Assets.Fencing.Scripts.Services
{
    internal class ScenarioGenerator
    {
        private static int MATCH_START_RATIO_WEIGHT = 1;
        private static int MATCH_WIN_RATIO_WEIGTH = 1;
        private static int MATCH_LOST_RATIO_WEIGTH = 1;
        private static int MATCH_ENDED_RATIO_WEIGTH = 1;
        private static int OTHER_RATIO_WEIGTH = 20;

        private WeigthedRandomSelector<Func<Scenario>> scenarioGeneratorPicker;

        private WeigthedRandomSelector<Func<Scenario>> ScenarioGeneratorPicker
        {
            get
            {
                if (scenarioGeneratorPicker == null)
                {
                    InitialiseScenarioPicker();
                }

                return scenarioGeneratorPicker;
            }
        }

        public Scenario GetScenario()
        {
            return ScenarioGeneratorPicker.GetRandom()();
        }

        public Scenario GetScenario(Scenario currentScenario)
        {
            return new Scenario
            {
                MatchTimer = TimeSpan.FromSeconds(Random.Range(0, (int)currentScenario.MatchTimer.TotalSeconds - 1)),
                OpponentAction = GetRandomOpponentAction(),
                OpponentScore = Random.Range(currentScenario.OpponentScore, 5),
                OwnScore = Random.Range(currentScenario.OwnScore, 6),
                PisteSection = GetRandomPisteSection(),
                Weapon = currentScenario.Weapon
            };
        }

        private void InitialiseScenarioPicker()
        {
            scenarioGeneratorPicker = new WeigthedRandomSelector<Func<Scenario>>();
            scenarioGeneratorPicker.Add(MATCH_START_RATIO_WEIGHT, GenerateMatchStartScenario);
            scenarioGeneratorPicker.Add(MATCH_WIN_RATIO_WEIGTH, GenerateMatchWinScenario);
            scenarioGeneratorPicker.Add(MATCH_LOST_RATIO_WEIGTH, GenerateMatchLostScenario);
            scenarioGeneratorPicker.Add(MATCH_ENDED_RATIO_WEIGTH, GenerateMatchEndedScenario);
            scenarioGeneratorPicker.Add(OTHER_RATIO_WEIGTH, GetDefaultScenarioGenerator);
        }

        private Scenario GenerateMatchStartScenario()
        {
            return GetRandomScenario(
                matchTimer: TimeSpan.FromMinutes(3),
                ownScore: 0,
                opponentScore: 0,
                pisteSection: PisteSection.Middle
            );
        }

        private Scenario GenerateMatchWinScenario()
        {
            return GetRandomScenario(
                ownScore: 5
            );
        }

        private Scenario GenerateMatchLostScenario()
        {
            return GetRandomScenario(
                opponentScore: 5
            );
        }

        private Scenario GenerateMatchEndedScenario()
        {
            return GetRandomScenario(
                matchTimer: TimeSpan.FromSeconds(0)
             );
        }

        private static Scenario GetDefaultScenarioGenerator()
        {
            return GetRandomScenario();
        }

        private static Scenario GetRandomScenario(
            TimeSpan? matchTimer = null,
            OpponentAction? opponentAction = null,
            int? opponentScore = null,
            int? ownScore = null,
            PisteSection? pisteSection = null,
            Weapon? weapon = null)
        {
            return new Scenario
            {
                MatchTimer = matchTimer ?? GetRandomNotEndingOrStartingMatchTime(),
                OpponentAction = opponentAction ?? GetRandomOpponentAction(),
                OpponentScore = opponentScore ?? GetRandomNonWinningScore(),
                OwnScore = ownScore ?? GetRandomNonWinningScore(),
                PisteSection = pisteSection ?? GetRandomPisteSection(),
                Weapon = weapon ?? GetRandomWeapon()
            };
        }

        private static Weapon GetRandomWeapon()
        {
            return (Weapon)Random.Range(0, 3);
        }

        private static OpponentAction GetRandomOpponentAction()
        {
            return (OpponentAction)Random.Range(0, 4);
        }

        private static TimeSpan GetRandomNotEndingOrStartingMatchTime()
        {
            return TimeSpan.FromSeconds(Random.Range(1, 3 * 60));
        }

        private static int GetRandomNonWinningScore()
        {
            return Random.Range(0, 5);
        }

        private static PisteSection GetRandomPisteSection()
        {
            return (PisteSection)Random.Range(0, 5);
        }
    }
}