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

    public IsWirePuzzelSolved puzzel;

    public bool wiresConnected;

    void Start()
    {
        wiresConnected = false;
    }

    private Vector3 GetMousePos()    // returns the mouse position
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()    // gets the mouse position when left click is down
    {
        if (!puzzel.isFocused)
            return;
        
        _mousePosition = Input.mousePosition - GetMousePos();
        if (Vector3.Distance(transform.position, port.position) <= tolerance)
        {
            wiresConnected = false;
        }
    }


    private void OnMouseDrag()    // set game objects's position to mouse position
    {
        if (!puzzel.isFocused)
            return;
        
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }

    private void OnMouseUp()     // checks if the player has made placed the item to the right position
    {
        if (!puzzel.isFocused)
            return;
        
        if (Vector3.Distance(transform.position, port.position) <= tolerance)
        {
            transform.position = port.position;
            wiresConnected = true;
            puzzel.CheckSolution();
        }
    }
}
