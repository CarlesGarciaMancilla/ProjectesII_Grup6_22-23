using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class LacusStats : MonoBehaviour
{
    public int maxBattery = 6;
    public int batteryLeft;

    [HideInInspector] public bool isMoving;

    public bool IsMoving { get { return isMoving; } set { isMoving = value; } }

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


}
