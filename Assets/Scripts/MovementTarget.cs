using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementTarget : MonoBehaviour
{
    [Tooltip("The target position and rotation of the camera when focusing on this object.")]
    public Transform movementTargetData;

    [Space] 
    [Tooltip("Prevent the camera from being rotated while this target is focused.")]
    public bool lockCameraWhileFocused;
    
    [Space]
    [Tooltip("Methods to run when this object becomes focused.")]
    public UnityEvent m_OnFocus;
    [Tooltip("Methods to run when this object becomes unfocused.")]
    public UnityEvent m_OnUnfocus;
}
