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
    [SerializeField] private Collider2D LacusCollider;
    

    // Start is called before the first frame update
    void Start()
    {

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
        
        if (col == colliderStop)
        //if (col == colliderStop && LacusCollider == colliderStop)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            { 
            
                rotationAngle += 90f;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                rotationAngle -= 90f;
            }

            if (rotationAngle != 0)
            {
                Debug.Log("AAAA");
                Lacus.gameObject.transform.Rotate(0f, 0f, rotationAngle, Space.Self);
            }
            rotationAngle = 0f;
        }
    }
}