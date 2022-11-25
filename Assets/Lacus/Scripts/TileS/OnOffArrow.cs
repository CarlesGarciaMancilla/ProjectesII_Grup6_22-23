using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffArrow : MonoBehaviour
{
    [SerializeField] public Button button;
    [SerializeField] GameObject off;
    [SerializeField] GameObject fletxa_button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button.isPressed)
        {
            off.SetActive(false);
            fletxa_button.tag = "Arrow";
        }
        else
        {
            off.SetActive(true);
            fletxa_button.tag = "Tile";
        }
    }
}
