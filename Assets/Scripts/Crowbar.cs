using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    [Tooltip("The name of the layer that the crowbar is on.")]
    public string crowbarLayer;
    private LayerMask _crowbarMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, _crowbarMask, QueryTriggerInteraction.Collide))
            {
                GameManager.Instance.hasCrowbar = true;
                Destroy(this);
            }
        }
    }
}
