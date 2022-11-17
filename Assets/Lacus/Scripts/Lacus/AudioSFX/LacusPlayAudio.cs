using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusPlayAudio : MonoBehaviour
{
    public AudioSource moveAudio;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Tile"))
        {
            moveAudio.Play();
        }
    }
}