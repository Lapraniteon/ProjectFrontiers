using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CheckSolution : MonoBehaviour
{
    [Tooltip("Displayes the code the player has typed")]
    public TMP_Text displayedCode;

    [Tooltip("Solution to the keypad puzzel")]
    public string solution;

    // a button that symbolizes the puzzel is not complete
    public GameObject notSolved;

    public UnityEvent onSolved;

    public void Submit()
    {
        StartCoroutine(SubmitCoroutine());
    }


    public IEnumerator SubmitCoroutine()
    {
        if (displayedCode.text == solution)
        {
            notSolved.SetActive(false);
            GameManager.Instance.solved_keypadPuzzle = true;
            onSolved.Invoke();
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
