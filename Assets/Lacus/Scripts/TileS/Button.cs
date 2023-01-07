using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Buttons : MonoBehaviour
{
    public bool isPressed;
    public Sprite buttonOn;
    public Sprite buttonOff;
    [SerializeField] private AudioSource buttonOnOffSound;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (isPressed)
            {
                Debug.Log("Button off");
                isPressed = false;
                this.gameObject.GetComponent<SpriteRenderer>().sprite=buttonOff;
                buttonOnOffSound.Play();
            }
            if (!isPressed)
            {
                Debug.Log("Button on");
                isPressed = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = buttonOn;
                buttonOnOffSound.Play();
            }
        }
    }

}
