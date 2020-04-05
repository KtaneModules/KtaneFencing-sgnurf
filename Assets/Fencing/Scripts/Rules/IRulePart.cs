using Assets.Fencing.Scripts.Models;

namespace Assets.Fencing.Scripts.Rules
{
    //TODO: Change to IRulePart<T> and make the whole rule system generic
    internal interface IRulePart
    {
        bool ScenarioMatchesRulePart(Scenario scenario);

        string Description { get; }
    }
}