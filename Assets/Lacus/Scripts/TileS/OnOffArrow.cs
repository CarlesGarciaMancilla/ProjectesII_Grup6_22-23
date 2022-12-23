using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffArrow : MonoBehaviour
{
    [SerializeField] public Button button;
    [SerializeField] GameObject off;
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
            off.SetActive(false);
            lights.SetActive(true);
            if(i == 0)
            spark.Play();
            fletxa_button.tag = "Arrow";
            i++;
        }
        else// is Off
        {
            i = 0;
            off.SetActive(true);
            lights.SetActive(false);
            fletxa_button.tag = "Tile";
        }
    }
}
