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

    [Tooltip("the command when the subit button is pressed")]
    public void Submit()
    {
        StartCoroutine(SubmitCoroutine());
    }

    private IEnumerator SubmitCoroutine()
    {
        if (displayedCode.text == solution) // if the solution is correct the puzzel is solved otherwise it says error and resets the displayed code
        {
            notSolved.SetActive(false);
            GameManager.keypadPuzzelSolved = false;
            yield return null;
        }
        else
        {
            notSolved.SetActive(true);
            displayedCode.text = "ERROR";
            yield return new WaitForSeconds(1);
            displayedCode.text = "";
            yield return null;
        }
    }
}
