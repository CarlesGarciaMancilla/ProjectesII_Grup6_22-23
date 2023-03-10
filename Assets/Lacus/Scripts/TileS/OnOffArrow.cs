using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffArrow : MonoBehaviour
{
    [SerializeField] public Buttons button;
    [SerializeField] Sprite arrowOn;
    [SerializeField] Sprite arrowOff;
    [SerializeField] GameObject fletxa_button;
    [SerializeField] GameObject lights;
    [SerializeField] ParticleSystem spark;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button.isPressed)//is On
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = arrowOn;
            lights.SetActive(true);
            if(i == 0)
            spark.Play();
            fletxa_button.tag = "Arrow";
            i++;
        }
        else// is Off
        {
            i = 0;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = arrowOff;
            lights.SetActive(false);
            fletxa_button.tag = "Tile";
        }
    }
}
