using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crowbar : MonoBehaviour
{
    [Tooltip("The name of the layer that the crowbar is on.")]
    public string crowbarLayer;

    [Tooltip("How close the player needs to be to the crowbar.")]
    public float perimeter;

    public UnityEvent m_OnSolved;

    private LayerMask _crowbarMask;

    // Start is called before the first frame update
    void Start()
    {
        _crowbarMask = LayerMask.GetMask(crowbarLayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.hasCrowbar)
            {
                Debug.Log("gotcha");
                m_OnSolved.Invoke();
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, perimeter, _crowbarMask, QueryTriggerInteraction.Collide))
            {
                GameManager.Instance.hasCrowbar = true;
                m_OnSolved.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
