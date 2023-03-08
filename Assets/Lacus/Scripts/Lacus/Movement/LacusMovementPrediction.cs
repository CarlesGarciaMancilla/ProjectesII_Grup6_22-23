using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Runtime.CompilerServices;

public class LacusMovementPrediction : MonoBehaviour
{
    [SerializeField] private LacusStats stats;
    //[SerializeField] GameObject tile;
    //[SerializeField] private bool locked;

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
            if (collider.CompareTag("Stop"))
            {
                tempBattery--;
            }
            if (collider.CompareTag("End"))
            {
                tempBattery--;
            }
            if (collider.CompareTag("Arrow"))
            {
                tempBattery--;
            }
            if (collider.CompareTag("Tile"))
            {
                tempBattery--;
            }
            if (collider.CompareTag("Button"))
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
