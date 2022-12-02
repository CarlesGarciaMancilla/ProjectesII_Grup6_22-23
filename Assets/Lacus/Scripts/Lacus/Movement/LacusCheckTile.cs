using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusCheckTile : MonoBehaviour
{
    public LacusMovement Lacus;
    public LacusStats LacusS;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Battery"))
        {
            Debug.Log("Battery");
            LacusS.batteryLeft = LacusS.maxBattery;
        }

        if (collider.CompareTag("Button"))
        {
            Debug.Log("Button");
        }

        if (collider.CompareTag("Stop"))
        {
            Lacus.isMoving = false;
            Debug.Log("Stop");
        }

        if (collider.CompareTag("End"))
        {
            Debug.Log("End");
        }
        if (collider.CompareTag("Tile"))
        {
            Debug.Log("Tile");
            //Lacus.ForwardWithJumps();
            LacusS.batteryLeft--;
        }
    }
}
