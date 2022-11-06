using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Button : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public SpriteRenderer spriteRenderer;
    public GameObject highlight;
    public Collider2D colliderLacus;


    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? color1 : color2;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    public void CheckIfObjectClickedRight()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        Vector2 mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);



        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace);

        if (col == colliderLacus)
        {

            Debug.Log("activa cosas :)");
            


        }

    }




}
