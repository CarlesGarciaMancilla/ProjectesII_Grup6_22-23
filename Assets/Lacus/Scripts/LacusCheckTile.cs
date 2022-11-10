using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LacusCheckTile : MonoBehaviour
{

    public LacusMovement Lacus;
    public LacusStats LacusS;
    public FinishTile final;
    public Grid grid;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Battery"))
        {
            Debug.Log("Battery");
            LacusS.batteryLeft = LacusS.maxBattery;
        }

        if (collider.CompareTag("Button"))
        {
            grid.GenerateFinal();
            Debug.Log("Button");
        }

        if (collider.CompareTag("Stop"))
        {

            Lacus.isMoving = false;
            Debug.Log("Stop");
        }

        if (collider.CompareTag("End"))
        {
            LacusS.tempFinish.SetActive(true);
            Debug.Log("End");
        }
        if (collider.CompareTag("Tile"))
        {
            Debug.Log("Tile");
            Lacus.ForwardWithJumps();
            LacusS.batteryLeft--;
            Debug.Log(LacusS.batteryLeft);
        }
    }
}
