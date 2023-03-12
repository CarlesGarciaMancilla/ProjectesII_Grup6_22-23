using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Rendering;

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
        /*if (restrictAcces)
        {
            ListOnOffArrows[0].GetComponent<OnOffArrow>().test = "HOLA";
            ListOnOffArrows[1].GetComponent<OnOffArrow>().test = "ADEU";

            Debug.Log("0:" + ListOnOffArrows[0].GetComponent<OnOffArrow>().test);
            Debug.Log("1:" + ListOnOffArrows[1].GetComponent<OnOffArrow>().test);

            ListOnOffArrows[1].GetComponent<OnOffArrow>().test = "WOW";

            Debug.Log("0:" + ListOnOffArrows[0].GetComponent<OnOffArrow>().test);
            Debug.Log("1:" + ListOnOffArrows[1].GetComponent<OnOffArrow>().test);

            restrictAcces = false;
        }*/


        /*for (int i = 0; i < ListButtons.Count; i++)
        {
            Debug.Log("Button " + i + " ID: " + ListButtons[i].GetComponent<Buttons>().ID);
        }
        for (int i = 0; i < ListOnOffArrows.Count; i++)
        {
            Debug.Log("Arrow " + i + " ID: " + ListOnOffArrows[i].GetComponent<OnOffArrow>().ID);
        }*/

        //for (int i = 0; i < ListButtons.Count; i++)
        //{
            //for (int j = 0; j < ListOnOffArrows.Count; j++)
            //{
                // Mirar botons i Arrows que tinguin el mateix ID
                //if (ListButtons[i].GetComponent<Buttons>().ID == ListOnOffArrows[j].GetComponent<OnOffArrow>().ID)
                //{
                    //if (ListOnOffArrows[j].GetComponent<OnOffArrow>().numLinks > 0 && !restrictAcces) 
                    //Debug.Log("Step: " + j + " Active Links: " + ListOnOffArrows[j].GetComponent<OnOffArrow>().numLinks);
                    //if (ListOnOffArrows[j].GetComponent<OnOffArrow>().numLinks > 0 && ListButtons[i].GetComponent<Buttons>().ID == ListOnOffArrows[j].GetComponent<OnOffArrow>().ID) 
                   // {
                        //Debug.Log("Active Links: " + ListOnOffArrows[j].GetComponent<OnOffArrow>().numLinks);

                    //    ListOnOffArrows[j].GetComponent<OnOffArrow>().ChangeSprite();
                    //    restrictAcces = true;
                   // }
                    /*else if(ListOnOffArrows[j].GetComponent<OnOffArrow>().numLinks == 0)
                    {
                        restrictAcces = false;
                    }*/


                    /*if(ListButtons[i].GetComponent<Buttons>().isPressed && !restrictAcces)
                    {
                        Debug.Log("HELLO");
                        ListOnOffArrows[j].GetComponent<OnOffArrow>().ChangeSprite();
                        restrictAcces = true;
                    }
                    else if(ListButtons[i].GetComponent<Buttons>().isPressed == false)
                    {
                        restrictAcces = false;
                    }*/
                //}
            //}
       //}
    }

    public void DeactivateSprites()
    {
        for (int i = 0; i < ListButtons.Count; i++)
        {
            ListButtons[i].GetComponent<SpriteRenderer>().sprite = ListButtons[i].GetComponent<Buttons>().buttonOff;

            ListButtons[i].GetComponent<Buttons>().isPressed = false;
        }
        for (int i = 0; i < ListOnOffArrows.Count; i++)
        {
            ListOnOffArrows[i].GetComponent<SpriteRenderer>().sprite = ListOnOffArrows[i].GetComponent<OnOffArrow>().arrowOff;
            ListOnOffArrows[i].tag = "Tile";

            ListOnOffArrows[i].GetComponent<OnOffArrow>().numLinks = 0;
        }
    }
}
