using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

public class LacusMovement : MonoBehaviour
{
    public Transform rotationValues;
    public Vector3 desiredRotation;

    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.DOLocalMoveX(transform.localPosition.x + 1f, 6f, false);

        // Moure's amb Unity
        //transform.localPosition = transform.localPosition + new Vector3(1f * Time.deltaTime, 0f, 0f);
    }

    // Funció que rota en Lacus donat una rotació amb un valor Z
    void Rotate(Vector3 rotation)
    {
        
        // Rotar amb DoTween
        rotationValues.transform.DOLocalRotate(rotation, 0.5f, RotateMode.Fast);

        // Rotar amb Unity
        //rotationValues.transform.rotation = Quaternion.Euler(rotation);
    }


}
