using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

public class LacusMovement : MonoBehaviour
{
    //public Transform lacusParent;
    [SerializeField] private LacusStats lacusStats;
    [SerializeField] private GameObject Lacus;
    [SerializeField] private Transform destination;
    [SerializeField] private Collider2D destinationCollider;

    [HideInInspector] public bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InitiateToDestinationMovement();
        //InitiateMovementWithJumps();
        //InitiateMovementContinuous();
        //Forward();
        //ForwardWithSpaceKey();

    }

    // Funci� que fa avan�ar en Lacus en direcci� al empty una �nica casella 
    void ForwardWithSpaceKey()
    {
        // Limitar el moviment del Lacus (Implementar vida/bateria)
        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
            transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
        }
    }

    // Funci� que fa avan�ar en Lacus en direcci� al empty seguit per� no �s prec�s 
    public void Forward()
    {
        // Inici del moviment   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 1 && isMoving)
        {
            transform.DOLocalMoveX(destination.transform.position.x, 4f, false);
            transform.DOLocalMoveY(destination.transform.position.y, 4f, false);
        }
    }

    // Funci� que fa avan�ar en Lacus en direcci� al empty una �nica casella per� no es crida al Update() sino en les colisions
    public void ForwardWithJumps()
    {
        // Moure's amb DoTween
        if (lacusStats.batteryLeft > 1 && isMoving)
        {
            Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
            Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
        }
    }

    // Funci� que rota en Lacus donat una rotaci� amb un valor Z
    public void Rotate(Quaternion rotation)
    {
        // Rotar amb DoTween
        Lacus.transform.DORotateQuaternion(rotation, 0.3f);
    }
    
    private void InitiateMovementWithJumps()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isMoving == false)
        {
            isMoving = true;
            ForwardWithJumps();
        }
    }

    private void ForwardContinuous()
    {
        if (isMoving)
        {
            Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
            Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
        }
    }

    private void InitiateMovementContinuous()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isMoving == false)
        {
            isMoving = true;
            ForwardContinuous();
        }
    }

    public void InitiateToDestinationMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isMoving)
            {
                Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1f, false);
                Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1f, false);
            }
            
        }
    }
    public void ToDestinationMovement()
    {
        Lacus.transform.DOLocalMoveX(destination.transform.position.x, 1.5f, false);
        Lacus.transform.DOLocalMoveY(destination.transform.position.y, 1.5f, false);
    }

}
