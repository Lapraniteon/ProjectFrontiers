using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject exitDoor;
    public TMP_Text screenText;
    
    public void Complete()
    {
        if (GameManager.Instance.solved_total < 4)
            return;
        
        exitDoor.SetActive(false);
        screenText.text = "Normal\nOperations";
        screenText.color = Color.green;
    }
}
