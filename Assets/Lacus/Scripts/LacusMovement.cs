using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

public class LacusMovement : MonoBehaviour
{
    public Transform globalRotation;
    private Vector3 desiredRotation;

    // Start is called before the first frame update
    void Start()
    {
        desiredRotation = new Vector3(0f, 0f, 90f);
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
        Vector3 lacusDirection = new Vector3(0f, 0f, globalRotation.transform.localRotation.z);

        // Rotar amb DoTween
        globalRotation.transform.DOLocalRotate(lacusDirection + rotation, 0.5f, RotateMode.Fast);

        // Rotar amb Unity
        //rotationValues.transform.rotation = Quaternion.Euler(lacusDirection + rotation);
    }


}
