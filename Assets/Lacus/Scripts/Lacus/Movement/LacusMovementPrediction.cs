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


    // GetCurrentIsFacing Inicial

    // Bucle:
    // Comprobar bateria no es 0
    // Mirar Tile Seguent, fer comprobacions
    // Avançar en IsFacing correcte

    private void Start()
    {

        // GetCurrentFacing Inicial
        ForwardDestination();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        // "Bucle"

        // Comprobar bateria
        if (stats.batteryLeft != 0)
        {
            // Mirar Tile Seguent
            if (collider.CompareTag("Tile"))
            {
                // Avançar en is Facing Correcte
                ForwardDestination();

                Debug.Log("Tile");
            }
            if (collider.CompareTag("Stop"))
            {
                // Parar moviment, no avança el destination
                LockDestination();
                Debug.Log("Stop");
            }
            if (collider.CompareTag("End"))
            {
                // Parar moviment, no avança el destination
                LockDestination();
                Debug.Log("End");
            }
            if (collider.CompareTag("Arrow"))
            {
                // Parar moviment, no avança el destination
                LockDestination();
                Debug.Log("Arrow");
            }
        }
    }

    private void Update()
    {
        /*if (LockDestination())
        {
            this.transform.position = currentPosition;
        }*/
    }

    void ForwardDestination()
    {
        if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.RIGHT)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x + 1f, 0f, 0f);
        }
        else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.UP)
        {
            this.transform.localPosition = new Vector3(0f, this.transform.localPosition.x + 1f, 0f);
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

    void LockDestination()
    {
        this.transform.TransformPoint(this.transform.localPosition);
    }


    
}
