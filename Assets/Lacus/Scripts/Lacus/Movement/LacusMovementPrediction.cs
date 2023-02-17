using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using System.Runtime.CompilerServices;

public class LacusMovementPrediction : MonoBehaviour
{
    [SerializeField] private LacusStats stats;
    [SerializeField] private LacusMovement movement;
    [SerializeField] GameObject tile;
    [SerializeField] private bool locked;

    [HideInInspector] private int tempBattery;


    private void Start()
    {
        tempBattery = stats.batteryLeft;
        
        movement.ForwardDestination();
    }

    private void Update()
    {
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        // "Bucle"
        // Comprobar bateria, mirar quantes caselles pot avançar amb la bateria que li queda

        // Mirar Tile Seguent
        if (tempBattery > 0)
        {
            if (collider.CompareTag("Battery"))
            {
                Debug.Log("Battery Filled");
                FillTempBattery();
                //movement.ForwardDestination();
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
                //movement.ForwardDestination();
                tempBattery--;
            }
            if (collider.CompareTag("Button"))
            {
                //movement.ForwardDestination();
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
