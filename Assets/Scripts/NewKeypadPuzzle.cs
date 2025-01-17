using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NewKeypadPuzzle : MonoBehaviour
{
    // if wire puzzel is solved activate display, and
    public GameObject withPower;

    public GameObject noPower;

    public void Update()
    {
        if (GameManager.Instance.solved_wirePuzzle >= 1 && noPower)
        {
            withPower.SetActive(true);
            noPower.SetActive(false);
        }
    }

}
