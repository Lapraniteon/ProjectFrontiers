using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadActivation : MonoBehaviour
{
    public GameObject keyPadCanvas;

    public void ActivateKeyPad()
    {
        keyPadCanvas.SetActive(true);
    }

    public void DeactivateKeyPad()
    {
        keyPadCanvas.SetActive(false);
    }
}
