using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Tooltip("How fast the camera will move around.")]
    public float cameraMoveSpeed;

    [Space] 
    [Tooltip("The area around the screen in which the mouse can be to move around, in a fraction from 0 - 1")]
    public float movementAreaMargin;
    [Tooltip("The range in degrees in which the camera can move on the x rotation axis.")]
    public float xRotationRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.cameraIsLocked)
            CameraMovement();
    }

    private void CameraMovement()
    {
        float xPositionNormalized = Input.mousePosition.x / Screen.width;
        float yPositionNormalized = Input.mousePosition.y / Screen.height;
        
        if (xPositionNormalized >= movementAreaMargin && xPositionNormalized <= 1f - movementAreaMargin)
            if (yPositionNormalized >= movementAreaMargin && yPositionNormalized <= 1f - movementAreaMargin)
                return;

        float xMagnitude = xPositionNormalized * 2f - 1f;
        float yMagnitude = yPositionNormalized * 2f - 1f;
        
        transform.Rotate(0f, xMagnitude * cameraMoveSpeed * Time.deltaTime, 0f, Space.World);
        transform.Rotate(-yMagnitude * cameraMoveSpeed * Time.deltaTime, 0f, 0f, Space.Self);

        float clampedX = transform.localEulerAngles.x;
        if (clampedX > 180f)
            clampedX -= 360f;
        
        clampedX = Mathf.Clamp(clampedX, -xRotationRange / 2f, xRotationRange / 2f);
        
        transform.localRotation = Quaternion.Euler(
            clampedX, 
            transform.localEulerAngles.y, 
            transform.localEulerAngles.z
            );

        // Debug.Log(xPositionNormalized + ", " + yPositionNormalized);
    }
}
