using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Tooltip("How fast the camera will move around.")]
    public float cameraMoveSpeed;

    [Space] 
    [Tooltip("The area around the screen in which the mouse can be to move around, in a fraction from 0 - 1")]
    public float movementAreaMargin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        float xPositionNormalized = Input.mousePosition.x / Screen.width;
        float yPositionNormalized = Input.mousePosition.y / Screen.height;
        
        if (xPositionNormalized >= movementAreaMargin && xPositionNormalized <= 1f - movementAreaMargin)
            if (yPositionNormalized >= movementAreaMargin && yPositionNormalized <= 1f - movementAreaMargin)
                return;

        float xMagnitude = xPositionNormalized / 2f + 1f;
        float yMagnitude = yPositionNormalized / 2f + 1f;

        Debug.Log(xPositionNormalized + ", " + yPositionNormalized);
    }
}
