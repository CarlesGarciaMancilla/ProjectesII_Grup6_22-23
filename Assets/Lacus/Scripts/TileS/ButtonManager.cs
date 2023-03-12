using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public List<GameObject> ListButtons;
    public List<GameObject> ListOnOffArrows;

    private bool restrictAcces = true;

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < ListButtons.Count; i++)
        {
            Debug.Log("Button " + i + " ID: " + ListButtons[i].GetComponent<Buttons>().ID);
        }
        for (int i = 0; i < ListOnOffArrows.Count; i++)
        {
            Debug.Log("Arrow " + i + " ID: " + ListOnOffArrows[i].GetComponent<OnOffArrow>().ID);
        }

        for (int i = 0; i < ListButtons.Count; i++)
        {
            for (int j = 0; j < ListOnOffArrows.Count; j++)
            {
                // Mirar botons i Arrows que tinguin el mateix ID
                if (ListButtons[i].GetComponent<Buttons>().ID == ListOnOffArrows[j].GetComponent<OnOffArrow>().ID)
                { 
                    if(ListButtons[i].GetComponent<Buttons>().isPressed && !restrictAcces)
                    {
                        Debug.Log("HELLO");
                        ListOnOffArrows[j].GetComponent<OnOffArrow>().ChangeSprite();
                        restrictAcces = true;
                    }
                    else if(ListButtons[i].GetComponent<Buttons>().isPressed == false)
                    {
                        restrictAcces = false;
                    }
                }
            }
        }
    }

    public void DeactivateSprites()
    {
        for (int i = 0; i < ListButtons.Count; i++)
        {
            ListButtons[i].GetComponent<SpriteRenderer>().sprite = ListButtons[i].GetComponent<Buttons>().buttonOff;
        }
        for (int i = 0; i < ListOnOffArrows.Count; i++)
        {
            ListOnOffArrows[i].GetComponent<SpriteRenderer>().sprite = ListOnOffArrows[i].GetComponent<OnOffArrow>().arrowOff;
            ListOnOffArrows[i].tag = "Tile";
        }
    }
}
