using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _mousePosition;
    [Tooltip("The radius in which the player let go of the wire for it to snap")]
    public float tolerance;
    [Tooltip("The position in which this game object needs to be at")]
    public Transform port;

    public static int numberOfWiresConnected;

    void Start()
    {
        numberOfWiresConnected = 0;
    }

    private Vector3 GetMousePos()    // returns the mouse position
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()    // gets the mouse position when left click is down
    {
        _mousePosition = Input.mousePosition - GetMousePos();
        if (Vector3.Distance(transform.position, port.position) <= tolerance)
        {
            numberOfWiresConnected--;
        }
    }


    private void OnMouseDrag()    // set game objects's position to mouse position
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }

    private void OnMouseUp()     // checks if the player has made placed the item to the right position
    {
        if (Vector3.Distance(transform.position, port.position) <= tolerance)
        {
            transform.position = port.position;
            numberOfWiresConnected++;
            if (numberOfWiresConnected == 4)
            {
                Debug.Log("wire puzzel solved");
            }
        }
    }
}
