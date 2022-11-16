using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TileSpriteFletxa2 : MonoBehaviour
{
    //public SpriteRenderer spriteRenderer;

    public Collider2D colliderArrow;
    private float rotationAngle = 0f;

    [SerializeField] private LayerMask layerArrow;

    void Start()
    {

    }

    void Update()
    {
        CheckIfObjectClicked();

        if (Input.touchCount > 0)
        {
            Vector2 touch = Input.GetTouch(0).position;
        }
    }

    private void CheckIfObjectClicked()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        Vector2 mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);

        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace, layerArrow);

        if (col == colliderArrow)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                rotationAngle += 90f;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rotationAngle -= 90f;
            }
            col.gameObject.transform.Rotate(0f, 0f, rotationAngle, Space.World);
            rotationAngle = 0f;
        }
    }
}