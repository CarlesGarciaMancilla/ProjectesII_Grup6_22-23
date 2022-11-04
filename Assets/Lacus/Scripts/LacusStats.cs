using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusStats : MonoBehaviour
{
    public int maxBattery = 6;
    public int batteryLeft;
    void Start()
    {
        batteryLeft = maxBattery;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
