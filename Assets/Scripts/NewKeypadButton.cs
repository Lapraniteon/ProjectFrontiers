using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewKeypadButton : MonoBehaviour
{
    private Vector3 _mousePosition;

    [Tooltip("Displayes the code the player has typed")]
    public TMP_Text displayedCode;

    private Vector3 GetMousePos()    // returns the mouse position
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()    // gets the mouse position when left click is down
    {
        _mousePosition = Input.mousePosition - GetMousePos();
        if (gameObject.name == "Restart Button")
        {
            displayedCode.text = "";
        } else
        {
            if(displayedCode.text.Length < 4)
                displayedCode.text += gameObject.name[6];
        }
    }
}
