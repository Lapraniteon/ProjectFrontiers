using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PipePuzzle : MonoBehaviour
{
    [Tooltip("The name of the layer that the pipe segments are on.")]
    public string pipeSegmentLayer;
    private LayerMask _pipeSegmentLayerMask;
    
    [Tooltip("The name of the layer that the button is on.")]
    public string pipeButtonLayer;
    private LayerMask _pipeButtonLayerMask;

    [System.Serializable]
    public class SegmentSolution
    {
        public PipePuzzleSegment segment;
        public int correctOrientation;
    }
    
    [Space]
    [Tooltip("The segments that are part of the solution and their rotations.")]
    public SegmentSolution[] solution;
    
    [System.Serializable]
    public enum SegmentTypes
    {
        Straight,
        Curve,
        Cross,
        ThreeWay,
        End
    };

    [System.Serializable]
    public class SegmentType
    {
        public SegmentTypes type;
        public GameObject prefab;
    }
    [Tooltip("The objects to spawn for each type of segment.")]
    public SegmentType[] segmentTypeObjects;

    [Header("Particles")]
    public Transform checkSolutionButton;

    public GameObject dropletsParticles;

    public bool isFocused = false;

    public UnityEvent m_OnRotateSegment;
    public UnityEvent m_OnSolved;

    void Start()
    {
        _pipeSegmentLayerMask = LayerMask.GetMask(pipeSegmentLayer);
        _pipeButtonLayerMask = LayerMask.GetMask(pipeButtonLayer);
        
        // Determine what pipe piece prefab to spawn based on the defined type.
        PipePuzzleSegment[] children = GetComponentsInChildren<PipePuzzleSegment>();
        foreach (PipePuzzleSegment segment in children) // Go through each pipe segment.
        {
            segment.SpawnPiece(segmentTypeObjects);
            segment.RandomizeRotation();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isFocused && GameManager.Instance.solved_crowbar >= 5)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, _pipeSegmentLayerMask, QueryTriggerInteraction.Collide))
            {
                PipePuzzleSegment segment = hit.transform.GetComponent<PipePuzzleSegment>();
                if (!segment.IsRotating && segment.segmentType != SegmentTypes.Cross)
                {
                    segment.Rotate();
                    m_OnRotateSegment.Invoke();
                }
                    
            }
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, _pipeButtonLayerMask, QueryTriggerInteraction.Collide))
            {
                Debug.Log("hit button");
                Instantiate(dropletsParticles, checkSolutionButton.position, Quaternion.identity);
                Solve();
            }
        }
    }

    public void Solve()
    {
        if (!CheckSolution())
            return;

        GameManager.Instance.solved_pipePuzzle++;
        m_OnSolved.Invoke();
    }

    public bool CheckSolution()
    {
        foreach (SegmentSolution sol in solution)
        {
            if (sol.segment.orientation == sol.correctOrientation || sol.segment.segmentType == SegmentTypes.Cross)
                continue;
            
            Debug.Log("Pipe Puzzle Incorrect \nHalted on check of " + sol.segment.transform.name);
            return false;
        }
        
        Debug.Log("Pipe Puzzle Solved!");
        return true;
    }
    
    public void SetFocus(bool focus) => isFocused = focus;
}
