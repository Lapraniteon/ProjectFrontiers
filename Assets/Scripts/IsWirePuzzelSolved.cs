using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsWirePuzzelSolved : MonoBehaviour
{
    public GameObject[] wireConnected;

    public UnityEvent m_OnSolved;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Debug.Log(CheckSolution());
    }

    public bool CheckSolution()
    {
        for (int i = 0; i < wireConnected.Length; i++)
        {
            if (wireConnected[i].GetComponent<DragAndDrop>().wiresConnected == false)
                return false;
        }

        GameManager.Instance.solved_wirePuzzle++;
        m_OnSolved.Invoke();
        return true;
    }
}
