using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class OnOffArrow : MonoBehaviour
{
    public int ID;
    private ButtonManager buttonManager;
    private GameObject generateMap;

    [SerializeField] public Sprite arrowOn;
    [SerializeField] public Sprite arrowOff;
    [SerializeField] public GameObject fletxa_button;
    [SerializeField] GameObject lights;
    [SerializeField] ParticleSystem spark;


    private void Update()
    {
        /*if (generateMap == null)
        {
            generateMap = GameObject.Find("Generate Map");
            buttonManager = generateMap.GetComponent<ButtonManager>();
        }

        for (int i = 0; i < buttonManager.ListButtons.Count; i++)
        {
            if (ID == buttonManager.ListButtons[i].GetComponent<Buttons>().ID)
            {
                if (buttonManager.ListButtons[i].GetComponent<Buttons>().isPressed)
                {
                    ChangeSprite();
                }
            }
            
        }*/
        

    }
    public void ChangeSprite()
    {
        if(GetComponent<SpriteRenderer>().sprite == arrowOn)
        {
            Debug.Log("Changed Sprite to OFF");
            gameObject.tag = "Tile";
            GetComponent<SpriteRenderer>().sprite = arrowOff;
        }
        else if (GetComponent<SpriteRenderer>().sprite == arrowOff)
        {
            Debug.Log("Changed Sprite to ON");
            gameObject.tag = "Arrow";
            GetComponent<SpriteRenderer>().sprite = arrowOn;
        }
    }
}
