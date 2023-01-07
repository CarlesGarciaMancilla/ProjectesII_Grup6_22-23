using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusPlayAudio : MonoBehaviour
{
    public AudioSource moveAudio;
    public AudioSource detectArrowAudio;
    public AudioSource endAudio;
    public AudioSource batteryAudio;
    //public AudioSource detectOffArrowAudio;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Tile"))
        {
            moveAudio.Play();
        }
        else if(collider.CompareTag("Arrow"))
        {
            detectArrowAudio.Play();
        }
        else if(collider.CompareTag("End"))
        {
            endAudio.Play();
        }
        else if (collider.CompareTag("Battery"))
        {
            batteryAudio.Play();
        }
    }
}