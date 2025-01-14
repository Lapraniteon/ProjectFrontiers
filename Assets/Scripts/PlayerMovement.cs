using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The layer to target in the raycast.")]
    public string movementTargetLayer;

    [Space] [Tooltip("The time it takes to move to a new location.")]
    public float movementInterpolationTime;

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
                    transform.DOMove(targetTransform.position, movementInterpolationTime);
                    transform.DORotate(targetTransform.localEulerAngles, movementInterpolationTime);
                }
            }
        }
    }
}
