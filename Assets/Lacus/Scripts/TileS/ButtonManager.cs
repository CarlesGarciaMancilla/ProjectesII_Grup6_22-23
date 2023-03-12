using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Rendering;

public class ButtonManager : MonoBehaviour
{
    public List<GameObject> ListButtons;
    public List<GameObject> ListOnOffArrows;

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
