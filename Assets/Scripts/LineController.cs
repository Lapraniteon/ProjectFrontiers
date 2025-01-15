using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    // the line renderer
    private LineRenderer _lr;
    // an array for the position of the points
    private Transform[] _points;

    private void Awake()    // sets the line renderer
    {
        _lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] _points)  // sets up the line using the points
    {
        _lr.positionCount = _points.Length;
        this._points = _points;
    }

    private void Update()    // constantly checks if the line is drawn correctly or every position
    {
        for (int i = 0; i < _points.Length; i++)
        {
            _lr.SetPosition(i, _points[i].position);
        }
    }
}
