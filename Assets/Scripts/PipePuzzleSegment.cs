using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipePuzzleSegment : MonoBehaviour
{
    [Tooltip("Is this segment currently rotating?")]
    public bool IsRotating { get; private set; }
    
    [Tooltip("The orientation of this pipe segment.\n0 = North\n1 = East\n2 = South\n3 = West")]
    public int orientation;
    
    [Tooltip("The type of this segment.")]
    public PipePuzzle.SegmentTypes segmentType;

    public void SpawnPiece(PipePuzzle.SegmentType[] segmentTypeObjects)
    {
        foreach (PipePuzzle.SegmentType definition in segmentTypeObjects) // Find the segment type that matches the specified type on the pipe segment.
        {
            if (segmentType == definition.type)
            {
                Instantiate(definition.prefab, transform); // Spawn the segment type and parent it to the pipe segment.
                break;
            }
        }
    }
    
    public void RandomizeRotation()
    {
        orientation = Random.Range(0, 4);
        if (segmentType == PipePuzzle.SegmentTypes.Straight && orientation > 1) // Straight pieces have only 0 or 1 orientation
            orientation -= 2;
        
        transform.localRotation = Quaternion.Euler(0, 0, -90 * orientation);
    }

    public void Rotate()
    {
        orientation++;
        if (orientation == 4 || (orientation == 2 && segmentType == PipePuzzle.SegmentTypes.Straight))
            orientation = 0;

        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        IsRotating = true;
        Tween rotation = transform.DOLocalRotate(transform.localEulerAngles + new Vector3(0f, 0f, -90f), 0.25f).SetEase(Ease.OutQuad);
        yield return rotation.WaitForCompletion();
        IsRotating = false;
        yield return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
    }
}
