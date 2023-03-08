using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RotationArrow : MonoBehaviour
{
    [SerializeField] private ProtoRotation rotationScript;

    [SerializeField] private LayerMask layerArrow;
    [SerializeField] private Collider2D colliderArrow;


    [SerializeField] private AudioSource arrowTurn;
    

    void Start()
    {

    }

    void Update()
    {
        rotationScript.ClickRotation(colliderArrow.transform, colliderArrow, layerArrow, arrowTurn);

        if (Input.touchCount > 0)
        {
            Vector2 touch = Input.GetTouch(0).position;
        }
    }
}