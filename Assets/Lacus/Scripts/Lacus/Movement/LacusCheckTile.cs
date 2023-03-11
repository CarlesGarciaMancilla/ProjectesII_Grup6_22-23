using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LacusCheckTile : MonoBehaviour
{
    public LacusMovement Lacus;
    public LacusStats LacusS;
    [SerializeField] private AudioSource StopSound;
    private GameObject tempG;
    private GameObject menu;

    void Start()
    {
        // Això SEGURAMENT no va aqui
        tempG = GameObject.Find("Canvasfinal");
        menu = tempG.transform.Find("FinalMenu").gameObject;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Colisions Amb Tiles

        if (!LacusS.isMoving)
            return;

        if (collider.CompareTag("Battery"))
        {
            LacusS.ResetBattery();
        }

        else if (collider.CompareTag("Button"))
        {
            // Activates / Deactivates the button
        }

        else if (collider.CompareTag("Stop"))
        {
            LacusS.isMoving = false;
            LacusS.batteryLeft--;
            StopSound.Play();
        }

        else if (collider.CompareTag("End"))
        {
            // Change to next scene
            // Canviar la linea de sota
            LacusS.isMoving = false;
            menu.SetActive(true);
        }
        else if (collider.CompareTag("Tile"))
        {
            LacusS.batteryLeft--;
        }
        else if (collider.CompareTag("Wall"))
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
