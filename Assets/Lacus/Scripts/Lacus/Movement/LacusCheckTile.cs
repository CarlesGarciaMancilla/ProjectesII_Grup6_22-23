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
        tempG = GameObject.Find("Canvasfinal");
       menu = tempG.transform.Find("FinalMenu").gameObject;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!Lacus.isMoving)
            return;

        if (collider.CompareTag("Battery"))
        {
            LacusS.ResetBattery();
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
            menu.SetActive(true);
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
