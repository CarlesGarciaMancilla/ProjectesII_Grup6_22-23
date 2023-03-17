using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusStats : MonoBehaviour
{
    public int maxBattery = 6;
    public int batteryLeft;
    [SerializeField] private bool _isMoving = false;

    public bool isMoving
    {
        get { return _isMoving; }
        set { _isMoving = value; }
    }

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
        CheckIsMoving();
    }

    private void CheckIsMoving()
    {
        if (batteryLeft == 0)
        {
            isMoving = false;
        }
    }
}
