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

    [Space] [Tooltip("The methods to run when movement is finished")]
    public UnityEvent m_onMovementFinished;

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
                    Move(targetTransform);
                }
            }
        }
    }

    private void Move(Transform targetTransform) => StartCoroutine(MoveCoroutine(targetTransform));

    private IEnumerator MoveCoroutine(Transform targetTransform)
    {
        transform.DOMove(targetTransform.position, movementInterpolationTime);
        Tween rotationTween = transform.DORotate(targetTransform.localEulerAngles, movementInterpolationTime);
        
        yield return rotationTween.WaitForCompletion();
        
        m_onMovementFinished.Invoke();
    }
}
