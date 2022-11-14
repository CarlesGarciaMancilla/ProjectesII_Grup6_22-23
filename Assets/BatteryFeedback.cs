using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryFeedback : MonoBehaviour
{
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public GameObject bar4;
    public GameObject bar5;
    public GameObject bar6;
    public LacusStats stats;

    private void Update()
    {
       switch(stats.batteryLeft)
        {
            case 0:
                {
                    bar1.SetActive(false);
                    bar2.SetActive(false);
                    bar3.SetActive(false);
                    bar4.SetActive(false);
                    bar5.SetActive(false);
                    bar6.SetActive(false);
                    break;
                }
            case 1:
                {
                    bar1.SetActive(false);
                    bar2.SetActive(false);
                    bar3.SetActive(false);
                    bar4.SetActive(false);
                    bar5.SetActive(false);
                    bar6.SetActive(true);
                    break;
                }
            case 2:
                {
                    bar1.SetActive(false);
                    bar2.SetActive(false);
                    bar3.SetActive(false);
                    bar4.SetActive(false);
                    bar5.SetActive(true);
                    bar6.SetActive(true);
                    break;
                }
            case 3:
                {
                    bar1.SetActive(false);
                    bar2.SetActive(false);
                    bar3.SetActive(false);
                    bar4.SetActive(true);
                    bar5.SetActive(true);
                    bar6.SetActive(true);
                    break;
                }
            case 4:
                {
                    bar1.SetActive(false);
                    bar2.SetActive(false);
                    bar3.SetActive(true);
                    bar4.SetActive(true);
                    bar5.SetActive(true);
                    bar6.SetActive(true);
                    break;
                }
            case 5:
                {
                    bar1.SetActive(false);
                    bar2.SetActive(true);
                    bar3.SetActive(true);
                    bar4.SetActive(true);
                    bar5.SetActive(true);
                    bar6.SetActive(true);
                    break;
                }
            case 6:
                {
                    bar1.SetActive(true);
                    bar2.SetActive(true);
                    bar3.SetActive(true);
                    bar4.SetActive(true);
                    bar5.SetActive(true);
                    bar6.SetActive(true);
                    break;
                }
        }
    }

}
