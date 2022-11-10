using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

public class LacusMovement2 : MonoBehaviour
{
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

    // Funció que fa avançar en Lacus en direcció X
    void Forward()
    {
       
        // Limitar el moviment del Lacus (Implementar vida/bateria)
        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //transform.DOLocalMoveX(transform.localPosition.x + lacusStats.batteryLeft, 4, false);
            transform.DOMoveX(transform.localPosition.x + 1f, 1f, false);
            
            
        }

        // Moure's amb Unity
        //transform.localPosition = transform.localPosition + new Vector3(1f * Time.deltaTime, 0f, 0f);
    }

    // Funció que rota en Lacus donat una rotació amb un valor Z
    public void Rotate(Quaternion rotation)
    {
        Debug.Log("Hello im under the water");
        // Rotar amb DoTween
        transform.DORotateQuaternion(rotation, 0f);

        // Rotar amb Unity
        //rotationValues.transform.rotation = Quaternion.Euler(lacusDirection + rotation);
    }
}
