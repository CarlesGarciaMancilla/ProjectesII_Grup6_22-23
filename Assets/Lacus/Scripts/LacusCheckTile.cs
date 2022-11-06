using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusCheckTile : MonoBehaviour
{

    public LacusMovement Lacus;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Arrow"))
        {
            Lacus.Rotate(collider.transform.rotation);
            Debug.Log("Arrow");
        }

        if (collider.CompareTag("Battery"))
        {
            Debug.Log("Battery");
        }

        if (collider.CompareTag("Button"))
        {
            Debug.Log("Button");
        }

        if (collider.CompareTag("Stop"))
        {
            Debug.Log("Stop");
        }

        if (collider.CompareTag("End"))
        {
            Debug.Log("End");
        }

    }
}
