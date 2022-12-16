using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LacusCheckTile : MonoBehaviour
{
    public LacusMovement Lacus;
    public LacusStats LacusS;
    [SerializeField] private AudioSource StopSound;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Battery"))
        {
            LacusS.batteryLeft = LacusS.maxBattery;
        }

        if (collider.CompareTag("Button"))
        {
            // Activates / Deactivates the button
        }

        if (collider.CompareTag("Stop"))
        {
            Lacus.isMoving = false;
            LacusS.batteryLeft--;
            StopSound.Play();
        }

        if (collider.CompareTag("End"))
        {
            // Change to next scene
        }
        if (collider.CompareTag("Tile"))
        {
            LacusS.batteryLeft--;
        }
        if (collider.CompareTag("Wall"))
        {

            StartCoroutine(WallRespawn());
        }
    }

    IEnumerator WallRespawn()
    {
        Lacus.ResetLacus();
        yield return new WaitForSeconds(0.1f);
        Lacus.ResetLacus();
    }

}
