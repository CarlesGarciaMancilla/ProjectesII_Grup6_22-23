using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusStats : MonoBehaviour
{
    public int maxBattery = 6;
    public int batteryLeft;

    [HideInInspector] public bool isMoving = false;

    void Start()
    {
        ResetBattery();
    }

    public void ResetBattery()
    {
        batteryLeft = maxBattery;
    }

    void Update()
    {
        
    }

    public void DisableMovement()
    {
        isMoving = false;
    }

    public void ActivateMovement()
    {
        isMoving = true;
    }
}
