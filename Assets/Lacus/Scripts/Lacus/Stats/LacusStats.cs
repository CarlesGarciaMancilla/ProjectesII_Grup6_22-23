using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusStats : MonoBehaviour
{
    [SerializeField] GameObject Lacus;
    public enum LacusIsFacing { LEFT, UP, RIGHT, DOWN };
    public LacusIsFacing isFacing;

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

    public LacusIsFacing GetCurrentIsFacing()
    {
        
        Quaternion right = Quaternion.Euler(0, 0, 0);
        Quaternion up = Quaternion.Euler(0, 0, 90);
        Quaternion left = Quaternion.Euler(0, 0, 180);
        Quaternion down = Quaternion.Euler(0, 0, 270);

        if (Lacus.transform.rotation == right)
        {
            isFacing = LacusIsFacing.RIGHT;
        }
        if (Lacus.transform.rotation == up)
        {
            isFacing = LacusIsFacing.UP;
        }
        if (Lacus.transform.rotation == left)
        {
            isFacing = LacusIsFacing.LEFT;
        }
        if (Lacus.transform.rotation == down)
        {
            Debug.Log("HELLO");
            isFacing = LacusIsFacing.DOWN;
        }
        return isFacing;
    }
}
