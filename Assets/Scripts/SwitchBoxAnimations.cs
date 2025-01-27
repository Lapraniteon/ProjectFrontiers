using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwitchBoxAnimations : MonoBehaviour
{

    public Transform doorPivot;
    public Transform switchPivot;

    public Light[] lights;
    
    public void AnimateDoor(bool goOpen)
    {
        Vector3 targetRotation = goOpen ? new Vector3(25f, 90f, 0f) : new Vector3(-80f, 90f, 0f);
        doorPivot.DOLocalRotate(targetRotation, .5f);
    }

    public void AnimateSwitch()
    {
        switchPivot.DOLocalRotate(new Vector3(25f, 0f, 0f), .35f).SetEase(Ease.InQuad);
    }

    public void TurnOnLights()
    {
        foreach (Light light in lights)
        {
            light.color = Color.white;
            light.intensity = 60f;
        }
    }
}
