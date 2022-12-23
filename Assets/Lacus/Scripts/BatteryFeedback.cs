using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryFeedback : MonoBehaviour
{
    public GameObject[] bars;
    public LacusStats stats;

    private void Update()
    {
        for(int i = 0; i < 6; i++)
        {
            bars[i].SetActive(stats.batteryLeft >= i);
        }
    }

}
