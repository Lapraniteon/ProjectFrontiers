using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The layer to target in the raycast.")]
    public string movementTargetLayer;

    [Space] [Tooltip("The time it takes to move to a new location.")]
    public float movementInterpolationTime;

    private LayerMask movementTargetLayerMask;
    private MovementTarget currentFocusedTarget;
    private MovementTarget previousFocusedTarget;

    private void Start()
    {
        movementTargetLayerMask = LayerMask.GetMask(movementTargetLayer);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.cameraIsLocked)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, ~0, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer(movementTargetLayer)) // Exit if the collider is not a movement target
                    return;
                
                if (currentFocusedTarget != null) // Check if a previous target exists
                    currentFocusedTarget.m_OnUnfocus.Invoke();
                
                MovementTarget thisHit = hit.transform.GetComponent<MovementTarget>(); // Get the current hit

                if (previousFocusedTarget != thisHit) // Hit a new target
                {
                    previousFocusedTarget = currentFocusedTarget; // Then the current target will be set as the previous target
                    
                    
                }
                
                if (currentFocusedTarget != null) // Current target exists
                    currentFocusedTarget.movementTargetCollider.enabled = true; // Then (re)-enable the current target
                
                currentFocusedTarget = thisHit; // Current focused target is our new hit
                if (currentFocusedTarget != null) // Current focused target exists
                {
                    currentFocusedTarget.movementTargetCollider.enabled = false; // Disable current movement target
                    Move(currentFocusedTarget.movementTargetData, currentFocusedTarget.m_OnFocus, currentFocusedTarget.applyCameraRotation); // Move
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (previousFocusedTarget == null || previousFocusedTarget == currentFocusedTarget)
                return;
            
            currentFocusedTarget.movementTargetCollider.enabled = true;
            currentFocusedTarget.m_OnUnfocus.Invoke();

            currentFocusedTarget = previousFocusedTarget;
            Move(currentFocusedTarget.movementTargetData, currentFocusedTarget.m_OnFocus, currentFocusedTarget.applyCameraRotation);
        }
    }

    private void Move(Transform targetTransform, UnityEvent onFocusEvent, bool applyCameraRotation = false)
    {
        GameManager.Instance.cameraIsLocked = currentFocusedTarget.lockCameraWhileFocused;
        
        StartCoroutine(MoveCoroutine(targetTransform, onFocusEvent, applyCameraRotation));
    }

    private IEnumerator MoveCoroutine(Transform targetTransform, UnityEvent onFocusEvent, bool applyCameraRotation = false)
    {
        Tween movementTween = transform.DOMove(targetTransform.position, movementInterpolationTime);
        
        if (applyCameraRotation)
            transform.DORotate(targetTransform.localEulerAngles, movementInterpolationTime);
        
        yield return movementTween.WaitForCompletion();
        
        onFocusEvent.Invoke();
    }
}
