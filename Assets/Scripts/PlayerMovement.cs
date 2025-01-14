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
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, movementTargetLayerMask, QueryTriggerInteraction.Collide))
            {
                Transform targetTransform = hit.transform.Find("MovementTargetData").transform;
                if (targetTransform != null)
                {
                    transform.position = targetTransform.position;
                    transform.localEulerAngles = targetTransform.localEulerAngles;
                }
            }
        }
    }
}
