using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CheckSolution : MonoBehaviour
{
    private Vector3 _mousePosition;

    public NewKeypadPuzzle puzzle;

    [Tooltip("Displayes the code the player has typed")]
    public TMP_Text displayedCode;

    [Tooltip("Solution to the keypad puzzel")]
    public string solution;

    // a button that symbolizes the puzzel is not complete
    public GameObject notSolved;

    public UnityEvent m_OnSolved;

    private Vector3 GetMousePos()    // returns the mouse position
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()    // gets the mouse position when left click is down
    {
        if (!puzzle.isFocused || !puzzle.hasPower)
            return;

        _mousePosition = Input.mousePosition - GetMousePos();
        Submit();
    }

    public void Submit()
    {
        StartCoroutine(SubmitCoroutine());
    }


    public IEnumerator SubmitCoroutine()
    {
        if (displayedCode.text == solution)
        {
            notSolved.SetActive(false);
            GameManager.Instance.solved_keypadPuzzle++;
            m_OnSolved.Invoke();
            yield return null;
        }
        else
        {
            notSolved.SetActive(true);
            displayedCode.text = "error";
            yield return new WaitForSeconds(1);
            displayedCode.text = "";
            yield return null;
        }
    }
}
