using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrTestingScript : MonoBehaviour
{
    // the points that the line connects to
    [SerializeField] private Transform[] _points;
    // the line renderer that is used to create the line
    [SerializeField] private LineController _line;


    private void Start()    // uses the line renderer and points to set up the line
    {
        _line.SetUpLine(_points);
    }
}
