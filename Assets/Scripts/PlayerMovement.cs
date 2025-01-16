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
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, movementTargetLayerMask, QueryTriggerInteraction.Collide))
            {
                if (currentFocusedTarget != null)
                    currentFocusedTarget.m_OnUnfocus.Invoke();
                
                previousFocusedTarget = currentFocusedTarget;
                currentFocusedTarget = hit.transform.GetComponent<MovementTarget>();
                if (currentFocusedTarget != null)
                {
                    Move(currentFocusedTarget.movementTargetData, currentFocusedTarget.m_OnFocus);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            currentFocusedTarget.m_OnUnfocus.Invoke();
            
            if (previousFocusedTarget == null)
                return;

            currentFocusedTarget = previousFocusedTarget;
            Move(currentFocusedTarget.movementTargetData, currentFocusedTarget.m_OnFocus);
        }
    }

    private void Move(Transform targetTransform, UnityEvent onFocusEvent)
    {
        GameManager.Instance.cameraIsLocked = currentFocusedTarget.lockCameraWhileFocused;
        
        StartCoroutine(MoveCoroutine(targetTransform, onFocusEvent));
    }

    private IEnumerator MoveCoroutine(Transform targetTransform, UnityEvent onFocusEvent)
    {
        transform.DOMove(targetTransform.position, movementInterpolationTime);
        Tween rotationTween = transform.DORotate(targetTransform.localEulerAngles, movementInterpolationTime);
        
        yield return rotationTween.WaitForCompletion();
        
        onFocusEvent.Invoke();
    }
}
