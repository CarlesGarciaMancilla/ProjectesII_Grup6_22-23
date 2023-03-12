using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Buttons : MonoBehaviour
{
    public int ID;

    public bool _isPressed;

    public Sprite buttonOn;
    public Sprite buttonOff;
    [SerializeField] GameObject lights;
    [SerializeField] private AudioSource buttonOnOffSound;

    public bool isPressed
    {
        get { return _isPressed; }
        set { _isPressed = value; }
    }

    // Codi per apagar encendre el boto
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("ENTER BUTTON");
            isPressed = true;
            ChangeSprite();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("EXIT BUTTON");
            isPressed = false;
        }
    }

    void ChangeSprite()
    {
        if (GetComponent<SpriteRenderer>().sprite == buttonOff)
        {
            GetComponent<SpriteRenderer>().sprite = buttonOn;
        }
        else if(GetComponent<SpriteRenderer>().sprite == buttonOn)
        {
            GetComponent<SpriteRenderer>().sprite = buttonOff;
        }
    }


}
