using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInterface : MonoBehaviour
{
    public GameObject electricityOff;
    public GameObject electricityOn;

    public GameObject waterOff;
    public GameObject waterOn;

    public void TurnElectricityOn()
    {
        electricityOn.SetActive(true);
        electricityOff.SetActive(false);
    }

    public void TurnWaterOn()
    {
        waterOn.SetActive(true);
        waterOff.SetActive(false);
    }
}
