using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHover : MonoBehaviour
{
    public GameObject highlight;

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
