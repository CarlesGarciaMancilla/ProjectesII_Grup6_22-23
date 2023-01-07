using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffArrow : MonoBehaviour
{
    [SerializeField] public Buttons button;
    [SerializeField] GameObject off;
    [SerializeField] GameObject fletxa_button;
    [SerializeField] GameObject lights;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button.isPressed)//is On
        {
            off.SetActive(false);
            lights.SetActive(true);
            fletxa_button.tag = "Arrow";
        }
        else// is Off
        {
            off.SetActive(true);
            lights.SetActive(false);
            fletxa_button.tag = "Tile";
        }
    }
}
