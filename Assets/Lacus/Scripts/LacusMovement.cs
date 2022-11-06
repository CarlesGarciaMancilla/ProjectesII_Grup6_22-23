using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

public class LacusMovement : MonoBehaviour
{
    public Transform globalRotation;
    private Vector3 desiredRotation;
    public LacusStats lacusStats;
    Grid tile;

    // Start is called before the first frame update
    void Start()
    {
        desiredRotation = new Vector3(0f, 0f, 90f);
        //Rotate(desiredRotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Observar els inputs del teclat (WASD o arrows)
        /*
        if(detectedRotation)
        {
            Rotate(desiredRotation);
        }
        */
        
        Forward();
        
    }

    // Funció que fa avançar en Lacus en direcció X
    void Forward()
    {
       
        // Limitar el moviment del Lacus (Implementar vida/bateria)
        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 0)
        {
            //transform.DOLocalMoveX(transform.localPosition.x + lacusStats.batteryLeft, 4, false);
            transform.DOLocalMoveX(transform.localPosition.x + 1f, 1f, false);
            
        }

        // Moure's amb Unity
        //transform.localPosition = transform.localPosition + new Vector3(1f * Time.deltaTime, 0f, 0f);
    }

    // Funció que rota en Lacus donat una rotació amb un valor Z
    void Rotate(Vector3 rotation)
    {
        Vector3 lacusDirection = new Vector3(0f, 0f, rotation.z);

        // Rotar amb DoTween
        globalRotation.transform.DOLocalRotate(rotation, 0.5f, RotateMode.Fast);

        // Rotar amb Unity
        //rotationValues.transform.rotation = Quaternion.Euler(lacusDirection + rotation);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.CompareTag("Arrow"))
        {
            Debug.Log("Arrow");
        }

        if (collider.CompareTag("Battery"))
        {
            Debug.Log("Battery");
        }

        if (collider.CompareTag("Button"))
        {
            Debug.Log("Button");
        }

        if (collider.CompareTag("Stop"))
        {
            Debug.Log("Stop");
        }

        if (collider.CompareTag("End"))
        {
            Debug.Log("End");
        }

    }
}
