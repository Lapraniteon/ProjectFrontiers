using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrTestingScript : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private LineController _line;


    private void Start()
    {
        _line.SetUpLine(_points);
    }
}
