using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckSolution : MonoBehaviour
{
    [Tooltip("Displayes the code the player has typed")]
    public TMP_Text displayedCode;

    [Tooltip("Solution to the keypad puzzel")]
    public string solution;

    // a button that symbolizes the puzzel is not complete
    public GameObject notSolved;

    public void Submit()
    {
        if (displayedCode.text == solution)
        {
            notSolved.SetActive(false);
            GameManager.keypadPuzzelSolved = false;
        }
        else
        {
            notSolved.SetActive(true);
            displayedCode.text = "";
        }
    }
}
