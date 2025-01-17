using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NewKeypadPuzzle : MonoBehaviour
{
    public bool isFocused;
    public bool hasPower;

    // if wire puzzel is solved activate display, and
    public GameObject withPower;

    public GameObject noPower;

    public void Update()
    {
        if (GameManager.Instance.solved_wirePuzzle >= 1 && !hasPower)
        {
            isFocused = true;
            hasPower = true;
            withPower.SetActive(true);
            noPower.SetActive(false);
        }
    }

    public void SetFocus(bool focus) => isFocused = focus;

    public void HasPower(bool power) => hasPower = power;

}
