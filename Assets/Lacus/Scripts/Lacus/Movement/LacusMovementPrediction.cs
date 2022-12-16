using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using DG.Tweening;

public class LacusMovementPrediction : MonoBehaviour
{
    [SerializeField] private LacusStats stats;
    [SerializeField] private LacusMovement movement;
    [SerializeField] GameObject tile;
    [SerializeField] private bool locked;

    private int tempBattery;


    // GetCurrentIsFacing Inicial

    // Bucle:
    // Comprobar bateria no es 0
    // Mirar Tile Seguent, fer comprobacions
    // Avançar en IsFacing correcte

    private void Start()
    {
        tempBattery = stats.batteryLeft;
        // GetCurrentFacing Inicial
        movement.ForwardDestination();
    }

    private void Update()
    {
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        // "Bucle"
        // Comprobar bateria, mirar quantes caselles pot avançar amb la bateria que li queda

        // Mirar Tile Seguent
        if (collider.CompareTag("Battery"))
        {
            // Parar moviment, no avança el destination
            movement.ForwardDestination();
        }
        if (collider.CompareTag("Stop"))
        {
            // Parar moviment, no avança el destination
               
        }
        if (collider.CompareTag("End"))
        {
            // Parar moviment, no avança el destination
               
        }
        if (collider.CompareTag("Arrow"))
        {
            // Parar moviment, no avança el destination
        }

        if (collider.CompareTag("Tile"))
        {
            // Avançar en is Facing Correcte
            movement.ForwardDestination();
        }
    }

    /*public void ForwardDestination()
    {
        if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.RIGHT)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 1.6f, 0f, 0f);
        }
        else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.UP)
        {
            transform.localPosition = new Vector3(0f, transform.localPosition.y + 1.6f, 0f);
        }
        else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.LEFT)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - 1.6f, 0f, 0f);
        }
        else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.DOWN)
        {
            transform.localPosition = new Vector3(0f, transform.localPosition.y - 1.6f, 0f);
        }
    } 

    public void ResetDestinationPosition()
    {
        transform.localPosition = new Vector3(1.6f, 0, 0);
    }*/
}
