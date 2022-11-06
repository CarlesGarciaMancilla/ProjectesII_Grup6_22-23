using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

public class LacusMovement : MonoBehaviour
{
    public Transform lacusParent;
    private Vector3 desiredRotation;
    public LacusStats lacusStats;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Forward();
    }

    // Funci� que fa avan�ar en Lacus en direcci� X
    void Forward()
    {

        // Limitar el moviment del Lacus (Implementar vida/bateria)
        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //transform.DOLocalMoveX(transform.localPosition.x + lacusStats.batteryLeft, 4, false);
            //lacusParent.transform.DOMoveX(lacusParent.transform.localPosition.x + 1f, 1f, false);
            transform.DOLocalMoveX(lacusParent.transform.position.x + 1f, 1f, false);
        }

        // Moure's amb Unity
        //transform.localPosition = transform.localPosition + new Vector3(1f * Time.deltaTime, 0f, 0f);
    }

    // Funci� que rota en Lacus donat una rotaci� amb un valor Z
    public void Rotate(Quaternion rotation)
    {

        // Rotar amb DoTween
        transform.DORotateQuaternion(rotation, 0.5f);

        // Rotar amb Unity
        //rotationValues.transform.rotation = Quaternion.Euler(lacusDirection + rotation);
    }
}
