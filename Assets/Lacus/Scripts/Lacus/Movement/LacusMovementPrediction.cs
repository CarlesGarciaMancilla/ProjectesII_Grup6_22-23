using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using DG.Tweening;

public class LacusMovementPrediction : MonoBehaviour
{
    [SerializeField] private LacusStats stats;
    [SerializeField] GameObject tile;
    Vector3 currentPosition;
    private bool locked;

    int tempBattery;


    // GetCurrentIsFacing Inicial

    // Bucle:
    // Comprobar bateria no es 0
    // Mirar Tile Seguent, fer comprobacions
    // Avançar en IsFacing correcte

    private void Start()
    {
        tempBattery = stats.batteryLeft;
        // GetCurrentFacing Inicial
        ForwardDestination();

        

    }

    private void Update()
    {
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        // "Bucle"

        // Comprobar bateria, mirar quantes caselles pot avançar amb la bateria que li queda
        if (tempBattery > 0)
        {
            // Mirar Tile Seguent
            if (collider.CompareTag("Tile") && !locked)
            {
                // Avançar en is Facing Correcte
                ForwardDestination();
            }

            locked = false;

            if (collider.CompareTag("Stop"))
            {
                // Parar moviment, no avança el destination
                locked = true;
            }
            if (collider.CompareTag("End"))
            {
                // Parar moviment, no avança el destination
                locked = true;
            }
            if (collider.CompareTag("Arrow"))
            {
                // Parar moviment, no avança el destination
                locked = true;
            }
            tempBattery--;
            Debug.Log(tempBattery);
        }
    }

    public void ForwardDestination()
    {
        if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.RIGHT)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x + 1f, 0f, 0f);
        }
        else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.UP)
        {
            this.transform.localPosition = new Vector3(0f, this.transform.localPosition.y + 1f, 0f);
        }
        else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.LEFT)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x - 1f, 0f, 0f);
        }
        else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.DOWN)
        {
            this.transform.localPosition = new Vector3(0f, this.transform.localPosition.y - 1f, 0f);
        }
    } 
}
