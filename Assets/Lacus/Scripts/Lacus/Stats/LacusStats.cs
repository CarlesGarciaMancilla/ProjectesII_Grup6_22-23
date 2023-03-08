using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusStats : MonoBehaviour
{
    public int maxBattery = 6;
    public int batteryLeft;
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
