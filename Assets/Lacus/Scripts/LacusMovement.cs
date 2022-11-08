using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

public class LacusMovement : MonoBehaviour
{
    //public Transform lacusParent;
    public LacusStats lacusStats;
    public Transform destination;


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
            transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
            transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
        }
    }

    // Funció que rota en Lacus donat una rotació amb un valor Z
    public void Rotate(Quaternion rotation)
    {
        // Rotar amb DoTween
        transform.DORotateQuaternion(rotation, 0.5f);
    }
}
