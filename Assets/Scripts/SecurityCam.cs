using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SecurityCam : MonoBehaviour
{

    public Material mat_On;
    public Material mat_Off;

    public MeshRenderer meshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material = mat_Off;
    }

    void Update()
    {
        TurnOn();
    }

    public void TurnOn()
    {
        if (GameManager.Instance.solved_firstSwitch < 2)
            return;

        meshRenderer.material = mat_On;
        GameManager.Instance.securityCamerasOn = true;
    }
}
