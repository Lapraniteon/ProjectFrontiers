using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipePuzzle : MonoBehaviour
{
    public string pipeSegmentLayer;
    private LayerMask _pipeSegmentLayerMask;

    void Start()
    {
        _pipeSegmentLayerMask = LayerMask.GetMask(pipeSegmentLayer);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, _pipeSegmentLayerMask, QueryTriggerInteraction.Collide))
            {
                PipePuzzleSegment segment = hit.transform.GetComponent<PipePuzzleSegment>();
                if (!segment.IsRotating)
                    segment.Rotate();
            }
        }
    }
}
