using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Button : MonoBehaviour
{
    public bool isPressed;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (isPressed)
            {
                Debug.Log("Button off");
                isPressed = false;
            }
            if (!isPressed)
            {
                Debug.Log("Button on");
                isPressed = true;
            }
        }
    }

}
