using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;
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
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, ~0, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer(movementTargetLayer))
                    return;
                
                if (currentFocusedTarget != null)
                    currentFocusedTarget.m_OnUnfocus.Invoke();
                
                MovementTarget thisHit = hit.transform.GetComponent<MovementTarget>();
                
                if (previousFocusedTarget != thisHit)
                    previousFocusedTarget = currentFocusedTarget;
                
                currentFocusedTarget = thisHit;
                if (currentFocusedTarget != null)
                {
                    currentFocusedTarget.movementTargetCollider.enabled = false;
                    Move(currentFocusedTarget.movementTargetData, currentFocusedTarget.m_OnFocus, currentFocusedTarget.applyCameraRotation);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            currentFocusedTarget.movementTargetCollider.enabled = true;
            currentFocusedTarget.m_OnUnfocus.Invoke();
            
            if (previousFocusedTarget == null)
                return;

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
