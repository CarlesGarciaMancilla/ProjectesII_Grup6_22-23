using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusCheckTileRotation : MonoBehaviour
{
    [SerializeField] private ProtoRotation rotationScript;
    [SerializeField] private LacusStats LacusS;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Colisió Casella NOMES ARROW
        if (collider.CompareTag("Arrow"))
        {
            LacusS.batteryLeft--;
            StartCoroutine(rotationScript.LacusOnTileRotation(collider));
        }
    }
}
