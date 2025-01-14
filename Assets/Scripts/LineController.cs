using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _lr;
    private Transform[] _points;

    private void Awake()
    {
        _lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] _points)
    {
        _lr.positionCount = _points.Length;
        this._points = _points;
    }

    private void Update()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            _lr.SetPosition(i, _points[i].position);
        }
    }
}
