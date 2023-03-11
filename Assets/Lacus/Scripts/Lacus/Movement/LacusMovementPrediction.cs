using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Runtime.CompilerServices;

public class LacusMovementPrediction : MonoBehaviour
{
    [SerializeField] private LacusStats stats;
    [SerializeField] private LacusMovement lacusM;

    [HideInInspector] private int tempBattery;


    private void Start()
    {
        tempBattery = stats.batteryLeft;
    }

    private void Update()
    {
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (tempBattery > 0)
        {
            if (collider.CompareTag("Battery"))
            {
                FillTempBattery();
            }
            else if (collider.CompareTag("Stop"))
            {
                tempBattery--;
            }
            else if (collider.CompareTag("End"))
            {
                tempBattery--;
            }
            else if (collider.CompareTag("Arrow"))
            {
                tempBattery--;
            }
            else if (collider.CompareTag("Tile"))
            {
                tempBattery--;
            }
            else if (collider.CompareTag("Button"))
            {
                tempBattery--;
            }
        }
    }

    public void FillTempBattery()
    {
        tempBattery = stats.maxBattery;
    }

    public void FillTempBattery(int battery)
    {
        tempBattery = battery -1;
    }
}
