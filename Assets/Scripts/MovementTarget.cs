using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementTarget : MonoBehaviour
{
    [Tooltip("The target position and rotation of the camera when focusing on this object.")]
    public Transform movementTargetData;
    [Tooltip("The area in which can be clicked to focus on this target.")]
    public SphereCollider movementTargetCollider;

    [Space] 
    [Tooltip("Prevent the camera from being rotated while this target is focused.")]
    public bool lockCameraWhileFocused;
    [Tooltip("Also rotate the camera according to the movement target data.")]
    public bool applyCameraRotation;

    public bool playedDialogue;
    
    [Space]
    [Tooltip("Methods to run when this object becomes focused.")]
    public UnityEvent m_OnFocus;
    [Tooltip("Methods to run when this object becomes unfocused.")]
    public UnityEvent m_OnUnfocus;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, .5f);
    }
}
