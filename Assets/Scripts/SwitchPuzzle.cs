using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchPuzzle : MonoBehaviour
{
    [Tooltip("The name of the layer that the pipe segments are on.")]
    public string switchButtonLayer;
    private LayerMask _switchButtonLayerMask;

    [Tooltip("Is this puzzle solved?")]
    public bool isSolved = false;

    public UnityEvent m_OnSolved;

    private void Start()
    {
        _switchButtonLayerMask = LayerMask.GetMask(switchButtonLayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, _switchButtonLayerMask, QueryTriggerInteraction.Collide))
            {
                if (!isSolved)
                {
                    isSolved = true;
                    Debug.Log("Switch solved!");
                    GameManager.Instance.solved_firstSwitch++;
                    m_OnSolved.Invoke();
                }
            }
        }
    }
}
