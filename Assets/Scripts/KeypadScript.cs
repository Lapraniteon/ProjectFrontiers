using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadScript : MonoBehaviour
{
    [Tooltip("Displayes the code the player has typed")]
    public TMP_Text displayedCode;
    [Tooltip("Number on the keypad")]
    public char c;

    public void AddDigit()   // adds a digit to the end of the displayed code
    {
        if (displayedCode.text.Length < 8)
            displayedCode.text += c;
    }

    public void Restart()    // empties out the displayed code
    {
        displayedCode.text = "";
    }
}
