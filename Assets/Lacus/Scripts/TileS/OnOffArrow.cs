using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffArrow : MonoBehaviour
{
    public int ID;
    private ButtonManager buttonManager;
    private GameObject generateMap;

    public int numLinks = 0;

    public string test;

    [SerializeField] public Sprite arrowOn;
    [SerializeField] public Sprite arrowOff;
    [SerializeField] public GameObject fletxa_button;
    [SerializeField] GameObject lights;
    [SerializeField] ParticleSystem spark;
    bool isOn;

    private void Start()
    {
        isOn = false;
    }

    private void Update()
    {
        if (generateMap == null)
        {
            generateMap = GameObject.Find("Generate Map");
            buttonManager = generateMap.GetComponent<ButtonManager>();
        }

        numLinks = GetActiveLinks();
        

    }
    private int GetActiveLinks()
    {
        int links = 0;
        for (int i = 0; i < buttonManager.ListButtons.Count; i++)
        {
            if (buttonManager.ListButtons[i].GetComponent<Buttons>().isPressed && (buttonManager.ListButtons[i].GetComponent<Buttons>().ID == ID))
            {
                links++;
            }
        }
        ChangeSprite();

        return links;
    }

    public void ChangeSprite()
    {
        if (numLinks == 0)
        {
            if (isOn)
            {
                spark.Play();
            }
            isOn = false;
            gameObject.tag = "Tile";
            GetComponent<SpriteRenderer>().sprite = arrowOff;
            lights.SetActive(false);
        }
        else if (numLinks > 0)
        {
            if (isOn == false)
            {
                spark.Play();
            }
            isOn = true;
            gameObject.tag = "Arrow";
            GetComponent<SpriteRenderer>().sprite = arrowOn;
            lights.SetActive(true);
        }
    }
}
