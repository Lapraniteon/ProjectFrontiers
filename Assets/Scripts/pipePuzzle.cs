using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePuzzle : MonoBehaviour
{
    [Tooltip("The name of the layer that the pipe segments are on.")]
    public string pipeSegmentLayer;
    private LayerMask _pipeSegmentLayerMask;

    [System.Serializable]
    public class SegmentSolution
    {
        public PipePuzzleSegment segment;
        public int orientation;
    }
    
    [Space]
    [Tooltip("The segments that are part of the solution and their rotations.")]
    public SegmentSolution[] solution;

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
