using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LacusRotationBody : MonoBehaviour
{
    [SerializeField] private LayerMask lacusBodyLayer;
    [SerializeField] private Collider2D colliderBody;
    private float rotationAngle = 0f;
    [SerializeField] private AudioSource lacusTurn;
    [SerializeField] private Transform Lacus;


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

        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace, lacusBodyLayer);

        if (col == colliderBody)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rotationAngle += 90f;
                lacusTurn.Play();
            }

            if (Input.GetMouseButtonDown(1))
            {
                rotationAngle -= 90f;
                lacusTurn.Play();
            }
            Lacus.Rotate(0f, 0f, rotationAngle, Space.World);
            rotationAngle = 0f;
        }
    }
}
