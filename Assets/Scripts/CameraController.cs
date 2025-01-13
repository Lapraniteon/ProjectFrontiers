using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Tooltip("How fast the camera will move around.")]
    public float cameraMoveSpeed;

    [Space] 
    [Tooltip("The area around the screen in which the mouse can be to move around, in pixels.")]
    public float movementAreaMargin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPositionNormalized = Input.mousePosition.x / Screen.width;
        float yPositionNormalized = Input.mousePosition.y / Screen.height;

        Debug.Log(xPositionNormalized + ", " + yPositionNormalized);
    }
}
