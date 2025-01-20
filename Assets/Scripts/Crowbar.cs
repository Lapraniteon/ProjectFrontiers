using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crowbar : MonoBehaviour
{
    [Tooltip("The name of the layer that the crowbar is on.")]
    public string crowbarLayer;
    private LayerMask _crowbarMask;

    [Tooltip("The name of the layer that the thing you can interact with the crowbar is on.")]
    public string interactCrowbarMask;
    private LayerMask _interactCrowbarMask;

    [Tooltip("How close the player needs to be to the crowbar.")]
    public float perimeter;

    public UnityEvent m_OnSolved;

    // Start is called before the first frame update
    void Start()
    {
        _crowbarMask = LayerMask.GetMask(crowbarLayer);
        _interactCrowbarMask = LayerMask.GetMask(interactCrowbarMask);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.hasCrowbar && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, perimeter, _interactCrowbarMask, QueryTriggerInteraction.Collide))
            {
                Debug.Log("gotcha");
                GameManager.Instance.solved_crowbar++;
                m_OnSolved.Invoke();
                Destroy(gameObject);
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), perimeter, _crowbarMask, QueryTriggerInteraction.Collide))
            {
                GameManager.Instance.hasCrowbar = true;
                m_OnSolved.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
