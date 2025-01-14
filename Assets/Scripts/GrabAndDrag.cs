using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrag : MonoBehaviour
{
    private Vector3 _mousePosition;
    [Tooltip("The radius in which the player let go of the wire for it to snap")]
    public float tolerance;

    public Transform port;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        _mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }

    private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, port.position) <= tolerance)
        {
            Debug.Log("correct");
            transform.position = port.position;
        }
    }
}

