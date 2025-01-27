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

    private float _tempMousePositionX;

    void Start()
    {
        wiresConnected = false;
        _tempMousePositionX = transform.position.x;
    }

    private Vector3 GetMousePos()    // returns the mouse position
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()    // gets the mouse position when left click is down
    {
        _mousePosition = Input.mousePosition - GetMousePos();
        transform.position = new Vector3(_tempMousePositionX, transform.position.y, transform.position.z);
        if (Vector3.Distance(transform.position, port.position) <= tolerance)
        {
            wiresConnected = false;
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
            wiresConnected = true;
            Instantiate(puzzel.sparksParticles, transform.position, Quaternion.identity);
            puzzel.CheckSolution();
        }
    }
}
