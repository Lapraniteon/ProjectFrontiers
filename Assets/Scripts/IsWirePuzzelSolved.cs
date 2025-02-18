using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsWirePuzzelSolved : MonoBehaviour
{
    public GameObject[] wireConnected;

    public GameObject sparksParticles;

    public UnityEvent m_OnSolved;

    public GameObject lights;

    public bool CheckSolution()
    {
        for (int i = 0; i < wireConnected.Length; i++)
        {
            if (wireConnected[i].GetComponent<DragAndDrop>().wiresConnected == false)
                return false;
        }
        lights.SetActive(true);
        GameManager.Instance.solved_wirePuzzle++;
        m_OnSolved.Invoke();
        return true;
    }
}
