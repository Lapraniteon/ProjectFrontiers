using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PipePuzzleSegment : MonoBehaviour
{
    [Tooltip("The orientation of this pipe segment.\n0 = North\n1 = East\n2 = South\n3 = West")]
    public int orientation;

    private void Start()
    {
        // Randomize rotation
        orientation = Random.Range(0, 4);
        transform.localRotation = Quaternion.Euler(-90 * orientation, 0, 0);
    }

    public void Rotate()
    {
        orientation++;
        if (orientation == 4)
            orientation = 0;

        transform.DORotate(transform.localEulerAngles + new Vector3(0f, 0f, -90f), 0.5f).SetEase(Ease.OutBounce);
    }
}
