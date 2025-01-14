using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The layer to target in the raycast.")]
    public string movementTargetLayer;

    private LayerMask movementTargetLayerMask;

    private void Start()
    {
        movementTargetLayerMask = LayerMask.GetMask(movementTargetLayer);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, movementTargetLayerMask))
            {
                Debug.Log("hit!");
            }
            else
                Debug.Log("no hit");
        }
    }
}
