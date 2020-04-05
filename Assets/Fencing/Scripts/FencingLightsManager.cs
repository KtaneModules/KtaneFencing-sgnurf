using Assets.Fencing.Scripts.Enums;
using Assets.Fencing.Scripts.Models;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

//TODO: Refactor to more fine-grained rules. Matbe re_use teh rule engine when genericised
public class FencingLightsManager : MonoBehaviour
{
    public int FlashDuration = 2;
    public MaterialStore materialStore;
    public GameObject OwnOffTarget;
    public GameObject OwnOnTarget;
    public GameObject OpponentOffTarget;
    public GameObject OpponentOnTarget;

    public void HandleButtonPress(
        ActionKeys pressedButton,
        Scenario scenario
    )
    {
        HandleOwnLights(pressedButton, scenario);
    }

    private void HandleOwnLights(ActionKeys pressedButton, Scenario scenario)
    {
        if (pressedButton == ActionKeys.Follow
            || pressedButton == ActionKeys.Parry
            || pressedButton == ActionKeys.Salute
            || pressedButton == ActionKeys.Wait)
        {
            return;
        }

        if (scenario.Weapon == Weapon.Foil
            && (pressedButton == ActionKeys.HitHand
                || pressedButton == ActionKeys.HitHead))
        {
            FlashOfftarget(OwnOffTarget);
        }
        else
        {
            FlashRed();
        }
    }

    private void HandleOpponentLights(ActionKeys pressedButton, Scenario scenario)
    {
        if (scenario.OpponentAction != OpponentAction.Forward
            || Random.Range(0, 100) < 80)
        {
            return;
        }

        if (scenario.Weapon == Weapon.Foil
            && Random.Range(0, 100) < 60)
        {
            FlashOfftarget(OpponentOffTarget);
        }
        else
        {
            FlashGreen();
        }
    }

    private void FlashOfftarget(GameObject objectToFlash)
    {
        StartCoroutine(Flash(objectToFlash, materialStore.OffTargetLit));
    }

    private void FlashRed()
    {
        StartCoroutine(Flash(OwnOnTarget, materialStore.RedLightLit));
    }

    private void FlashGreen()
    {
        StartCoroutine(Flash(OpponentOnTarget, materialStore.GreenLightLit));
    }

    private IEnumerator Flash(GameObject gameObject, Material flashMaterial)
    {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        Material initialMaterial = renderer.material;

        renderer.material = flashMaterial;
        yield return new WaitForSeconds(FlashDuration);
        renderer.material = initialMaterial;
    }
}