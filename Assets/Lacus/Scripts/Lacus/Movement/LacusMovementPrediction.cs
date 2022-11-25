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

    void OnTriggerEnter2D(Collider2D collider)
    {
        /*if (collider.CompareTag("Tile"))
        {

            if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.RIGHT && stats.batteryLeft != 0 && !LockDestination())
            {
                this.transform.position = new Vector3( this.transform.localPosition.x + tile.transform.localScale.x, 0f, 0f);
            }
            else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.UP && stats.batteryLeft != 0 && !LockDestination())
            {
                this.transform.position = new Vector3( 0f, this.transform.position.x + tile.transform.localScale.y, 0f);
            }
            else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.LEFT && stats.batteryLeft != 0 && !LockDestination())
            {
                this.transform.position = new Vector3( this.transform.position.x - tile.transform.localScale.x, 0f, 0f);
            }
            else if (stats.GetCurrentIsFacing() == LacusStats.LacusIsFacing.DOWN && stats.batteryLeft != 0 && !LockDestination())
            {
                this.transform.position = new Vector3( 0f, this.transform.position.y - tile.transform.localScale.y, 0f);
            }
            
            Debug.Log("Tile");
        }
        if (collider.CompareTag("Stop"))
        {
            locked = true;
            // Parar moviment, no avança el destination
            Debug.Log("Stop");
        }
        if (collider.CompareTag("End"))
        {
            locked = true;
            // Parar moviment, no avança el destination
            Debug.Log("End");
        }
        if (collider.CompareTag("Arrow"))
        {
            locked = true;
            // Parar moviment, no avança el destination
        }*/
        
    }

    private void Update()
    { 
        /*if (LockDestination())
        {
            this.transform.position = currentPosition;
        }*/
    }

    bool LockDestination()
    {
        currentPosition = this.transform.position;
        if (!locked)
        {
            return false;
        }
        else 
        {
            return true;
        }  
    }
}
