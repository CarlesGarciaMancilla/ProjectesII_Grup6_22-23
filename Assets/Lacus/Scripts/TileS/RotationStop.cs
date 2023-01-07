using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RotationStop: MonoBehaviour
{
    [SerializeField] private Collider2D colliderStop;
    [SerializeField] private LayerMask layerStop;
    private float rotationAngle = 0f;

    [SerializeField] private GameObject Lacus;
    private Collider2D LacusCollider;
    

    // Start is called before the first frame update
    void Start()
    {
       //LacusCollider = Lacus.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfObjectClicked();
    }

    private void CheckIfObjectClicked()
    {
        Vector2 mousePosScreenSpace = Input.mousePosition;
        Vector2 mousePosWorldSpace = Camera.main.ScreenToWorldPoint(mousePosScreenSpace);

        Collider2D col = Physics2D.OverlapPoint(mousePosWorldSpace, layerStop);

        if (col == colliderStop && LacusCollider == colliderStop)
        {
            Debug.Log("ONSTOP");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("LEFT");
                rotationAngle += 90f;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("RIGHT");
                rotationAngle -= 90f;
            }
            //Lacus.transform.Rotate(0f, 0f, rotationAngle, Space.World);
            Lacus.transform.Rotate(0f, 0f, 90f, Space.World);
            rotationAngle = 0f;
        }
    }
}