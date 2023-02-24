using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LacusRotationBody : MonoBehaviour 
{
    [SerializeField] private ProtoRotation rotationScript;

    [SerializeField] private LayerMask lacusBodyLayer;
    [SerializeField] private Collider2D colliderBody;

    [SerializeField] private AudioSource lacusTurn;
    [SerializeField] private Transform Lacus;


    void Start()
    {

    }

    void Update()
    {
        rotationScript.ClickRotation(Lacus, colliderBody, lacusBodyLayer, lacusTurn);

        if (Input.touchCount > 0)
        {
            Vector2 touch = Input.GetTouch(0).position;
        }
    }
}
