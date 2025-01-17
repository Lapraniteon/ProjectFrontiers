using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewKeypadButton : MonoBehaviour
{
    private Vector3 _mousePosition;

    [Tooltip("Displayes the code the player has typed")]
    public TMP_Text displayedCode;

    private string tempString;
    private char[] tempCharArray;

    private Vector3 GetMousePos()    // returns the mouse position
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()    // gets the mouse position when left click is down
    {
        _mousePosition = Input.mousePosition - GetMousePos();
        if (gameObject.name == "Restart Button")
        {
            displayedCode.text = "____";
        } else
        {
            tempString = displayedCode.ToString();
            tempCharArray = tempString.ToCharArray();
            for (int i = 0; i < displayedCode.text.Length - 1; i++)
            {
                if (displayedCode.text[i] == '_')
                {
                    tempCharArray[i] = gameObject.name[6];
                    break;
                }
            }
            displayedCode.text = tempString;
        }
    }
}
