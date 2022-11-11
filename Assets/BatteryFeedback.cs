using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryFeedback : MonoBehaviour
{
    public Image battery;
    public LacusStats stats;

    private void Update()
    {
        battery.fillAmount = ((stats.batteryLeft / 6) / 10);
    }

}
